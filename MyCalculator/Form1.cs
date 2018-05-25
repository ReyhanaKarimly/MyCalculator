using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace MyCalculator
{



    public partial class MyCalculator : Form
    {
        Stack Undo=new Stack();
        Stack Redo=new Stack();

        int count = 0;
        int to = 0;
        int from = 0;
        double value = 0;
        string var;
        string operation = "";
        bool operation_pressed = false;
        int encoding;
        public MyCalculator()
        {
            InitializeComponent();
        }

        //public make_visible(string value)
        //{
        //    if(value < 0)
        //}

        private void button_Click(object sender, EventArgs e)
        {
            if(result.Text=="0" || operation_pressed ==true)
            {
                result.Clear();
            }

            operation_pressed = false;
            Button b = (Button)sender;
            if(b.Text==".")
            {
                if(!result.Text.Contains("."))
                     result.Text = result.Text + b.Text;
            }
            else
            result.Text = result.Text + b.Text;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(value!=0)
            {
                
                if (b.Text=="sqrt")
                {
                    Undo.Push(double.Parse(result.Text));

                    Redo.Push(Math.Sqrt(double.Parse(result.Text)).ToString());

                    result.Text = Math.Sqrt(Double.Parse(result.Text)).ToString();
                    
                    value = Math.Sqrt(Double.Parse(result.Text));
                   
                }
                
              

                        equal.PerformClick();
                        operation_pressed = true;
                        operation = b.Text;
                        equation.Text = value + " " + operation;


                

            }
            else if (b.Text=="sqrt")
            {
                Undo.Push(double.Parse(result.Text));
                Redo.Push(Math.Sqrt(double.Parse(result.Text)).ToString());
                result.Text = Math.Sqrt(Double.Parse(result.Text)).ToString();
               // Undo.Push(Math.Pow(double.Parse(result.Text), 2));
               
                value = Math.Sqrt(Double.Parse(result.Text));

            }
            else if(b.Text=="convert")
            {
                var = result.Text;
                value = Double.Parse(result.Text);
                operation_pressed = true;
               // result.Text = "";

            }
     else if(b.Text=="from")
            {

              //  textBox1.Text = result.Text;
                value = double.Parse(result.Text);
                operation_pressed = true;
                result.Clear();

            }
            else if(value!=0 && b.Text=="to")
            {
               operation_pressed = true;
                 to = int.Parse(result.Text);
                 from = (int)value;
                result.Text = System.Convert.ToString(Convert.ToInt32(var, (int)value), int.Parse(result.Text));
                
                //Undo.Push(Double.Parse(System.Convert.ToString(Convert.ToInt32(result.Text, from), to)));

                //Redo.Push(System.Convert.ToString(Convert.ToInt32(result.Text, int.Parse(result.Text)), (int)value));
                //  value =double.Parse( System.Convert.ToString(Convert.ToInt32(var, int.Parse(textBox1.Text)), int.Parse(result.Text)));
                equal.PerformClick();
               
            }
            else {
            operation = b.Text;
            value = Double.Parse(result.Text);
            operation_pressed = true;
            equation.Text = value + " " + operation;
            }
            
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
           // operation_pressed = false;
            equation.Text = "";
          
            switch (operation)
            {
                case "+":
                    Undo.Push(value);
                    Redo.Push(double.Parse((value + Double.Parse(result.Text)).ToString()));
                    result.Text=(value + Double.Parse(result.Text)).ToString(); break;
                case "-":
                    Undo.Push(value);
                    Redo.Push(double.Parse((value - Double.Parse(result.Text)).ToString()));
                    result.Text = (value - Double.Parse(result.Text)).ToString(); break;
                case "/":
                    Undo.Push(value);
                    Redo.Push(double.Parse((value / Double.Parse(result.Text)).ToString()));


                    result.Text = (value / Double.Parse(result.Text)).ToString(); break;
                case "*":
                    Undo.Push(value);
                   Redo.Push(double.Parse((value * Double.Parse(result.Text)).ToString()));

                    result.Text = (value * Double.Parse(result.Text)).ToString(); break;
                case "to": result.Text = System.Convert.ToString(Convert.ToInt32(var, (int)value), int.Parse(result.Text));
                    Undo.Push(var);
                    Redo.Push(result.Text);
                    break;
                case "power": result.Text = (Math.Pow(value,Double.Parse(result.Text))).ToString(); break;
                default:
                    break;
            }
          
               
                

            
            value = double.Parse(result.Text);
            operation = "";
           // operation_pressed = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            equation.Text = "";
        }

      
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  MessageBox.Show(e.KeyChar.ToString());
            switch (e.KeyChar.ToString())
            {
                
                
                case "0": zero.PerformClick();break;
                case "1": one.PerformClick(); break;
                case "2": two.PerformClick(); break;
                case "3": three.PerformClick(); break;
                case "4": four.PerformClick(); break;
                case "5": five.PerformClick(); break;
                case "6": six.PerformClick(); break;
                case "7": seven.PerformClick(); break;
                case "8": eight.PerformClick(); break;
                case "9": nine.PerformClick(); break;
                case "/": div.PerformClick(); break;
                case "*": times.PerformClick(); break;
                case "-": sub.PerformClick(); break;
                case "+": add.PerformClick(); break;
                case "=": equal.PerformClick(); break;
                case "ENTER": equal.PerformClick(); break;


                default:
                    break;
            }

        }

        private void undo_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (Undo.Count != 0)
            {
                result.Text = Undo.Peek().ToString();
                Redo.Push(Undo.Peek());
                Undo.Pop();
            }
            else result.Text = "0";
        }

         private void redo_click(object sender, EventArgs e)
         {
            Button b = (Button)sender;
            count++;
            if (Redo.Count != 0)
            {
              
                result.Text = Redo.Peek().ToString();
                Undo.Push(Redo.Peek());
                Redo.Pop();
                if(count==8)
                {

                    Redo.Clear();

                    count = 0;
                }
            }
           // else result.Text = "0";


        }
        private void convert_operator(object sender, EventArgs e)
        {
           

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void encoding_click(object sender, EventArgs e)
        {
              encoding = int.Parse(result.Text);
            value = double.Parse(result.Text);
                       result.Text = "";
        }

        private void to_click(object sender, EventArgs e)
        {

        }

      
    }
}
