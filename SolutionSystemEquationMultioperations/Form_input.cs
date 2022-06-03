using System;
using System.Collections.Generic;
using System.Collections;
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
        helpers.forTMToSEBF TMT = new helpers.forTMToSEBF();
        Controller controller = new Controller();

        public Form_Input()
        {
            InitializeComponent();
            //Form_Output formOutput = new Form_Output();
            //formOutput.Show();
        }

        private void Form_SolvingOfSystemEquationOfTheoryMultioperations_Load(object sender, EventArgs e)
        {

        }

        private void button_getResualtEquation_Click(object sender, EventArgs e)
        {
            char[] forTrim = new char[] { '\r', '\n', ' ' };
            string[] equationsInput = textBox_Equation.Text.Trim(forTrim).Replace("\r", "").Split('\n');
            string[] multioperationsInput = textBox_Multioperations.Text.Trim(forTrim).Replace("\r", "").Split('\n');
            string[] coefficientsInput = textBox_coefficients.Text.Trim(forTrim).Replace("\r", "").Split('\n');
            string[] unknownsInput = textBox_unknows.Text.Trim(forTrim).Replace("\r", "").Split('\n');
            string[] conditionsInput = textBox_conditions.Text.Trim(forTrim).Replace("\r", "").Split('\n');
            int rang = Convert.ToInt32(textBox_Rang.Text);
            string[] splitInput;
            string[] temp;
            string[] equations;
            string coefficients = "", unknowns = "", notConstants = "",
                method = radioButton_AM.Checked ? "analytical" : "numeric",
                formatAnswer = radioButton_FormatHorizontal.Checked ? "horizontal" : "vertical";
            Dictionary<string, Multioperation> multioperations = new Dictionary<string, Multioperation>();
            Dictionary<string, int[]> designationAndVector = new Dictionary<string, int[]>();

            foreach (string s in multioperationsInput)
            {
                string[] input = s.Split('=');

                if (rang < 4)
                {
                    int[] multioperation = new int[input[1].Length];
                    for (int i = 0; i < input[1].Length; i++) multioperation[i] = input[1][i] - '0';
                    designationAndVector.Add(input[0], multioperation);
                }
                else
                {
                    string[] elementsMO = input[1].Split(new char[] { ',', ' ' });
                    int[] multioperation = new int[elementsMO.Length];
                    for (int i = 0; i < elementsMO.Length; i++) multioperation[i] = Convert.ToInt32(elementsMO[i]);
                    designationAndVector.Add(input[0], multioperation);
                }
            }

            equations = new string[equationsInput.Length];
            for (int i = 0; i < equationsInput.Length; i++)
            {
                ArrayList list = TMT.decompositionEquation(equationsInput[i], i);
                splitInput = new string[list.Count];
                for (int j = 0; j < splitInput.Length; j++) splitInput[j] = list[j].ToString();

                foreach (string s in splitInput)
                {
                    if (s.Contains('<')) equations[i] = s;
                    else
                    {
                        string designation = s.Split('=')[0];
                        string designationMultioperation = s.Split('=')[1].Split('|')[0];
                        string[] arguments = s.Split('=')[1].Split('|')[1].Split(',');

                        if (designationAndVector.ContainsKey(designationMultioperation))
                        {
                            notConstants += designationMultioperation + ',';
                            int[][] codeRepresentation = helpers.parseMOtoVectors(designationAndVector[designationMultioperation], rang);
                            Multioperation newMO = new Multioperation(designationMultioperation, codeRepresentation, arguments, null);
                            multioperations.Add(designation, newMO);
                        }
                    }
                }
            }

            temp = notConstants.TrimEnd(',').Split(',').Distinct().ToArray();
            foreach (KeyValuePair<string, int[]> kvp in designationAndVector)
            {
                if (temp.Contains(kvp.Key)) continue;
                string[][] equationPresent = helpers.parseMOtoVectorsEquation(designationAndVector[kvp.Key], rang);
                Multioperation newMO = new Multioperation(kvp.Key, null, null, equationPresent);
                multioperations.Add(kvp.Key, newMO);

            }
            
            if (coefficientsInput[0] != "")
            {
                foreach (string s in coefficientsInput)
                {
                    string designation = s.Split('|')[0];
                    string[] elements = s.Split('|')[1].Split(',');
                    string[][] newEquation = new string[elements.Length][];
                    for (int i = 0; i < elements.Length; i++)
                    {
                        newEquation[i] = new string[] { elements[i] };
                        coefficients += elements[i];
                    }
                    multioperations.Add(designation, new Multioperation(designation, null, null, newEquation));
                }
            }

            foreach (string s in unknownsInput)
            {
                string designation = s.Split('|')[0];
                string[] elements = s.Split('|')[1].Split(',');
                string[][] newEquation = new string[elements.Length][];
                for (int i = 0; i < elements.Length; i++)
                {
                    newEquation[i] = new string[] { elements[i] };
                    unknowns += elements[i];
                }
                multioperations.Add(designation, new Multioperation(designation, null, null, newEquation));
            }

            Dictionary<string, string[][]> resultEquation = controller.start(rang, multioperations, conditionsInput, equations, coefficients, unknowns, method);

            textBox_resualEquation.Text = "";
            foreach (KeyValuePair<string, string[][]> kvpRes in resultEquation)
            {
                string condition = kvpRes.Key;
                string[][] resValue = kvpRes.Value;
                string answer = "";
                int midCondition = condition.Length / 2;

                if (condition == "no conditions" || condition == "") answer += "Условий нет";
                else
                {
                    answer += "При ";
                    for (int i = 0; i < midCondition; i++) answer += $"{condition[i]} = {condition[i + midCondition]}, ";
                }
                answer = answer.TrimEnd(new char[] { ' ', ',' }) + "\r\n";
                if (formatAnswer == "horizontal")
                {
                    for (int i = 0; i < unknowns.Length; i++)
                    {
                        for (int j = 0; j < resValue.Length; j++) answer += unknowns[i] + " = " + resValue[j][i] + "   ";
                        answer += "\r\n";
                    }
                    answer += "\r\n";
                }
                else
                {
                    for (int i = 0; i < resValue.Length; i++)
                    {
                        for (int j = 0; j < unknowns.Length; j++) answer += unknowns[j] + " = " + resValue[i][j] + "\r\n";
                        answer += "\r\n";
                    }
                }
                textBox_resualEquation.Text += answer;
            }
        }
    }
}
