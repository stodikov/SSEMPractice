using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class GeneralFunctionsBF
    {
        public string ReductionEquation(string equation)
        {
            if (equation == "") return equation;
            equation = DeleteRepeatElements(new string[] { equation })[0];
            string[] splitEquation = equation.Split('V');
            string indexsMin = "";
            int min = Int32.MaxValue, indexMin = 0, max = Int32.MinValue;

            while (min != max)
            {
                min = Int32.MaxValue;
                max = Int32.MinValue;
                for (int i = 0; i < splitEquation.Length; i++)
                {
                    if (splitEquation[i] != "" && splitEquation[i].Length <= min && !indexsMin.Contains($"[{i}]"))
                    {
                        min = splitEquation[i].Length;
                        indexMin = i;
                    }
                    if (splitEquation[i] != "" && splitEquation[i].Length > max) max = splitEquation[i].Length;
                }

                string minElem = splitEquation[indexMin];
                indexsMin += $"[{indexMin}]";
                for (int i = 0; i < splitEquation.Length; i++)
                {
                    if (i != indexMin)
                    {
                        string[] splitMinElem = minElem.Split('&');
                        string[] splitEquationOnConjunction = splitEquation[i].Split('&');
                        int count = 0;

                        foreach (string tempMin in splitMinElem)
                        {
                            foreach (string tempEq in splitEquationOnConjunction)
                            {
                                if (tempMin == tempEq)
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        if (count == splitMinElem.Length)
                        {
                            splitEquation[i] = minElem;
                        }
                    }
                }
            }

            return DeleteRepeatElements(new string[] { String.Join("V", splitEquation) })[0];
        }

        public string[] DeleteRepeatElements(string[] input)
        {
            string[] result = new string[input.Length];
            int count = 0;
            for (int s = 0; s < input.Length; s++)
            {
                string[] temp = input[s].Split('V');
                string resultTemp = "";
                for (int i = 0; i < temp.Length; i++) temp[i] = DistinctWithNegative(temp[i]);
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
                                string[] splitOne = temp[i].Split('&');
                                string[] splitTwo = temp[j].Split('&');
                                foreach (string s1 in splitOne)
                                {
                                    foreach (string s2 in splitTwo)
                                    {
                                        if (s1 == s2)
                                        {
                                            countEq++;
                                            break;
                                        }
                                    }
                                }
                                if (countEq == splitTwo.Length) temp[j] = "-1";
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

            //проверка всего результирующего массива на одинаковые конъюнкции
            return result;
        }

        public string DistinctWithNegative(string input) //Функция на костыле
        {
            string result = "";
            if (input.Contains('&'))
            {
                string[] split = input.Split('&');
                foreach (string str in split)
                    if (!result.Contains(str)) result += str + "&";
                result = result.TrimEnd('&');
            }
            else
            {
                bool neg = false;
                foreach (char e in input)
                {
                    if (!result.Contains(e) && e != '-' && !neg) result += e;
                    else if (!result.Contains(e) && e != '-' && neg)
                    {
                        result += $"-{e}";
                        neg = false;
                    }
                    else if (e == '-') neg = true;
                    else if (result.Contains(e))
                    {
                        int index = result.IndexOf(e);
                        if (index > 0 && result[index - 1] == '-' && !neg) return "";
                        if (index > 0 && result[index - 1] != '-' && neg) return "";
                        if (index == 0 && neg) return "";
                    }
                }
            }
            return result;
        }
    }
}
