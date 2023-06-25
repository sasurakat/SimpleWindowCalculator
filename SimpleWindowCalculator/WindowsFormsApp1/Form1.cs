using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double display = 0;
        string operationalSign = string.Empty;
        bool isOperationPerformed = false;
        private const string DefaultDisplayValue = "0";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void click(object sender, EventArgs e)
        {
            if (textbox_display.Text == DefaultDisplayValue || isOperationPerformed)
            {
                textbox_display.Clear(); 
                isOperationPerformed = false; 
            }

            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!textbox_display.Text.Contains("."))
                {
                    textbox_display.Text += button.Text;
                }
            }
            else
            {
                textbox_display.Text += button.Text;
            }
        }

        private void OperationBtn(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            operationalSign = button.Text;
            if (double.TryParse(textbox_display.Text, out display))
            {
                Currentdisply.Text = display + " " + operationalSign;
                isOperationPerformed = true;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }

        private void Currentdisplay(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textbox_display.Text = DefaultDisplayValue;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textbox_display.Text.Length > 0)
            {
                textbox_display.Text = textbox_display.Text.Substring(0, textbox_display.Text.Length - 1);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            switch (operationalSign)
            {
                case "+":
                    if (double.TryParse(textbox_display.Text, out double operand))
                    {
                        textbox_display.Text = (display + operand).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.");
                    }
                    break;
                case "-":
                    if (double.TryParse(textbox_display.Text, out operand))
                    {
                        textbox_display.Text = (display - operand).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.");
                    }
                    break;
                case "*":
                    if (double.TryParse(textbox_display.Text, out operand))
                    {
                        textbox_display.Text = (display * operand).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.");
                    }
                    break;
                case "/":
                    if (double.TryParse(textbox_display.Text, out operand))
                    {
                        if (operand != 0)
                        {
                            textbox_display.Text = (display / operand).ToString();
                        }
                        else
                        {
                            textbox_display.Text = DefaultDisplayValue; 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.");
                    }
                    break;
                case "%":
                    if (double.TryParse(textbox_display.Text, out operand))
                    {
                        textbox_display.Text = (display * (operand / 100)).ToString();
                    }
                    else
                    {
                        textbox_display.Text = DefaultDisplayValue;
                    }
                    break;
                default:
                    break;
            }

            if (double.TryParse(textbox_display.Text, out display))
            {
                Currentdisply.Text = "";
                isOperationPerformed = false;
            }
            else
            {
                textbox_display.Text = DefaultDisplayValue; 
            }
        }

    }
}
