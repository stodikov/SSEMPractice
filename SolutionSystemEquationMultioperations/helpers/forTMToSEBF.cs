using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class forTMToSEBF
    {
        public void getEquationPresent(Dictionary<string, Multioperation> multioperations, string key)
        {
            string[] arguments = multioperations[key].arguments;
            string[][] newEquationPresent = new string[multioperations[key].codeRepresentation.Length][];
            foreach (string argument in arguments)
            {
                if (newEquationPresent[0] == null) newEquationPresent = matrixMultiplication(multioperations[argument].equationPresent, multioperations[key].codeRepresentation);
                else newEquationPresent = matrixMultiplication(multioperations[argument].equationPresent, null, newEquationPresent);
            }
            multioperations[key].equationPresent = newEquationPresent;
        }

        private string[][] matrixMultiplication(string[][] equationPresent, int[][] codeRepresentation = null, string[][] newEquationPresent = null)
        {
            string[][] result = new string[2][];
            //Работает только для ранга 2
            if (codeRepresentation != null)
            {
                for (int i = 0; i < codeRepresentation.Length; i++)
                {
                    string[] partEquation = new string[codeRepresentation[0].Length / 2];
                    int countPartEquation = 0;
                    for (int j = 0; j < codeRepresentation[i].Length; j+=2)
                    {
                        string s = "";
                        if (codeRepresentation[i][j] == 1) s += equationPresent[0][0];
                        if (codeRepresentation[i][j + 1] == 1)
                        {
                            if (s != "") s += "V" + equationPresent[1][0];
                            else s += equationPresent[1][0];
                        }
                        if (s == "") s = "0";
                        partEquation[countPartEquation] = s;
                        countPartEquation++;
                    }
                    partEquation = deleteRepeatElements(partEquation);
                    result[i] = partEquation;
                }
            }
            else
            {
                for (int i = 0; i < newEquationPresent.Length; i++)
                {
                    string[] partEquation = new string[newEquationPresent[0].Length / 2];
                    int countPartEquation = 0;
                    for (int j = 0; j < newEquationPresent[i].Length; j+=2)
                    {
                        string s = "";
                        if (newEquationPresent[i][j] != "0")
                        {
                            if (newEquationPresent[i][j].Contains('V'))
                            {
                                string[] split = newEquationPresent[i][j].Split('V');
                                foreach (string temp in split) s += temp + equationPresent[0][0] + "V";
                                if (s[s.Length - 1] == 'V') s = s.Remove(s.Length - 1, 1);
                            }
                            else s += newEquationPresent[i][j] + equationPresent[0][0];
                        }
                        if (newEquationPresent[i][j + 1] != "0")
                        {
                            if (s != "") s += "V";
                            if (newEquationPresent[i][j + 1].Contains('V'))
                            {
                                string[] split = newEquationPresent[i][j + 1].Split('V');
                                foreach (string temp in split) s += temp + equationPresent[1][0] + "V";
                                if (s[s.Length - 1] == 'V') s = s.Remove(s.Length - 1, 1);
                            }
                            else s += newEquationPresent[i][j + 1] + equationPresent[1][0];
                        }
                        if (s == "") s = "0";
                        partEquation[countPartEquation] = s;
                        countPartEquation++;
                    }
                    partEquation = deleteRepeatElements(partEquation);
                    result[i] = partEquation;
                }
            }
            //Работает только для ранга 2
            return result;
        }

        private string[] deleteRepeatElements(string[] input)
        {
            string[] result = new string[input.Length];
            int count = 0;
            for (int s = 0; s < input.Length; s++)
            {
                string[] temp = input[s].Split('V');
                string resultTemp = "";
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = new string(temp[i].Distinct().ToArray());
                    //if (i != temp.Length - 1) resultTemp += temp[i] + "V";
                    //else resultTemp += temp[i];
                }
                result[s] = resultTemp;

                if (temp.Length >= 2)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        for (int j = 0; j < temp.Length; j++)
                        {
                            if (i != j && temp[i].Length == temp[j].Length && temp[i] != "-1" && temp[j] != "-1")
                            {
                                int countEq = 0;
                                for (int ti = 0; ti < temp[i].Length; ti++)
                                {
                                    for (int tj = 0; tj < temp[j].Length; tj++)
                                    {
                                        if (temp[i][ti] == temp[j][tj])
                                        {
                                            countEq++;
                                            break;
                                        }
                                    }
                                }
                                if (countEq == temp[j].Length)
                                {
                                    temp[j] = "-1";
                                }
                            }
                        }
                    }

                    for (int i = 0; i < temp.Length; i++) if (temp[i] != "-1") count++;
                    if (count > 0)
                    {
                        string[] conjunctions = new string[count];
                        string form = "";
                        count = 0;
                        for (int i = 0; i < temp.Length; i++)
                        {
                            if (temp[i] != "-1")
                            {
                                conjunctions[count] = temp[i];
                                count++;
                            }
                        }
                        for (int i = 0; i < count; i++)
                        {
                            if ((i + 1) == count) form += conjunctions[i];
                            else form += conjunctions[i] + "V";
                        }
                        result[s] = form;
                    }
                }
                else result[s] += temp[0];
            }

            //for (int s = 0; s < result.Length; s++)
            //{
            //    count = 0;
            //    string[] temp = result[s].Split('V');
            //    if (temp.Length > 2)
            //    {
            //        for (int i = 0; i < temp.Length; i++)
            //        {
            //            for (int j = 0; j < temp.Length; j++)
            //            {
            //                if (i != j && temp[i] == temp[j]) temp[j] = "-1";
            //            }
            //        }
            //        for (int i = 0; i < temp.Length; i++)
            //        {
            //            if (temp[i] != "-1") count++;
            //        }
            //        if (count > 0)
            //        {
            //            string[] conjunctions = new string[count];
            //            string form = "";
            //            count = 0;
            //            for (int i = 0; i < temp.Length; i++)
            //            {
            //                if (temp[i] != "-1")
            //                {
            //                    conjunctions[count] = temp[i];
            //                    count++;
            //                }
            //            }
            //            for (int i = 0; i < count; i++)
            //            {
            //                if ((i + 1) == count) form += conjunctions[i];
            //                else form += conjunctions[i] + "V";
            //            }
            //            result[s] = form;
            //        }
            //    }
            //}
            //проверка всего результирующего массива на одинаковые конъюнкции
            return result;
        }
    }
}
