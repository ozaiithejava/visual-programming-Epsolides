using System;
using System.Globalization;
using System.Text;

class SimpletronSimulator
{
    private const int MEM_SIZE = 1000;

    private int[] rawWords = new int[MEM_SIZE];
    private double[] floatWords = new double[MEM_SIZE];
    private bool[] isFloat = new bool[MEM_SIZE];

    private double accumulatorDouble = 0.0;
    private long accumulatorInt = 0;
    private bool accIsFloat = false;

    private int instructionCounter = 0;
    private int instructionRegister = 0;
    private int operationCode = 0;
    private int operand = 0;

    private Random rng = new Random();

    enum Op : byte
    {
        READ_INT = 0x10,
        WRITE_INT = 0x11,
        READ_FLOAT = 0x12,
        WRITE_FLOAT = 0x13,
        READ_STR = 0x14,
        WRITE_STR = 0x15,
        NEWLINE = 0x16,

        LOAD_INT = 0x20,
        STORE_INT = 0x21,
        LOAD_FLOAT = 0x22,
        STORE_FLOAT = 0x23,

        ADD_INT = 0x30,
        SUB_INT = 0x31,
        MUL_INT = 0x32,
        DIV_INT = 0x33,
        MOD_INT = 0x34,
        POW_INT = 0x35,

        ADD_FLOAT = 0x36,
        SUB_FLOAT = 0x37,
        MUL_FLOAT = 0x38,
        DIV_FLOAT = 0x39,
        POW_FLOAT = 0x3A,

        BRANCH = 0x40,
        BRANCHNEG = 0x41,
        BRANCHZERO = 0x42,
        HALT = 0xFF
    }

    public SimpletronSimulator()
    {
        ClearMemory();
    }

    private void ClearMemory()
    {
        for (int i = 0; i < MEM_SIZE; i++)
        {
            rawWords[i] = 0;
            floatWords[i] = double.NaN;
            isFloat[i] = false;
        }
        accumulatorDouble = 0;
        accumulatorInt = 0;
        accIsFloat = false;
        instructionCounter = 0;
    }

    private int EncodeInstruction(byte opcode, int operand12)
    {
        return (opcode << 12) | (operand12 & 0xFFF);
    }

    private void DecodeInstruction(int instr)
    {
        operationCode = (instr >> 12) & 0xFF;
        operand = instr & 0xFFF;
    }

    private void StoreInt(int addr, int v)
    {
        rawWords[addr] = v;
        isFloat[addr] = false;
        floatWords[addr] = double.NaN;
    }

    private int LoadInt(int addr)
    {
        return rawWords[addr];
    }

    private void StoreFloat(int addr, double v)
    {
        floatWords[addr] = v;
        isFloat[addr] = true;
        rawWords[addr] = 0;
    }

    private double LoadFloat(int addr)
    {
        return floatWords[addr];
    }

    private void WriteStringToMemory(int start, string s)
    {
        string up = s.ToUpperInvariant();
        int len = up.Length;
        int idx = 0;

        int high = len & 0xFFFF;
        int low = idx < len ? up[idx] : 0;
        idx++;

        rawWords[start] = (high << 16) | (low & 0xFFFF);

        int a = start + 1;

        while (idx < len)
        {
            int h = idx < len ? up[idx] : 0;
            idx++;
            int l = idx < len ? up[idx] : 0;
            idx++;

            rawWords[a] = (h << 16) | (l & 0xFFFF);
            a++;

            if (a >= MEM_SIZE) break;
        }
    }

    private string ReadStringFromMemory(int start)
    {
        int w0 = rawWords[start];
        int len = (w0 >> 16) & 0xFFFF;
        if (len <= 0) return "";

        StringBuilder sb = new StringBuilder(len);
        int idx = 0;
        int addr = start;

        while (idx < len)
        {
            int word = rawWords[addr];
            int high = (word >> 16) & 0xFFFF;
            int low = word & 0xFFFF;

            if (addr == start)
            {
                if (low != 0)
                {
                    sb.Append((char)low);
                    idx++;
                }
            }
            else
            {
                if (high != 0 && idx < len)
                {
                    sb.Append((char)high);
                    idx++;
                }
                if (low != 0 && idx < len)
                {
                    sb.Append((char)low);
                    idx++;
                }
            }

            addr++;
        }
        return sb.ToString();
    }

