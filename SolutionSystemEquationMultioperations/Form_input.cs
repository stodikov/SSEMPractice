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
                textBox_resualEquation.Text += "Решений нет";
                return;
            }

            int rang = Convert.ToInt32(textBox_Rang.Text);

            foreach (KeyValuePair<string, string[][]> kvpRes in result)
            {
                string[] conditions = kvpRes.Key.Split(',');
                string[][] resValue = kvpRes.Value;
                string answer = "", condition = "";
                char[] trimElem = new char[] { ' ', ',' };
                int countUnknowns = textBox_unknows.Text.Split(',').Length;

                if (conditions[0] != "no conditions")
                {
                    foreach (string elem in conditions) condition += $"{elem}, ";
                    condition = condition.TrimEnd(trimElem);
                    answer += $"При {condition}";
                }
                answer = answer != "" ? answer.TrimEnd(trimElem) + "\r\n" : "";
                if (radioButton_horizontalFormat.Checked)
                {
                    for (int i = 0; i < countUnknowns; i++)
                    {
                        for (int j = 0; j < resValue.Length; j++)
                        {
                            answer += $"{resValue[j][i]}, ";
                        }
                        answer += "\r\n";
                    }
                    answer += "\r\n";
                }
                else
                {
                    for (int i = 0; i < resValue.Length; i++)
                    {
                        for (int j = 0; j < countUnknowns; j++) answer += $"{resValue[i][j]}\r\n";
                        answer += "\r\n";
                    }
                }
                textBox_resualEquation.Text += answer;
            }
        }

        private void Button_saveData_Click(object sender, EventArgs e)
        {
            string nameFile = textBox_nameFileSave.Text.Trim();
            if (!checkNameFile(nameFile, textBox_nameFileSave)) return;
            char[] forTrim = new char[] { '\r', '\n', ' ' };
            string saveData = $"Ранг\r\n{textBox_Rang.Text}\r\n" +
                              $"Уравнение\r\n{textBox_Equation.Text.Trim(forTrim)}\r\n" +
                              $"Мультиоперации\r\n{textBox_Multioperations.Text.Trim(forTrim)}\r\n" +
                              $"Коэффициенты\r\n{textBox_coefficients.Text.Trim(forTrim)}\r\n" +
                              $"Неизвестные\r\n{textBox_unknows.Text.Trim(forTrim)}\r\n" +
                              $"Условия\r\n{textBox_conditions.Text.Trim(forTrim)}\r\n" +
                              $"Результат\r\n{textBox_resualEquation.Text.Trim(forTrim)}";
            string curPath = Application.StartupPath;
            StreamWriter sw = new StreamWriter($@"{curPath}\{nameFile}.txt");
            sw.Write(saveData);
            sw.Close();
        }

        private void button_uploadData_Click(object sender, EventArgs e)
        {
            string nameFile = textBox_nameFileUpload.Text.Trim();
            if (!checkNameFile(nameFile, textBox_nameFileUpload)) return;
            string curPath = Application.StartupPath,
                   line = "";
            string[] points = new string[] { "ранг", "уравнение", "мультиоперации", "коэффициенты", "неизвестные", "условия", "результат" };
            int countPoints = 0;

            try
            {
                StreamReader sr = new StreamReader($@"{curPath}\{nameFile}.txt");
                clearForm();

                while ((line = sr.ReadLine()) != null)
                {
                    if (countPoints < points.Length && line.ToLower() == points[countPoints]) countPoints++;
                    else insertData(countPoints, line.Trim());
                }
            }
            catch
            {
                textBox_nameFileUpload.Text = "Файл не найден";
            }
        }

        private void clearForm()
        {
            textBox_Rang.Text = "";
            textBox_Equation.Text = "";
            textBox_Multioperations.Text = "";
            textBox_coefficients.Text = "";
            textBox_unknows.Text = "";
            textBox_conditions.Text = "";
            textBox_resualEquation.Text = "";
        }

        private void insertData(int countPoint, string line)
        {
            switch (countPoint)
            {
                case 1:
                    textBox_Rang.Text = line;
                    break;
                case 2:
                    textBox_Equation.Text += $"{line}\r\n";
                    break;
                case 3:
                    textBox_Multioperations.Text += $"{line}\r\n";
                    break;
                case 4:
                    textBox_coefficients.Text = line;
                    break;
                case 5:
                    textBox_unknows.Text = line;
                    break;
                case 6:
                    textBox_conditions.Text = $"{line}\r\n";
                    break;
                case 7:
                    textBox_resualEquation.Text += $"{line}\r\n";
                    break;
            }
        }

        private void button_longInstruction_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.Show();
        }

        private bool checkNameFile(string nameFile, TextBox textBox)
        {
            if (nameFile == "" || nameFile == "Не указано название файла")
            {
                textBox.Text = "Не указано название файла";
                return false;
            }
            else if (nameFile.Split(' ').Length > 1)
            {
                textBox.Text = "Пробелы в название файла";
                return false;
            }
            return true;
        }
    }
}
