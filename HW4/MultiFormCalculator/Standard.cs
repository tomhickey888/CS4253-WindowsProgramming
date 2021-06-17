using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFormCalculator
{
    public partial class Standard : Form
    {
        private bool dec = false;
        private string op;

        public Standard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String num = "0";
            txtBox.Text = num;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad9:
                    e.Handled = true;
                    button9.PerformClick();
                    break;
                case Keys.D9:
                    e.Handled = true;
                    button9.PerformClick();
                    break;
                case Keys.NumPad8:
                    e.Handled = true;
                    button8.PerformClick();
                    break;
                case Keys.D8:
                    e.Handled = true;
                    button8.PerformClick();
                    break;
                case Keys.NumPad7:
                    e.Handled = true;
                    button7.PerformClick();
                    break;
                case Keys.D7:
                    e.Handled = true;
                    button7.PerformClick();
                    break;
                case Keys.NumPad6:
                    e.Handled = true;
                    button6.PerformClick();
                    break;
                case Keys.D6:
                    e.Handled = true;
                    button6.PerformClick();
                    break;
                case Keys.NumPad5:
                    e.Handled = true;
                    button5.PerformClick();
                    break;
                case Keys.D5:
                    e.Handled = true;
                    button5.PerformClick();
                    break;
                case Keys.NumPad4:
                    e.Handled = true;
                    button4.PerformClick();
                    break;
                case Keys.D4:
                    e.Handled = true;
                    button4.PerformClick();
                    break;
                case Keys.NumPad3:
                    e.Handled = true;
                    button3.PerformClick();
                    break;
                case Keys.D3:
                    e.Handled = true;
                    button3.PerformClick();
                    break;
                case Keys.NumPad2:
                    e.Handled = true;
                    button2.PerformClick();
                    break;
                case Keys.D2:
                    e.Handled = true;
                    button2.PerformClick();
                    break;
                case Keys.NumPad1:
                    e.Handled = true;
                    button1.PerformClick();
                    break;
                case Keys.D1:
                    e.Handled = true;
                    button1.PerformClick();
                    break;
                case Keys.NumPad0:
                    e.Handled = true;
                    button0.PerformClick();
                    break;
                case Keys.D0:
                    e.Handled = true;
                    button0.PerformClick();
                    break;
                case Keys.Divide:
                    e.Handled = true;
                    buttonDivide.PerformClick();
                    break;
                case Keys.OemBackslash:
                    e.Handled = true;
                    buttonDivide.PerformClick();
                    break;
                case Keys.Multiply:
                    e.Handled = true;
                    buttonMultiply.PerformClick();
                    break;
                case Keys.Subtract:
                    e.Handled = true;
                    buttonSubtract.PerformClick();
                    break;
                case Keys.OemMinus:
                    e.Handled = true;
                    buttonSubtract.PerformClick();
                    break;
                case Keys.Add:
                    e.Handled = true;
                    buttonAdd.PerformClick();
                    break;
                case Keys.Oemplus:
                    e.Handled = true;
                    buttonAdd.PerformClick();
                    break;
                case Keys.OemPeriod:
                    e.Handled = true;
                    buttonDec.PerformClick();
                    break;
                case Keys.Decimal:
                    e.Handled = true;
                    buttonDec.PerformClick();
                    break;
                case Keys.Space:
                    e.Handled = true;
                    buttonEquals.PerformClick();
                    break;
                case Keys.Back:
                    e.Handled = true;
                    buttonDelete.PerformClick();
                    break;
                case Keys.Escape:
                    e.Handled = true;
                    buttonClearAll.PerformClick();
                    break;
            }
        }

        private void operatorButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            op = btn.Text;
            string text = txtBox.Text;

            if (text == "0")
            {
                if(txtBoxResult.Text != "")
                {
                    txtBoxPrev.Text = txtBoxResult.Text;
                    txtBoxOp.Text = op;
                }

                else
                {
                    txtBox.Text = "0";
                    txtBoxPrev.Text = text;
                    txtBoxOp.Text = op;
                }
            }

            else
            {
                txtBox.Text = "0";
                txtBoxPrev.Text = text;
                txtBoxOp.Text = op;
            }
        }

        private void numericButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int digit = Convert.ToInt32(btn.Text);
            string text = txtBox.Text;

            if (text.Length < 17)
            {
                if (dec == false)
                {
                    if (text == "")
                    {
                        txtBoxPrev.Text = "";
                        txtBox.Text = "0";
                        dec = false;
                    }

                    else if (text == "0")
                    {
                        if (digit != 0)
                            txtBox.Text = digit.ToString();
                    }

                    else
                        txtBox.Text += digit.ToString();
                }
                else
                {
                    if (text == "0")
                    {
                        txtBox.Text = "0.";
                        txtBox.Text += digit.ToString();
                    }

                    else if (text.Contains("."))
                    {
                        txtBox.Text += digit.ToString();
                    }

                    else
                        txtBox.Text += "." + digit.ToString();
                }
            }
        }

        private void buttonDecClick(object sender, EventArgs e)
        {
            if (!dec)
            {
                dec = true;
            }
        }

        private void buttonClearLine_Click(object sender, EventArgs e)
        {
            if (txtBox.Text != "0")
            {
                txtBox.Text = "0";
                dec = false;
            }

            else
            {
                txtBoxPrev.Text = "";
                txtBox.Text = "0";
                txtBoxResult.Text = "";
                txtBoxOp.Text = "";
                dec = false;
                op = "";
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            txtBoxPrev.Text = "";
            txtBox.Text = "0";
            txtBoxResult.Text = "";
            txtBoxOp.Text = "";
            dec = false;
            op = "";
        }

        private void buttonPosNeg_Click(object sender, EventArgs e)
        {
            string text = txtBox.Text;

            if (text == "0")
            {
                if (txtBoxResult.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxResult.Text);
                    num *= -1;
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }

                else if(txtBoxPrev.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxPrev.Text);
                    num *= -1;
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }
            }

            else
            {
                double num = Convert.ToDouble(text);
                num *= -1;
                text = num.ToString();
            }

            if (!text.Contains('E'))
            {
                if (text.Length > 17)
                    text = text.Substring(0, 17);

                txtBox.Text = text;
            }
        }

        private void buttonSqRt_Click(object sender, EventArgs e)
        {
            string text = txtBox.Text;

            if (text == "0")
            {
                if (txtBoxResult.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxResult.Text);
                    num = Math.Sqrt(num);
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }

                else if (txtBoxPrev.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxPrev.Text);
                    num = Math.Sqrt(num);
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }
            }

            else
            {
                double num = Convert.ToDouble(text);
                num = Math.Sqrt(num);
                text = num.ToString();
            }

            if (!text.Contains('E'))
            {
                if (text.Length > 17)
                    text = text.Substring(0, 17);

                txtBox.Text = text;
            }
        }

        private void buttonSq_Click(object sender, EventArgs e)
        {
            string text = txtBox.Text;

            if (text == "0")
            {
                if (txtBoxResult.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxResult.Text);
                    num = Math.Pow(num, 2);
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }

                else if (txtBoxPrev.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxPrev.Text);
                    num = Math.Pow(num, 2);
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }
            }

            else
            {
                double num = Convert.ToDouble(text);
                num = Math.Pow(num, 2);
                text = num.ToString();
            }

            if (!text.Contains('E'))
            {
                if (text.Length > 17)
                    text = text.Substring(0, 17);

                txtBox.Text = text;
            }
        }

        private void buttonInverse_Click(object sender, EventArgs e)
        {
            string text = txtBox.Text;

            if (text == "0")
            {
                if (txtBoxResult.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxResult.Text);
                    num = 1 / num;
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }

                else if (txtBoxPrev.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxPrev.Text);
                    num = 1 / num;
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }
            }

            else
            {
                double num = Convert.ToDouble(text);
                num = 1 / num;
                text = num.ToString();
            }

            if (!text.Contains('E'))
            {
                if (text.Length > 17)
                    text = text.Substring(0, 17);

                txtBox.Text = text;
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            string text = txtBox.Text;

            if (text == "0")
            {
                if (txtBoxResult.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxResult.Text);
                    num = num * 0.01;
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }

                else if (txtBoxPrev.Text != "")
                {
                    double num = Convert.ToDouble(txtBoxPrev.Text);
                    num = num * 0.01;
                    text = num.ToString();
                    txtBoxResult.Text = "";
                    txtBoxPrev.Text = "";
                    txtBoxOp.Text = "";
                    op = "";
                    dec = false;
                }
            }

            else
            {
                double num = Convert.ToDouble(text);
                num = num * 0.01;
                text = num.ToString();
            }

            if (!text.Contains('E'))
            {
                if (text.Length > 17)
                    text = text.Substring(0, 17);

                txtBox.Text = text;
            }
        }
        
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (txtBoxPrev.Text != "")
            {
                double op1 = Convert.ToDouble(txtBoxPrev.Text);
                double op2 = Convert.ToDouble(txtBox.Text);
                double result = 0;
                string optr = op;

                switch (optr)
                {
                    case "÷":
                        if (op2 != 0)
                            result = op1 / op2;
                        op = "=";
                        break;

                    case "x":
                        result = op1 * op2;
                        op = "=";
                        break;

                    case "-":
                        result = op1 - op2;
                        op = "=";
                        break;

                    case "+":
                        result = op1 + op2;
                        op = "=";
                        break;
                }

                string text = result.ToString();

                if (!text.Contains('E'))
                {
                    if (text.Length > 17)
                        text = text.Substring(0, 17);

                    txtBoxPrev.Text = "";
                    txtBox.Text = "0";
                    txtBoxOp.Text = op;
                    txtBoxResult.Text = text;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string text = txtBox.Text;

            if(text.Length > 0)
            {
                text = text.Substring(0, (text.Length - 1));

                if (text.Length == 0)
                {
                    text = "0";
                }

                txtBox.Text = text;
            }

            if(text == "0")
                if (dec)
                    dec = false;
        }

        private void conversionSwitch(object sender, EventArgs e)
        {
            Form Conversion = new Conversion();
            Conversion.ShowDialog();
            this.Hide();
        }

        private void timeSwitch(object sender, EventArgs e)
        {
            Form Time = new Time();
            Time.ShowDialog();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