    public void InteractiveLoad()
    {
        Console.WriteLine("Hex instructions (6 hex digits). Empty = finish. SAMPLE loads demo.");

        while (true)
        {
            Console.Write("load> ");
            string line = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(line)) break;

            if (line.Equals("SAMPLE", StringComparison.OrdinalIgnoreCase))
            {
                LoadSampleProgram();
                break;
            }

            line = line.Replace(" ", "");

            if (line.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                line = line.Substring(2);

            line = line.PadLeft(6, '0');

            if (!int.TryParse(line, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int instr))
            {
                Console.WriteLine("Invalid hex.");
                continue;
            }

            rawWords[instructionCounter] = instr;
            instructionCounter++;

            if (instructionCounter >= MEM_SIZE)
            {
                Console.WriteLine("Memory full.");
                break;
            }
        }

        instructionCounter = 0;
    }

    private void LoadSampleProgram()
    {
        ClearMemory();
        int pc = 0;
        rawWords[pc++] = EncodeInstruction((byte)Op.READ_STR, 50);
        rawWords[pc++] = EncodeInstruction((byte)Op.WRITE_STR, 50);
        rawWords[pc++] = EncodeInstruction((byte)Op.NEWLINE, 0);
        rawWords[pc++] = EncodeInstruction((byte)Op.HALT, 0);
    }

