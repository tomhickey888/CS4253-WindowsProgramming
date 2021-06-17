using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiFormCalculator
{
    public partial class Conversion : Form
    {
        private bool dec = false;

        public Conversion()
        {
            InitializeComponent();
        }

        private void Conversion_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.Escape:
                    e.Handled = true;
                    buttonClearAll.PerformClick();
                    break;
                case Keys.OemPeriod:
                    e.Handled = true;
                    buttonDec.PerformClick();
                    break;
                case Keys.Decimal:
                    e.Handled = true;
                    buttonDec.PerformClick();
                    break;
            }
        }

        private void numericButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int digit = Convert.ToInt32(btn.Text);
            string text = txtBoxTL.Text;

            if (text.Length < 17)
            {
                if (dec == false)
                {
                    if (text == "")
                    {
                        txtBoxTR.Text = "";
                        txtBoxTR.SelectAll();
                        txtBoxTR.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxTR.DeselectAll();

                        txtBoxTL.Text = "0";
                        txtBoxTL.SelectAll();
                        txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxTL.DeselectAll();

                        dec = false;
                    }

                    else if (text == "0")
                    {
                        if (digit != 0)
                        {
                            txtBoxTL.Text = digit.ToString();
                            txtBoxTL.SelectAll();
                            txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
                            txtBoxTL.DeselectAll();
                        }
                    }

                    else
                    {
                        txtBoxTL.Text += digit.ToString();
                        txtBoxTL.SelectAll();
                        txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxTL.DeselectAll();
                    }
                }
                else
                {
                    if (text == "0")
                    {
                        txtBoxTL.Text = "0.";
                        txtBoxTL.Text += digit.ToString();
                        txtBoxTL.SelectAll();
                        txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxTL.DeselectAll();
                    }

                    else if (text.Contains("."))
                    {
                        txtBoxTL.Text += digit.ToString();
                        txtBoxTL.SelectAll();
                        txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxTL.DeselectAll();
                    }

                    else
                    {
                        txtBoxTL.Text += "." + digit.ToString();
                        txtBoxTL.SelectAll();
                        txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxTL.DeselectAll();
                    }
                }
            }
        }
        
        private void standardSwitch(object sender, EventArgs e)
        {
            Form Standard = new Standard();
            Standard.ShowDialog();
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

        private void Conversion_Load(object sender, EventArgs e)
        {
            String num = "0";

            txtBoxTL.Text = num;
            txtBoxTL.SelectAll();
            txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxTL.DeselectAll();

            txtBoxTR.Text = num;
            txtBoxTR.SelectAll();
            txtBoxTR.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxTR.DeselectAll();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            txtBoxTL.Text = "0";
            txtBoxTL.SelectAll();
            txtBoxTL.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxTL.DeselectAll();

            txtBoxTR.Text = "0";
            txtBoxTR.SelectAll();
            txtBoxTR.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxTR.DeselectAll();

            dec = false;
        }

        private void buttonDecClick(object sender, EventArgs e)
        {
            if (!dec)
            {
                dec = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conv = comboBox1.SelectedItem.ToString();
            txtBoxBL.Text = conv;
            txtBoxBL.SelectAll();
            txtBoxBL.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxBL.DeselectAll();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conv = comboBox2.SelectedItem.ToString();
            txtBoxBR.Text = conv;
            txtBoxBR.SelectAll();
            txtBoxBR.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxBR.DeselectAll();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            string orig = txtBoxTL.Text;
            double o = Convert.ToDouble(orig);
            string oUnit = txtBoxBL.Text;
            string rUnit = txtBoxBR.Text;
            double r = 0;
            string result;

            switch(oUnit)
            {
                case "Inch":
                    switch (rUnit)
                    {
                        case "Inch":
                            r = o * 1;
                            break;

                        case "Foot":
                            r = o / 12;
                            break;

                        case "Yard":
                            r = o / 36;
                            break;

                        case "Mile":
                            r = o / 63360;
                            break;
                    }
                    break;

                case "Foot":
                    switch (rUnit)
                    {
                        case "Inch":
                            r = o * 12;
                            break;

                        case "Foot":
                            r = o * 1;
                            break;

                        case "Yard":
                            r = o / 3;
                            break;

                        case "Mile":
                            r = o / 5280;
                            break;
                    }
                    break;

                case "Yard":
                    switch (rUnit)
                    {
                        case "Inch":
                            r = o * 36;
                            break;

                        case "Foot":
                            r = o * 3;
                            break;

                        case "Yard":
                            r = o * 1;
                            break;

                        case "Mile":
                            r = o / 1760;
                            break;
                    }
                    break;

                case "Mile":
                    switch (rUnit)
                    {
                        case "Inch":
                            r = o * 63360;
                            break;

                        case "Foot":
                            r = o * 5280;
                            break;

                        case "Yard":
                            r = o * 1760;
                            break;

                        case "Mile":
                            r = o * 1;
                            break;
                    }
                    break;
            }
            

            result = r.ToString();

            if (!result.Contains('E'))
            {
                if (result.Length > 17)
                    result = result.Substring(0, 17);

                txtBoxTR.Text = result;
                txtBoxTR.SelectAll();
                txtBoxTR.SelectionAlignment = HorizontalAlignment.Center;
                txtBoxTR.DeselectAll();
            }
            
        }
    }
}
