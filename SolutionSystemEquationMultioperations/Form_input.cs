using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace SolutionSystemEquationMultioperations
{
    public partial class Form_Input : Form
    {
        Controller Controller = new Controller();

        public Form_Input()
        {
            InitializeComponent();
        }

        private void Form_SolvingOfSystemEquationOfTheoryMultioperations_Load(object sender, EventArgs e)
        {

        }

        private void Button_getResualtEquation_Click(object sender, EventArgs e)
        {
            char[] forTrim = new char[] { '\r', '\n', ' ' };
            textBox_resualEquation.Text = "Поиск решений...";
            Dictionary<string, string[][]> result = Controller.Start(
                textBox_Rang.Text,
                textBox_Equation.Text.Trim(forTrim),
                textBox_Multioperations.Text.Trim(forTrim),
                textBox_coefficients.Text.Trim(forTrim),
                textBox_unknows.Text.Trim(forTrim),
                textBox_conditions.Text.Trim(forTrim));
            OutputResult(result);
        }

        private void OutputResult(Dictionary<string, string[][]> result)
        {
            textBox_resualEquation.Text = "";
            if (result.ContainsKey("error"))
            {
                string[] errors = result["error"][0][0].Split('|');
                foreach (string error in errors) textBox_resualEquation.Text += $"{error}\r\n";
                return;
            }
            if (result.ContainsKey("no solution"))
            {
                textBox_resualEquation.Text += "Решения нет";
                return;
            }

            int rang = Convert.ToInt32(textBox_Rang.Text);

            foreach (KeyValuePair<string, string[][]> kvpRes in result)
            {
                string condition = kvpRes.Key;
                string[][] resValue = kvpRes.Value;
                string answer = "";
                //Формирование неизвестных
                string[] unknowns = textBox_unknows.Text.Split(',');
                string[] unknownsArr = new string[unknowns.Length * rang];
                int lenUnknownsArr = 0;
                foreach (string unknow in unknowns)
                {
                    for (int i = 0; i < rang; i++)
                    {
                        unknownsArr[lenUnknownsArr] = $"{unknow}_{i + 1}";
                        lenUnknownsArr++;
                    }
                }
                //Формирование неизвестных

                if (condition != "no conditions") answer += $"При {condition}";
                answer = answer != "" ? answer.TrimEnd(new char[] { ' ', ',' }) + "\r\n" : "";
                for (int i = 0; i < unknownsArr.Length; i++)
                {
                    for (int j = 0; j < resValue.Length; j++)
                    {
                        answer += $"{unknownsArr[i]} = {resValue[j][i]}   ";
                    }
                    answer += "\r\n";
                }
                answer += "\r\n";
                //for (int i = 0; i < resValue.Length; i++)
                //{
                //    for (int j = 0; j < unknownsArr.Length; j++) answer += $"{unknownsArr[j]} = {resValue[i][j]}\r\n";
                //    answer += "\r\n";
                //}
                textBox_resualEquation.Text += answer;
            }
        }

        private void Button_saveData_Click(object sender, EventArgs e)
        {
            char[] forTrim = new char[] { '\r', '\n', ' ' };
            string saveData = $"Ранг:\r\n{textBox_Rang.Text}\r\n" +
                              $"Уравнение:\r\n{textBox_Equation.Text.Trim(forTrim)}\r\n" +
                              $"Мультиоперации:\r\n{textBox_Multioperations.Text.Trim(forTrim)}\r\n" +
                              $"Коэффициенты:\r\n{textBox_coefficients.Text.Trim(forTrim)}\r\n" +
                              $"Неизвестные:\r\n{textBox_unknows.Text.Trim(forTrim)}\r\n" +
                              $"Условия:\r\n{textBox_conditions.Text.Trim(forTrim)}\r\n" +
                              $"Результат:\r\n{textBox_resualEquation.Text.Trim(forTrim)}";
            string curPath = Environment.CurrentDirectory;
            StreamWriter sw = new StreamWriter(@"C:\Users\NiceLiker\Desktop\SSIM\Data.txt");
            sw.Write(saveData);
            sw.Close();
        }
    }
}
