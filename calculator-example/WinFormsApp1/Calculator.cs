
namespace WinFormsApp1

{
    public class Calculator
    {
        private string currentInput = "";
        private string lastInput = "";
        private string operation = "";
        private bool resultCalculated = false;

        public string Display => currentInput;

        public void EnterDigit(string digit)
        {
            if (resultCalculated)
            {
                currentInput = "";
                resultCalculated = false;
            }

            currentInput += digit;
        }

        public void Clear()
        {
            currentInput = "";
            lastInput = "";
            operation = "";
        }

        public void ClearAll()
        {
            Clear();
        }

        public void SetOperation(string op)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                lastInput = currentInput;
                currentInput = "";
                operation = op;
            }
        }

        public void CalculateResult()
        {
            try
            {
                double num1 = double.Parse(lastInput);
                double num2 = double.Parse(currentInput);

                switch (operation)
                {
                    case "+":
                        currentInput = (num1 + num2).ToString();
                        break;
                    case "-":
                        currentInput = (num1 - num2).ToString();
                        break;
                    case "*":
                        currentInput = (num1 * num2).ToString();
                        break;
                    case "/":
                        currentInput = num2 != 0 ? (num1 / num2).ToString() : "Error";
                        break;
                    case "%":
                        currentInput = (num1 % num2).ToString();
                        break;
                    default:
                        currentInput = "Error";
                        break;
                }

                resultCalculated = true;
                lastInput = "";
                operation = "";
            }
            catch
            {
                currentInput = "Error";
            }
        }
    }
}
