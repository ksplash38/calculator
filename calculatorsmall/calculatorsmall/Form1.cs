using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorsmall
{
    public partial class Form1 : Form
    {
        bool blcheck;
        string strOperator;
        string strFNumber;
        decimal dcAnswer;
        
        public bool status;//It checks the status that what you want to append the string into the textbox or clear the textbox  
        public bool Dot;// it checks that only one Dot You can put inside the textbox  
        public double PreviousValue = 0.0;// by default previous value will be 0.0 and on performing any operation it will be change according to the textbox  
        public char Operation;//this checks which operation you want to perform like add, subtract, etc...  
        public bool FirstTime = true;
        double MemoryStore = 0;
        decimal EndResult = 0;
        public Form1()
        {
            this.InitializeComponent();
          //  TxtBox.IsReadOnly = true;// textbox will be ready only no one can write inside the textbox  
         //   TxtBox.Text = "0";// default value of the textbox 
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Button Operation = (Button)sender;


         //   string ButtonText = Operation.Text;


            textBox2.Text += Operation.Text;

            if (status == true)
            {
                textBox1.Text += Operation.Text;
             
            }
            else
            {
               // textBox1.Text += btnNumbers.Text;
                textBox1.Text = Operation.Text.ToString();
           
                status = true;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("."))
            {
                return;
            }
            textBox1.Text = textBox1.Text + ".";
            textBox1.ForeColor = Color.Red;
        }

        private void button18_Click(object sender, EventArgs e)
        { // for addition

            textBox2.Text = textBox2.Text + " + ";

            if (!FirstTime)
            {
                OpreationMethod();
                Operation = '+';
                status = false;
            }
            else
            {
          
                PreviousValue = double.Parse(textBox1.Text);
                Operation = '+';
                status = false;
                FirstTime = false;
            }
            textBox1.Text = "0";

        }

        private void button4_Click(object sender, EventArgs e)
        {// division

            /**   if (textBox1.Text.Contains("/"))
               {
                   return;
               }
               textBox2.Text = textBox1.Text + "/";
               Button btnOperators = (Button)sender;
               strOperator = btnOperators.Text;
               strFNumber = textBox1.Text;
               blcheck = true;  **/
            textBox2.Text = textBox2.Text + " / ";
            if (!FirstTime)
            {
      
                OpreationMethod();
                Operation = '/';
                status = false;
            }
            else
            {

                PreviousValue = double.Parse(textBox1.Text);
                Operation = '/';
                status = false;
                FirstTime = false;
            }
            textBox1.Text = "0";
        }


        private void button15_Click(object sender, EventArgs e)
        {
            // multiply

            /**   if (textBox1.Text.Contains("*"))
               {
                   return;
               }
               textBox2.Text = textBox1.Text + "*";
               Button btnOperators = (Button)sender;
               strOperator = btnOperators.Text;
               strFNumber = textBox1.Text;
               blcheck = true;

               **/
            textBox2.Text = textBox2.Text + " * ";
            if (!FirstTime)
            {
            
                OpreationMethod();
                Operation = '*';
                status = false;
            }
            else if (textBox1.Text != "")
            {
                PreviousValue = double.Parse(textBox1.Text);
                Operation = '*';
                status = false;
                FirstTime = false;
            }
            else
            {        
              
            }
            textBox1.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // subtract

            /**   if (textBox1.Text.Contains("-"))
               {
                   return;
               }
               textBox2.Text = textBox1.Text + "-";
               Button btnOperators = (Button)sender;
               strOperator = btnOperators.Text;
               strFNumber = textBox1.Text;
               blcheck = true;

               **/

            textBox2.Text = textBox2.Text + " - ";
            if (!FirstTime)
            {
  
                OpreationMethod();
                Operation = '-';
                status = false;
            }
            else
            {

                PreviousValue = double.Parse(textBox1.Text);
                Operation = '-';
                status = false;
                FirstTime = false;
            }
            textBox1.Text = "0";
        }

        private void xsquarebutton_Click(object sender, EventArgs e)
        {
            Operation = '2';
            OpreationMethod();
        }

        private void xcubebutton_Click(object sender, EventArgs e)
        {
            Operation = '3';
            OpreationMethod();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            // x^y
            if (!FirstTime)
            {
                OpreationMethod();
                Operation = '^';
                status = false;
            }
            else
            {
                PreviousValue = double.Parse(textBox1.Text);
                Operation = '^';
                status = false;
                FirstTime = false;
            }
            textBox1.Text = "0";
        }

        private void button7_Click(object sender, EventArgs e)
        { //  10^y

            Operation = 'y';
            OpreationMethod();

        }
        private void modebutton_Click(object sender, EventArgs e)
        { // mod

            textBox2.Text = textBox2.Text + " Mod ";
            if (!FirstTime)
            {

                OpreationMethod();
                Operation = 'm';
                status = false;
            }
            else
            {

                PreviousValue = double.Parse(textBox1.Text);
                Operation = 'm';
                status = false;
                FirstTime = false;
            }
            textBox1.Text = "0";
        }
     
        
        

        private void button19_Click(object sender, EventArgs e)
        {
            // !n
            Operation = 'f';
            OpreationMethod();
        }

        private void expbutton_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + " Exp ";
            if (!FirstTime)
            {

                OpreationMethod();
                Operation = 'E';
                status = false;
            }
            else
            {

                PreviousValue = double.Parse(textBox1.Text);
                Operation = 'E';
                status = false;
                FirstTime = false;
            }
            textBox1.Text = "0";

        }

        private void mplusbutton_Click(object sender, EventArgs e)
        {
            Button Operation = (Button)sender;
            string ButtonText = Operation.Text;
            // Memory add 
            if (ButtonText == "M+")
            {
                // Memory add 

                MemoryStore += double.Parse(textBox1.Text);
                memorytextbox.Text = MemoryStore.ToString();
                return;
            

            }

        }

        private void mminusbutton_Click(object sender, EventArgs e)
        {
            Button Operation = (Button)sender;
            string ButtonText = Operation.Text;
            // Memory add 
            if (ButtonText == "M-")
            {
                // Memory subtract

                MemoryStore -= double.Parse(textBox1.Text);
                memorytextbox.Text = MemoryStore.ToString();
                return;


            }

        }

        private void mcbutton_Click(object sender, EventArgs e)
        {
            Button Operation = (Button)sender;
            string ButtonText = Operation.Text;
            if (ButtonText == "MC")
            {
                //Memory Recall
                memorytextbox.Text = String.Empty;
                return;
            }

        }

        private void button14_Click(object sender, EventArgs e)
            //equals button
        {
            if (Operation != '\0')
            {
                OpreationMethod();
                textBox1.Text = PreviousValue.ToString();
                PreviousValue = 0.0;
            }
            status = false;
            FirstTime = true;
            Operation = '\0';

            /**      if (strOperator == ("+"))
                  { 
                      dcAnswer = Convert.ToDecimal(strFNumber) +
                                  Convert.ToDecimal(textBox1.Text);
                  textBox1.Text = Convert.ToString(dcAnswer);
                    //  textBox2.Text = Convert.ToString(dcAnswer);

                  }
                  else if
                  (strOperator == ("/"))
                  { 
                      dcAnswer = Convert.ToDecimal(strFNumber) /
                                  Convert.ToDecimal(textBox1.Text);
                  textBox1.Text = Convert.ToString(dcAnswer);
                  }

                  else if
                 (strOperator == ("*"))
                  {
                      dcAnswer = Convert.ToDecimal(strFNumber) *
                                  Convert.ToDecimal(textBox1.Text);
                      textBox1.Text = Convert.ToString(dcAnswer);
                  }

                  else if
             (strOperator == ("-"))
                  {
                      dcAnswer = Convert.ToDecimal(strFNumber) -
                                  Convert.ToDecimal(textBox1.Text);
                      textBox1.Text = Convert.ToString(dcAnswer);
                  }  **/
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            int length = textBox1.TextLength - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for
                (int i = 0; i < length; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }

        }

        private void OpreationMethod()
        {
            switch (Operation)
            {
                case '+':
                    {
                        History.Items.Add(PreviousValue + " + " + textBox1.Text + " = " + (PreviousValue + double.Parse(textBox1.Text)));
                        PreviousValue += double.Parse(textBox1.Text);
                        break;
                    }

                case '/':
                    {
                        History.Items.Add(PreviousValue + " / " + textBox1.Text + " = " + (PreviousValue / double.Parse(textBox1.Text)));
                        PreviousValue /= double.Parse(textBox1.Text);
                        break;
                    }

                case '*':
                    {
                        History.Items.Add(PreviousValue + " * " + textBox1.Text + " = " + (PreviousValue * double.Parse(textBox1.Text)));
                        PreviousValue *= double.Parse(textBox1.Text);
                        break;
                    }
                case '-':
                    {
                        History.Items.Add(PreviousValue + " - " + textBox1.Text + " = " + (PreviousValue - double.Parse(textBox1.Text)));
                        PreviousValue -= double.Parse(textBox1.Text);
                        break;
                    }
                case 'm':
                    {
                        History.Items.Add(PreviousValue + " Mod " + textBox1.Text + " = " + (PreviousValue % double.Parse(textBox1.Text)));
                        PreviousValue %= double.Parse(textBox1.Text);
                        break;
                    }

                case 'E':
                    {
                        double i = double.Parse(textBox1.Text);
                        double q;
                        q = (PreviousValue);
                        textBox1.Text = Math.Exp(i * Math.Log(q * 4)).ToString();

                        break;
                    }

                case 'f':
                    {

                        double Fact = 1;
                        for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
                        {
                            Fact = Fact * i;
                        }
                        History.Items.Add(textBox1.Text + "! = " + Fact);
                        PreviousValue = Fact;
                        textBox1.Text = PreviousValue.ToString();
                        status = false;
                        break;
                    }
                case '2':
                    {
                        double square = Math.Pow(double.Parse(textBox1.Text), 2);
                        History.Items.Add("square(" + textBox1.Text + ") = " + square);
                        PreviousValue = square;
                        textBox1.Text = PreviousValue.ToString();
                        status = false;
                        break;
                    }
                case '3':
                    {
                        double cube = Math.Pow(double.Parse(textBox1.Text), 3);
                        History.Items.Add("cube(" + textBox1.Text + ") = " + cube);
                        PreviousValue = cube;
                        textBox1.Text = PreviousValue.ToString();
                        status = false;
                        break;
                    }
                case '^':
                    {
                        double Pow = Math.Pow(PreviousValue, double.Parse(textBox1.Text));
                        History.Items.Add(PreviousValue + " ^ " + textBox1.Text + "=" + Pow);
                        PreviousValue = Pow;
                        break;
                    }
                case 'y':
                    {
                        double raise = Math.Pow(double.Parse(textBox1.Text), 10);
                        History.Items.Add("10(" + textBox1.Text + ") = " + raise);
                        PreviousValue = raise;
                        textBox1.Text = PreviousValue.ToString();
                        status = false;
                        break;
                    
             
                    }
            


                default:
                    {
                        break;
                    }

            }
        }


        private int factorial(int x)
        {
            int i = 1;
            for (int s = 1; s <= x; s++)
            {
                i = i * s;
            }
            return i;
        }

        private void historyclear_Click(object sender, EventArgs e)
        {
            History.Items.Clear();
        }

    

      

        private void clearallbutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            History.Items.Clear();
        }

     
    }
}
