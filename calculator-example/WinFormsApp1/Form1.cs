using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();

            // Otomatik olarak bazı butonlara ortak event bağlamak için (opsiyonel)
            foreach (var control in panel1.Controls)
            {
                if (control is Button btn)
                {
                    if (int.TryParse(btn.Text, out _) || btn.Text == "00")
                        btn.Click += DigitButton_Click;
                    else if (btn.Text == "+" || btn.Text == "-" || btn.Text == "*" || btn.Text == "/" || btn.Text == "%")
                        btn.Click += OperationButton_Click;
                    else if (btn.Text == "=")
                        btn.Click += EqualButton_Click;
                    else if (btn.Text == "C")
                        btn.Click += ClearButton_Click;
                    else if (btn.Text == "C/A")
                        btn.Click += ClearAllButton_Click;
                    else if (btn.Text == "off")
                        btn.Click += OffButton_Click;
                }
            }
        }

        private void DigitButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calculator.EnterDigit(btn.Text);
            textBox1.Text = calculator.Display;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calculator.SetOperation(btn.Text);
            textBox1.Text = "";
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            calculator.CalculateResult();
            textBox1.Text = calculator.Display;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            textBox1.Text = "";
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            calculator.ClearAll();
            textBox1.Text = "";
        }

        private void OffButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Bu butonlara özel eventler istenmişti, onları da doğrudan aşağıda implement ediyoruz:
        private void button6_Click(object sender, EventArgs e)
        {
            calculator.EnterDigit("4");
            textBox1.Text = calculator.Display;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculator.EnterDigit("5");
            textBox1.Text = calculator.Display;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            calculator.SetOperation("/");
            textBox1.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            calculator.ClearAll();
            textBox1.Text = "";
        }

  private void button20_Click(object sender, EventArgs e)
{
    DialogResult result = MessageBox.Show(
        "Hesap makinesini kapatmak istediğinize emin misiniz?",
        "Kapatmayı Onayla",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

    if (result == DialogResult.Yes)
    {
        Application.Exit();
    }
}

    }
}
