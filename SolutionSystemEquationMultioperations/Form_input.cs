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
            Dictionary<string, Dictionary<string, string[][]>> result = Controller.Start(
                textBox_Rang.Text,
                textBox_Equation.Text.Trim(forTrim),
                textBox_Multioperations.Text.Trim(forTrim),
                textBox_coefficients.Text.Trim(forTrim),
                textBox_unknows.Text.Trim(forTrim),
                textBox_conditions.Text.Trim(forTrim));
            OutputResult(result);
        }

        private void OutputResult(Dictionary<string, Dictionary<string, string[][]>> result)
        {
            textBox_resualEquation.Text = "";
            if (result.ContainsKey("error"))
            {
                string[] errors = result["error"]["error"][0][0].Split('|');
                foreach (string error in errors) textBox_resualEquation.Text += $"{error}\r\n";
                return;
            }
            if (result.ContainsKey("no solution"))
            {
                textBox_resualEquation.Text += "Решения нет";
                return;
            }

            int rang = Convert.ToInt32(textBox_Rang.Text);

            foreach (KeyValuePair<string, Dictionary<string, string[][]>> kvpRes in result)
            {
                string condition = kvpRes.Key;
                Dictionary<string, string[][]> resCondition = kvpRes.Value;
                string answer = "";
                string[] answersUnknow = new string[] { "new" };

                if (condition != "no conditions") answer += $"При {condition}";
                answer = answer != "" ? answer.TrimEnd(new char[] { ' ', ',' }) + "\r\n" : "";
                foreach (KeyValuePair<string, string[][]> kvp in resCondition)
                {
                    string unknow = kvp.Key;
                    string[][] resValue = kvp.Value;
                    if (answersUnknow[0] == "new") answersUnknow = new string[resValue.Length];
                    //for (int i = 0; i < resValue.Length; i++)
                    //{
                    //    for (int r = 0; r < rang; r++)
                    //    {
                    //        answersUnknow[i] += $"{unknow}_{r} = {resValue[i][r]}   ";
                    //    }
                    //}

                    for (int i = 0; i < resValue.Length; i++)
                    {
                        for (int r = 0; r < rang; r++) answersUnknow[i] += $"{unknow}_{r} = {resValue[i][r]}\r\n";
                    }
                }
                foreach (string strAnswer in answersUnknow) answer += $"{strAnswer}\r\n";
                answer += "\r\n";
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