    public void Run()
    {
        instructionCounter = 0;
        bool halt = false;

        while (!halt)
        {
            instructionRegister = rawWords[instructionCounter];
            DecodeInstruction(instructionRegister);
            instructionCounter++;

            Op op = (Op)operationCode;

            switch (op)
            {
                case Op.READ_INT:
                    Console.Write($"int@{operand}: ");
                    if (int.TryParse(Console.ReadLine(), out int iv))
                        StoreInt(operand, iv);
                    else StoreInt(operand, 0);
                    break;

                case Op.WRITE_INT:
                    Console.WriteLine(LoadInt(operand));
                    break;

                case Op.READ_FLOAT:
                    Console.Write($"float@{operand}: ");
                    if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double fv))
                        StoreFloat(operand, fv);
                    else StoreFloat(operand, 0.0);
                    break;

                case Op.WRITE_FLOAT:
                    Console.WriteLine(
                        isFloat[operand]
                        ? LoadFloat(operand).ToString(CultureInfo.InvariantCulture)
                        : ((double)LoadInt(operand)).ToString(CultureInfo.InvariantCulture)
                    );
                    break;

                case Op.READ_STR:
                    Console.Write("string: ");
                    WriteStringToMemory(operand, Console.ReadLine());
                    break;

                case Op.WRITE_STR:
                    Console.Write(ReadStringFromMemory(operand));
                    break;

                case Op.NEWLINE:
                    Console.WriteLine();
                    break;

                case Op.LOAD_INT:
                    accumulatorInt = LoadInt(operand);
                    accIsFloat = false;
                    break;

                case Op.STORE_INT:
                    StoreInt(operand, (int)accumulatorInt);
                    break;

                case Op.LOAD_FLOAT:
                    accumulatorDouble = isFloat[operand] ? LoadFloat(operand) : LoadInt(operand);
                    accIsFloat = true;
                    break;

                case Op.STORE_FLOAT:
                    StoreFloat(operand, accumulatorDouble);
                    break;

                case Op.ADD_INT:
                    accumulatorInt += LoadInt(operand);
                    accIsFloat = false;
                    break;

                case Op.SUB_INT:
                    accumulatorInt -= LoadInt(operand);
                    accIsFloat = false;
                    break;

                case Op.MUL_INT:
                    accumulatorInt *= LoadInt(operand);
                    accIsFloat = false;
                    break;

                case Op.DIV_INT:
                    int dv = LoadInt(operand);
                    accumulatorInt = dv == 0 ? 0 : accumulatorInt / dv;
                    accIsFloat = false;
                    break;

                case Op.MOD_INT:
                    int mv = LoadInt(operand);
                    accumulatorInt = mv == 0 ? 0 : accumulatorInt % mv;
                    accIsFloat = false;
                    break;

                case Op.POW_INT:
                    int exp = LoadInt(operand);
                    long result = 1;
                    if (exp >= 0)
                        for (int i = 0; i < exp; i++)
                            result *= accumulatorInt;
                    accumulatorInt = result;
                    accIsFloat = false;
                    break;

                case Op.ADD_FLOAT:
                    accumulatorDouble = (accIsFloat ? accumulatorDouble : accumulatorInt)
                        + (isFloat[operand] ? LoadFloat(operand) : LoadInt(operand));
                    accIsFloat = true;
                    break;

                case Op.SUB_FLOAT:
                    accumulatorDouble = (accIsFloat ? accumulatorDouble : accumulatorInt)
                        - (isFloat[operand] ? LoadFloat(operand) : LoadInt(operand));
                    accIsFloat = true;
                    break;

                case Op.MUL_FLOAT:
                    accumulatorDouble = (accIsFloat ? accumulatorDouble : accumulatorInt)
                        * (isFloat[operand] ? LoadFloat(operand) : LoadInt(operand));
                    accIsFloat = true;
                    break;

                case Op.DIV_FLOAT:
                    double div = isFloat[operand] ? LoadFloat(operand) : LoadInt(operand);
                    accumulatorDouble = div == 0 ? 0 : (accIsFloat ? accumulatorDouble : accumulatorInt) / div;
                    accIsFloat = true;
                    break;

                case Op.POW_FLOAT:
                    double rhs = isFloat[operand] ? LoadFloat(operand) : LoadInt(operand);
                    accumulatorDouble = Math.Pow(accIsFloat ? accumulatorDouble : accumulatorInt, rhs);
                    accIsFloat = true;
                    break;

                case Op.BRANCH:
                    instructionCounter = operand;
                    break;

                case Op.BRANCHNEG:
                    if ((accIsFloat ? accumulatorDouble : accumulatorInt) < 0)
                        instructionCounter = operand;
                    break;

                case Op.BRANCHZERO:
                    if (Math.Abs(accIsFloat ? accumulatorDouble : accumulatorInt) < 1e-12)
                        instructionCounter = operand;
                    break;

                case Op.HALT:
                    halt = true;
                    break;
            }
        }

        Console.WriteLine("\nProgram halted.");
        Console.WriteLine(accIsFloat ? $"ACC(float)= {accumulatorDouble}" : $"ACC(int)= {accumulatorInt}");
    }

    public void DumpMemory(int from = 0, int count = 32)
    {
        int end = Math.Min(MEM_SIZE, from + count);
        for (int i = from; i < end; i++)
        {
            Console.WriteLine($"{i:D3}: {rawWords[i]:X6}");
        }
    }

    public void ProgramWriteInstruction(int addr, Op op, int operandAddr)
    {
        rawWords[addr] = EncodeInstruction((byte)op, operandAddr);
    }

    public void LoadModPowSample()
    {
        ClearMemory();
        int pc = 0;
        ProgramWriteInstruction(pc++, Op.READ_INT, 100);
        ProgramWriteInstruction(pc++, Op.READ_INT, 101);
        ProgramWriteInstruction(pc++, Op.LOAD_INT, 100);
        ProgramWriteInstruction(pc++, Op.POW_INT, 101);
        ProgramWriteInstruction(pc++, Op.STORE_INT, 102);
        ProgramWriteInstruction(pc++, Op.WRITE_INT, 102);
        ProgramWriteInstruction(pc++, Op.HALT, 0);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Simpletron Simulator – made by ozaiithejava");

        var sim = new SimpletronSimulator();

        while (true)
        {
            Console.WriteLine("\n1) Load program (hex)");
            Console.WriteLine("2) Load sample string program");
            Console.WriteLine("3) Load mod/pow sample");
            Console.WriteLine("4) Dump memory");
            Console.WriteLine("5) Run");
            Console.WriteLine("6) Clear memory");
            Console.WriteLine("0) Exit");

            Console.Write("Option: ");
            string opt = Console.ReadLine();

            if (opt == "0") break;

            switch (opt)
            {
                case "1": sim.InteractiveLoad(); break;
                case "2": sim.LoadSampleProgram(); break;
                case "3": sim.LoadModPowSample(); break;
                case "4": sim.DumpMemory(0, 64); break;
                case "5": sim.Run(); break;
                case "6": sim = new SimpletronSimulator(); break;
                default: Console.WriteLine("Invalid."); break;
            }
        }

        Console.WriteLine("Exiting… made by ozaiithejava");
    }
}
