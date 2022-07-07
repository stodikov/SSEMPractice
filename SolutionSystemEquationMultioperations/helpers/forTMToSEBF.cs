using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class forTMToSEBF
    {
        Dictionary<string, int> designations = new Dictionary<string, int>();
        ArrayList result = new ArrayList();
        int count = 0;
        string mainEquation = "";

        public ArrayList decompositionEquation(string equation, int indexEquation)
        {
            designations.Clear();
            result.Clear();
            count = 0;
            mainEquation = "";

            decomposition(equation, indexEquation);

            return result;
        }

        public string decomposition(string equation, int indexEquation)
        {
            string function = "", functionArguments = "", arguments = "", codeFunction = "";
            while (count < equation.Length)
            {
                switch(equation[count])
                {
                    case '(':
                        count++;
                        arguments = decomposition(equation, indexEquation);
                        if (designations.ContainsKey(function))
                        {
                            codeFunction = $"{function}_{Convert.ToString(designations[function])}_{indexEquation}";
                            designations[function] = designations[function] + 1;
                        }
                        else
                        {
                            designations.Add(function, 1);
                            codeFunction = $"{function}_0_{indexEquation}";
                        }
                        result.Add($"{codeFunction}={function}|{arguments}");
                        functionArguments = functionArguments.Substring(0, functionArguments.LastIndexOf(function)) + codeFunction;
                        function = "";
                        break;
                    case ')':
                        return functionArguments;
                    case '<':
                        function = "";
                        functionArguments = "";
                        if (result.Count != 0) mainEquation = result[result.Count - 1].ToString().Split('=')[0] + '<';
                        else mainEquation = equation.Substring(0, count) + '<';
                        break;
                    default:
                        if (equation[count] != ',') function += equation[count];
                        else function = "";
                        functionArguments += equation[count];
                        break;
                }
                count++;
            }
            if (function != "") mainEquation += function;
            else mainEquation += result[result.Count - 1].ToString().Split('=')[0];
            result.Add(mainEquation);
            return "";
        }

        public void getEquationPresent(int rang, Dictionary<string, Multioperation> multioperations, string key)
        {
            string[] coefficients = multioperations[key].coefficients;
            string[][] newEquationPresent = new string[multioperations[key].codeRepresentation.Length][];

            Array.Reverse(coefficients);
            foreach (string coefficient in coefficients)
            {
                if (newEquationPresent[0] == null) newEquationPresent = matrixMultiplication(rang, multioperations[coefficient].equationPresent, multioperations[key].codeRepresentation);
                else newEquationPresent = matrixMultiplication(rang, multioperations[coefficient].equationPresent, null, newEquationPresent);
            }
            multioperations[key].equationPresent = newEquationPresent;
        }

        private string[][] matrixMultiplication(int rang, string[][] equationPresent, int[][] codeRepresentation = null, string[][] newEquationPresent = null)
        {
            string[][] result = new string[rang][];
            if (codeRepresentation != null)
            {
                for (int i = 0; i < codeRepresentation.Length; i++)
                {
                    string[] partEquation = new string[codeRepresentation[0].Length / rang];
                    int countPartEquation = 0;
                    int countEquationPresent = 0;
                    for (int j = 0; j < codeRepresentation[i].Length; j+=rang)
                    {
                        string s = "";
                        for (int k = 0; k < rang; k++)
                        {
                            if (codeRepresentation[i][j + k] == 1)
                            {
                                if (equationPresent[k][countEquationPresent] == "1")
                                {
                                    s = "1";
                                    break;
                                } else if (equationPresent[k][countEquationPresent] == "0")
                                {
                                    if (s == "") s += "0";
                                }
                                else
                                {
                                    if (s == "") s += equationPresent[k][countEquationPresent];
                                    else s += "V" + equationPresent[k][countEquationPresent];
                                }
                            }
                        }
                        if (s == "") s = "0";
                        partEquation[countPartEquation] = s;
                        countPartEquation++;
                        countEquationPresent = (countEquationPresent + 1) % equationPresent[0].Length;
                    }
                    partEquation = deleteRepeatElementsAM(partEquation);
                    result[i] = partEquation;
                }
            }
            else
            {
                for (int i = 0; i < newEquationPresent.Length; i++)
                {
                    string[] partEquation = new string[newEquationPresent[0].Length / rang];
                    int countPartEquation = 0;
                    for (int j = 0; j < newEquationPresent[i].Length; j+=rang)
                    {
                        string s = "";
                        for (int k = 0; k < rang; k++)
                        {
                            if (newEquationPresent[i][j + k] == "0") continue;
                            if (newEquationPresent[i][j + k] == "1")
                            {
                                s += equationPresent[k][0] + "V";
                                continue;
                            }

                            if (equationPresent[k][0] == "0") continue;
                            if (equationPresent[k][0] == "1")
                            {
                                s += newEquationPresent[i][j + k] + "V";
                                continue;
                            }
                            
                            if (newEquationPresent[i][j + k].Contains('V') && !equationPresent[k][0].Contains('V'))
                            {
                                string[] split = newEquationPresent[i][j + k].Split('V');
                                foreach(string temp in split) s += $"{temp}&{equationPresent[k][0]}V";
                            }
                            else if (!newEquationPresent[i][j + k].Contains('V') && equationPresent[k][0].Contains('V'))
                            {
                                string[] split = equationPresent[k][0].Split('V');
                                foreach (string temp in split) s += $"{temp}&{newEquationPresent[i][j + k]}V";
                            }
                            else
                            {
                                string[] splitNewEquation = newEquationPresent[i][j + k].Split('V');
                                string[] splitEquation = equationPresent[k][0].Split('V');
                                foreach (string elemNewEquation in splitNewEquation)
                                    foreach (string elemEquation in splitEquation) s += $"{elemNewEquation}&{elemEquation}V";
                            }
                        }
                        s = s.TrimEnd('V');
                        if (s == "") s = "0";
                        s = reductionEquationAM(s);
                        partEquation[countPartEquation] = s;
                        countPartEquation++;
                    }
                    for (int j = 0; j < partEquation.Length; j++) partEquation[j] = reductionEquationAM(partEquation[j]);
                    result[i] = partEquation;
                }
            }
            return result;
        }

        public string reductionEquation(string equation)
        {
            equation = deleteRepeatElements(new string[] { equation })[0];
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
                    bool swapOnMin = false;
                    if (i != indexMin)
                    {
                        foreach (char elem in minElem)
                        {
                            if (splitEquation[i].Contains(elem)) swapOnMin = true;
                            else
                            {
                                swapOnMin = false;
                                break;
                            }
                        }
                        if (swapOnMin) splitEquation[i] = minElem;
                    }
                }
            }

            return deleteRepeatElements(new string[] { String.Join("V", splitEquation) })[0];
        }

        public string reductionEquationAM(string equation)
        {
            if (equation == "") return equation;
            equation = deleteRepeatElementsAM(new string[] { equation })[0];
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

            return deleteRepeatElementsAM(new string[] { String.Join("V", splitEquation) })[0];
        }

        public string[] deleteRepeatElements(string[] input)
        {
            string[] result = new string[input.Length];
            int count = 0;
            for (int s = 0; s < input.Length; s++)
            {
                string[] temp = input[s].Split('V');
                string resultTemp = "";
                for (int i = 0; i < temp.Length; i++) temp[i] = distinctWithNegative(temp[i]);
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
                                if (countEq == temp[j].Length) temp[j] = "-1";
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

        public string[] deleteRepeatElementsAM(string[] input)
        {
            string[] result = new string[input.Length];
            int count = 0;
            for (int s = 0; s < input.Length; s++)
            {
                string[] temp = input[s].Split('V');
                string resultTemp = "";
                for (int i = 0; i < temp.Length; i++) temp[i] = distinctWithNegative(temp[i]);
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
                                        if (s1 == s2) {
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

        public string distinctWithNegative(string input) //Функция на костыле
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
