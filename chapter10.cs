using System;
using System.Linq;

class HugeInteger
{
    private int[] digits;
    private bool isNegative;

    public HugeInteger(string number)
    {
        if (number.StartsWith("-"))
        {
            isNegative = true;
            number = number.Substring(1);
        }

        if (!number.All(char.IsDigit))
            throw new ArgumentException("Invalid number");

        digits = number.TrimStart('0').DefaultIfEmpty('0')
                       .Select(c => c - '0')
                       .ToArray();
    }

    private HugeInteger(int[] digits, bool neg)
    {
        this.digits = digits;
        this.isNegative = neg;
    }

    public override string ToString()
    {
        string s = string.Join("", digits);
        return isNegative && s != "0" ? "-" + s : s;
    }

    /* -------------------- OPERATORS -------------------- */

    public static HugeInteger operator +(HugeInteger a, HugeInteger b)
    {
        if (a.isNegative == b.isNegative)
        {
            return new HugeInteger(Add(a.digits, b.digits), a.isNegative);
        }

        int cmp = CompareAbs(a, b);

        if (cmp == 0) return new HugeInteger(new[] { 0 }, false);
        if (cmp > 0) return new HugeInteger(Sub(a.digits, b.digits), a.isNegative);
        return new HugeInteger(Sub(b.digits, a.digits), b.isNegative);
    }

    public static HugeInteger operator -(HugeInteger a, HugeInteger b)
        => a + new HugeInteger(b.digits, !b.isNegative);

    public static bool operator ==(HugeInteger a, HugeInteger b)
        => a?.isNegative == b?.isNegative && a?.digits.SequenceEqual(b?.digits ?? Array.Empty<int>()) == true;

    public static bool operator !=(HugeInteger a, HugeInteger b)
        => !(a == b);

    public static bool operator >(HugeInteger a, HugeInteger b)
    {
        if (a.isNegative != b.isNegative) return !a.isNegative;
        int cmp = CompareAbs(a, b);
        return a.isNegative ? cmp < 0 : cmp > 0;
    }

    public static bool operator <(HugeInteger a, HugeInteger b)
        => b > a;

    public static bool operator >=(HugeInteger a, HugeInteger b)
        => a > b || a == b;

    public static bool operator <=(HugeInteger a, HugeInteger b)
        => a < b || a == b;

    

    private static int[] Add(int[] a, int[] b)
    {
        int carry = 0;
        int max = Math.Max(a.Length, b.Length);
        int[] result = new int[max + 1];

        for (int i = 0; i < result.Length; i++)
        {
            int da = (a.Length - 1 - i >= 0) ? a[a.Length - 1 - i] : 0;
            int db = (b.Length - 1 - i >= 0) ? b[b.Length - 1 - i] : 0;

            int sum = da + db + carry;
            result[result.Length - 1 - i] = sum % 10;
            carry = sum / 10;
        }

        return result.SkipWhile((x, i) => x == 0 && i < result.Length - 1).ToArray();
    }

    private static int[] Sub(int[] a, int[] b) // assumes |a| >= |b|
    {
        int borrow = 0;
        int[] result = new int[a.Length];

        for (int i = 0; i < a.Length; i++)
        {
            int da = a[a.Length - 1 - i] - borrow;
            int db = (b.Length - 1 - i >= 0) ? b[b.Length - 1 - i] : 0;

            if (da < db)
            {
                da += 10;
                borrow = 1;
            }
            else borrow = 0;

            result[result.Length - 1 - i] = da - db;
        }

        return result.SkipWhile((x, i) => x == 0 && i < result.Length - 1).ToArray();
    }

    private static int CompareAbs(HugeInteger a, HugeInteger b)
    {
        if (a.digits.Length != b.digits.Length)
            return a.digits.Length.CompareTo(b.digits.Length);

        for (int i = 0; i < a.digits.Length; i++)
            if (a.digits[i] != b.digits[i])
                return a.digits[i].CompareTo(b.digits[i]);

        return 0;
    }

    public override bool Equals(object obj)
        => obj is HugeInteger h && this == h;

    public override int GetHashCode()
        => digits.Length ^ isNegative.GetHashCode();
}
