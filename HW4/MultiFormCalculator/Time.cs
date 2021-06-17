using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiFormCalculator
{
    public partial class Time : Form
    {
        bool PM = true;
        bool HR = true;

        public Time()
        {
            InitializeComponent();
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
               case Keys.Escape:
                   e.Handled = true;
                   buttonClearAll.PerformClick();
                   break;
           }
       }

        private void Time_Load(object sender, EventArgs e)
        {
            comboBoxMode.SelectedIndex = 0;
            panelKeypad.Enabled = true;
            timePicker2.Hide();
            label3.Hide();
            txtBoxHrs.Enabled = true;
            txtBoxHrs.Show();
            txtBoxMins.Enabled = true;
            txtBoxMins.Show();

            txtBoxHrs.Text = "Hours";
            txtBoxHrs.SelectAll();
            txtBoxHrs.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxHrs.DeselectAll();

            txtBoxMins.Text = "Minutes";
            txtBoxMins.SelectAll();
            txtBoxMins.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxMins.DeselectAll();

            txtBoxResult.Text = "";
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mode = comboBoxMode.SelectedIndex; 

            switch(mode)
            {
                case 0:
                    panelKeypad.Enabled = true;
                    timePicker2.Hide();
                    label3.Hide();
                    txtBoxHrs.Enabled = true;
                    txtBoxHrs.Show();
                    txtBoxMins.Enabled = true;
                    txtBoxMins.Show();

                    txtBoxHrs.Text = "Hours";
                    txtBoxHrs.SelectAll();
                    txtBoxHrs.SelectionAlignment = HorizontalAlignment.Center;
                    txtBoxHrs.DeselectAll();

                    txtBoxMins.Text = "Minutes";
                    txtBoxMins.SelectAll();
                    txtBoxMins.SelectionAlignment = HorizontalAlignment.Center;
                    txtBoxMins.DeselectAll();

                    txtBoxResult.Text = "";
                    break;

                case 1:
                    panelKeypad.Enabled = true;
                    timePicker2.Hide();
                    label3.Hide();
                    txtBoxHrs.Enabled = true;
                    txtBoxHrs.Show();
                    txtBoxMins.Enabled = true;
                    txtBoxMins.Show();

                    txtBoxHrs.Text = "Hours";
                    txtBoxHrs.SelectAll();
                    txtBoxHrs.SelectionAlignment = HorizontalAlignment.Center;
                    txtBoxHrs.DeselectAll();

                    txtBoxMins.Text = "Minutes";
                    txtBoxMins.SelectAll();
                    txtBoxMins.SelectionAlignment = HorizontalAlignment.Center;
                    txtBoxMins.DeselectAll();

                    txtBoxResult.Text = "";
                    break;

                case 2:
                    panelKeypad.Enabled = false;
                    timePicker2.Show();
                    label3.Show();
                    txtBoxHrs.Enabled = false;
                    txtBoxHrs.Hide();
                    txtBoxMins.Enabled = false;
                    txtBoxMins.Hide();
                    break;
            }
        }

        private void buttonHrMin_Click(object sender, EventArgs e)
        {
            if (HR)
                HR = false;
            else
                HR = true;
        }

        private void numericButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int digit = Convert.ToInt32(btn.Text);
            string text;

            if (HR)
                text = txtBoxHrs.Text;
            else
                text = txtBoxMins.Text;

            if (text.Length < 17)
            {
                if (text == "")
                {
                    if (HR)
                    {
                        txtBoxHrs.Text = "Hours";
                        txtBoxHrs.SelectAll();
                        txtBoxHrs.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxHrs.DeselectAll();
                    }
                    else
                    {
                        txtBoxMins.Text = "Minutes";
                        txtBoxMins.SelectAll();
                        txtBoxMins.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxMins.DeselectAll();
                    }
                }

                else if (text == "Hours" || text == "Minutes")
                {
                    if (HR)
                    {
                        txtBoxHrs.Text = digit.ToString();
                        txtBoxHrs.SelectAll();
                        txtBoxHrs.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxHrs.DeselectAll();
                    }
                    else
                    {
                        txtBoxMins.Text = digit.ToString();
                        txtBoxMins.SelectAll();
                        txtBoxMins.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxMins.DeselectAll();
                    }
                }

                else
                {
                    if (HR)
                    {
                        txtBoxHrs.Text += digit.ToString();
                        txtBoxHrs.SelectAll();
                        txtBoxHrs.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxHrs.DeselectAll();
                    }
                    else
                    {
                        txtBoxMins.Text += digit.ToString();
                        txtBoxMins.SelectAll();
                        txtBoxMins.SelectionAlignment = HorizontalAlignment.Center;
                        txtBoxMins.DeselectAll();
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

        private void conversionSwitch(object sender, EventArgs e)
        {
            Form Conversion = new Conversion();
            Conversion.ShowDialog();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            txtBoxHrs.Text = "Hours";
            txtBoxHrs.SelectAll();
            txtBoxHrs.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxHrs.DeselectAll();

            txtBoxMins.Text = "Minutes";
            txtBoxMins.SelectAll();
            txtBoxMins.SelectionAlignment = HorizontalAlignment.Center;
            txtBoxMins.DeselectAll();

            txtBoxResult.Text = "";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int mode = comboBoxMode.SelectedIndex;

            switch(mode)
            {
                case 0:
                    int hrsT=0;
                    if (txtBoxHrs.Text != "Hours")
                        hrsT = Convert.ToInt32(txtBoxHrs.Text);

                    int minsT=0;
                    if (txtBoxMins.Text != "Minutes")
                        minsT = Convert.ToInt32(txtBoxMins.Text);

                    int hrs = Convert.ToInt32(timePicker1.Value.ToString("HH"));
                    int mins = Convert.ToInt32(timePicker2.Value.ToString("mm"));
                    int hrsR = 0;
                    int minsR = 0;
                    string result;

                    minsR = mins + minsT;

                    if(minsR >= 60)
                    {
                        hrsT += minsR / 60;
                        minsR = minsR % 60;
                    }

                    hrsR = hrs + hrsT;

                    if (hrsR > 24)
                        hrsR = hrsR % 24;
                    if (hrsR > 12)
                        hrsR = hrsR - 12;
                    else if (hrsR < 12)
                        PM = false;

                    if (PM)
                        result = hrsR.ToString() + ":" + minsR.ToString() + " PM";
                    else
                        result = hrsR.ToString() + ":" + minsR.ToString() + " AM";

                    if (!result.Contains('E'))
                    {
                        if (result.Length > 17)
                            result = result.Substring(0, 17);

                        txtBoxResult.Text = result;
                    }

                    break;

                case 1:
                    int hrsT1 = 0;
                    if(txtBoxHrs.Text != "Hours")
                        hrsT1 = Convert.ToInt32(txtBoxHrs.Text);

                    int minsT1 = 0;
                    if(txtBoxMins.Text != "Minutes")
                        minsT1 = Convert.ToInt32(txtBoxMins.Text);

                    int hrs1 = Convert.ToInt32(timePicker1.Value.ToString("HH"));
                    int mins1 = Convert.ToInt32(timePicker2.Value.ToString("mm"));
                    int hrsR1 = 0;
                    int minsR1 = 0;
                    string result1;

                    minsR1 = Math.Abs(mins1 + (60 - minsT1));

                    if(minsR1 >=60)
                    {
                        hrsT1 += minsR1 / 60;
                        minsR1 = minsR1 % 60;
                    }

                    hrsR1 = Math.Abs(hrs1 + (24 - hrsT1));

                    if (hrsR1 > 24)
                        hrsR1 = hrsR1 % 24;
                    if (hrsR1 > 12)
                        hrsR1 = hrsR1 - 12;
                    else if (hrsR1 < 12)
                        PM = false;

                    if (PM)
                        result1 = hrsR1.ToString() + ":" + minsR1.ToString() + " PM";
                    else
                        result1 = hrsR1.ToString() + ":" + minsR1.ToString() + " AM";

                    if (!result1.Contains('E'))
                    {
                        if (result1.Length > 17)
                            result1 = result1.Substring(0, 17);

                        txtBoxResult.Text = result1;
                    }

                    break;

                case 2:
                    int hrsT2 = Convert.ToInt32(timePicker2.Value.ToString("HH"));
                    int minsT2 = Convert.ToInt32(timePicker2.Value.ToString("mm"));
                    int hrs2 = Convert.ToInt32(timePicker1.Value.ToString("HH"));
                    int mins2 = Convert.ToInt32(timePicker1.Value.ToString("mm"));
                    int hrsR2 = 0;
                    int minsR2 = 0;
                    string result2;

                    minsR2 = Math.Abs(mins2 + (60 - minsT2));

                    if (minsR2 >= 60)
                    {
                        hrsT2 += minsR2 / 60;
                        minsR2 = minsR2 % 60;
                    }

                    hrsR1 = Math.Abs(hrs2 + (24 - hrsT2));

                    result2 = hrsR2.ToString() + " hours and " + minsR2.ToString() + " minutes";

                    if (!result2.Contains('E'))
                    {
                        if (result2.Length > 17)
                            result2 = result2.Substring(0, 17);

                        txtBoxResult.Text = result2;
                    }

                    break;
            }
        }
    }
}
