using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolutionSystemEquationMultioperations
{
    public partial class Form_Output : Form
    {
        public Form_Output()
        {
            InitializeComponent();
        }

        //public void showResult(Dictionary<string, string[][]> resultEquation, string equation, string unknows)
        public void showResult()
        {
            InitializeComponent();
            textBox_equation.Text = "equation";

            //foreach (KeyValuePair<string, string[][]> kvpRes in resultEquation)
            //{
            //    string condition = kvpRes.Key;
            //    string[][] resValue = kvpRes.Value;
            //    textBox_resualEquation.Text += condition + "\r\n";
            //    for (int i = 0; i < resValue.Length; i++)
            //    {
            //        for (int j = 0; j < unknows.Length; j++)
            //        {
            //            textBox_resualEquation.Text += unknows[j] + " = " + resValue[i][j] + "\r\n";
            //        }
            //        textBox_resualEquation.Text += "\r\n";
            //    }
            //}
        }
    }
}
