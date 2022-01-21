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
    public partial class Form_Input : Form
    {
        helpers.parseMultioperations helpers = new helpers.parseMultioperations();
        Controller controller = new Controller();

        public Form_Input()
        {
            InitializeComponent();
        }

        private void Form_SolvingOfSystemEquationOfTheoryMultioperations_Load(object sender, EventArgs e)
        {

        }

        private void button_getResualtEquation_Click(object sender, EventArgs e)
        {
            string[] splitInput = textBox_Equation.Text.Replace("\r", "").Split('\n');
            string[] multioperationsInput = textBox_Multioperations.Text.Replace("\r", "").Split('\n');
            string[] constantsInput = textBox_constants.Text.Replace("\r", "").Split('\n');
            string[] unknowsInput = textBox_unknows.Text.Replace("\r", "").Split('\n');
            string[] conditionsInput = textBox_conditions.Text.Replace("\r", "").Split('\n');
            string equation = "", constants = "", unknows = "";
            Dictionary<string, Multioperation> multioperations = new Dictionary<string, Multioperation>();
            Dictionary<string, int[]> designationAndVector = new Dictionary<string, int[]>();

            foreach (string s in multioperationsInput)
            {
                string[] input = s.Split('=');
                int[] multioperation = new int[input[1].Length];
                for (int i = 0; i < input[1].Length; i++) multioperation[i] = input[1][i] - '0';
                designationAndVector.Add(input[0], multioperation);
            }

            foreach (string s in splitInput)
            {
                if (s.Contains('<')) equation = s;
                else
                {
                    string designation = s.Split('=')[0];
                    string designationMultioperation = s.Split('=')[1].Split('|')[0];
                    string[] arguments = s.Split('=')[1].Split('|')[1].Split(',');

                    if (designationAndVector.ContainsKey(designationMultioperation))
                    {
                        int[][] codeRepresentation = helpers.parseMOtoVectorsRang2(designationAndVector[designationMultioperation]);
                        Multioperation newMO = new Multioperation(designationMultioperation, codeRepresentation, arguments, null);
                        multioperations.Add(designation, newMO);
                    }
                }
            }
            
            foreach (string s in constantsInput)
            {
                string designation = s.Split('|')[0];
                string[] elements = s.Split('|')[1].Split(',');
                string[][] newEquation = new string[elements.Length][];
                for (int i = 0; i < elements.Length; i++)
                {
                    newEquation[i] = new string[] { elements[i] };
                    constants += elements[i];
                }
                multioperations.Add(designation, new Multioperation(designation, null, null, newEquation));
            }

            foreach (string s in unknowsInput)
            {
                string designation = s.Split('|')[0];
                string[] elements = s.Split('|')[1].Split(',');
                string[][] newEquation = new string[elements.Length][];
                for (int i = 0; i < elements.Length; i++)
                {
                    newEquation[i] = new string[] { elements[i] };
                    unknows += elements[i];
                }
                multioperations.Add(designation, new Multioperation(designation, null, null, newEquation));
            }

            Dictionary<string, string[][]> resultEquation = controller.start(multioperations, conditionsInput, equation, constants, unknows);

            foreach (KeyValuePair<string, string[][]> kvpRes in resultEquation)
            {
                string condition = kvpRes.Key;
                string[][] resValue = kvpRes.Value;
                textBox_resualEquation.Text += condition + "\r\n";
                for (int i = 0; i < resValue.Length; i++)
                {
                    for (int j = 0; j < unknows.Length; j++)
                    {
                        textBox_resualEquation.Text += unknows[j] + " = " + resValue[i][j] + "\r\n";
                    }
                    textBox_resualEquation.Text += "\r\n";
                }
            }


            //foreach (KeyValuePair<string, Multioperation> kvp in multioperations)
            //{
            //    textBox_resualEquation.Text += kvp.Key + "\r\n";
            //}
            //Dictionary<string,Multioperation>

            /*Разбиение строки по мультиоперациям через рекурсивную функцию.
             * g(h(z,c),s(c))<g(c,z)
               g(
               h(
               z,c) запомнили h(z,c)
               g(,s(
               c) запомнили s(c)
               g(,) запомнили g(h(z,c),s(c))

               g(
               c,z) запомнили g(c,z)
               
               h(z,c) s(c) g(h(z,c),s(c))
             */

            /* 
             Или получение уравнения через кодировку
             g(h(z,c),s(c))<g(c,z)

             g1(h1,s1)<g2(c,z)
             g1=g(h1,s1)
             g2=g(c,z)
             h1=h(z,c)
             s1=s(c)
            */

            /* 
             Объект функция
               функция - g
               параметр1 - h
               параметр2 - s
               матричное представление - null


              функция - с
              параметр1 - null
              параметр2 - null
              матричное представление - есть

            через цикл заполнить все функции
             */
        }
    }
}
