using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class GeneralFunctionsAnalyticalMethod
    {
        GeneralFunctionsBF general = new GeneralFunctionsBF();

        public Dictionary<string, Dictionary<string, int>> getConditions(string[][] splitCon, string equation)
        {
            Dictionary<string, Dictionary<string, int>> conditions = new Dictionary<string, Dictionary<string, int>>();
            string binary = "", temp = "";
            string[] splitEquation;
            int binarySize = 2;
            string arguments = "";

            foreach (string[] conjunction in splitCon)
            {
                foreach (string argument in conjunction)
                {
                    foreach (char c in argument) if (c != '-' && !arguments.Contains(c)) arguments += c;
                }
            }
            
            if (splitCon.Length == 1)
            {
                foreach (char c in arguments)
                {
                    string key = $"{c}0";
                    Dictionary<string, int> condition = new Dictionary<string, int>();
                    condition.Add(c + "", 0);
                    conditions.Add(key, condition);
                }
            }
            else
            {
                if (arguments.Length > 1) binarySize = (int)Math.Pow(2, arguments.Length);
                for (int i = 0; i < binarySize; i++)
                {
                    binary = Convert.ToString(i, 2);
                    if (binary.Length < arguments.Length)
                    {
                        for (int r = arguments.Length - binary.Length; r > 0; r--) temp += "0"; //?
                        binary = temp + binary;
                        temp = "";
                    }

                    splitEquation = equation.Split('V');
                    bool flagEquation = true;
                    foreach (string conjuction in splitEquation)
                    {
                        bool flag = false;
                        for (int u = 0; u < arguments.Length; u++)
                        {
                            int index = conjuction.IndexOf(arguments[u]);
                            if (index > 0 && conjuction[index - 1] == '-' && binary[u] == '1' ||
                                index > 0 && conjuction[index - 1] != '-' && binary[u] == '0' ||
                                index == 0 && binary[u] == '0')
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag) flagEquation = false;
                    }
                    if (flagEquation)
                    {
                        string key = arguments + binary;
                        Dictionary<string, int> condition = new Dictionary<string, int>();
                        for (int j = 0; j < arguments.Length; j++) condition.Add(arguments[j] + "", binary[j] - '0');
                        conditions.Add(key, condition);
                    }
                }
            }
            return conditions;
        }

        public string getDerivativesGivesUnknows(string equation, string unknows)
        {
            string binary = "", temp = "", resultDerivative = "", resultTemp = "";
            string[] splitEquation;
            int binarySize = 2;
            if (unknows.Length > 1) binarySize = (int)Math.Pow(2, unknows.Length);
            for (int i = 0; i < binarySize; i++)
            {
                binary = Convert.ToString(i, 2);
                if (binary.Length < unknows.Length)
                {
                    for (int r = unknows.Length - binary.Length; r > 0; r--) temp += "0"; //?
                    binary = temp + binary;
                    temp = "";
                }

                splitEquation = equation.Split('V');
                foreach (string conjuction in splitEquation)
                {
                    bool flag = true;
                    for (int u = 0; u < unknows.Length; u++)
                    {
                        int index = conjuction.IndexOf(unknows[u]);
                        if (index > 0 && conjuction[index - 1] == '-' && binary[u] == '1' ||
                            index > 0 && conjuction[index - 1] != '-' && binary[u] == '0' ||
                            index == 0 && binary[u] == '0')
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        string conjuction_temp = conjuction, res_replace;
                        foreach (char s in unknows)
                        {
                            int index = conjuction_temp.IndexOf(s);
                            if (index > 0 && conjuction_temp[index - 1] == '-')
                            {
                                if ((conjuction_temp.Length - index) > 2 && conjuction_temp[index + 1] == '&')
                                    res_replace = conjuction_temp.Replace("-" + Convert.ToString(s) + "&", "");
                                else res_replace = conjuction_temp.Replace("-" + Convert.ToString(s), "");
                            }
                            else
                            {
                                if ((conjuction_temp.Length - index) > 1 && conjuction_temp[index + 1] == '&')
                                    res_replace = conjuction_temp.Replace(Convert.ToString(s) + "&", "");
                                else res_replace = conjuction_temp.Replace(Convert.ToString(s), "");
                            }

                            //if (res_replace.Contains('&') && (res_replace.Length == 2 || (res_replace.Length == 3 && res_replace.Contains('-')))) res_replace = res_replace.Replace("&", "");
                            //conjuction_temp = res_replace;
                            conjuction_temp = res_replace.TrimStart('&').TrimEnd('&');
                        }
                        if (resultTemp == "") resultTemp += conjuction_temp;
                        else resultTemp += $"V{conjuction_temp}";
                    }
                }
                if (resultTemp == "") return "";
                if (resultDerivative == "") resultDerivative += $"({resultTemp})";
                else resultDerivative += $"*({resultTemp})";
                resultTemp = "";
            }
            return resultDerivative;
        }

        public string getDerivative(string equation, string unknow, int value)
        {
            string resultDerivative = "";
            string[] splitEquation = equation.Split('V');
            foreach (string conjuction in splitEquation)
            {
                bool flag = true;
                if (conjuction.Contains(unknow))
                {
                    int index = conjuction.IndexOf(unknow);
                    if (index > 0 && conjuction[index - 1] == '-' && value == 1 ||
                        index > 0 && conjuction[index - 1] != '-' && value == 0 ||
                        index == 0 && value == 0) flag = false;
                }
                if (flag)
                {
                    string conjuction_temp = conjuction, res_replace;
                    int index = conjuction_temp.IndexOf(unknow);
                    if (index > 0 && conjuction_temp[index - 1] == '-')
                    {
                        if ((conjuction_temp.Length - index) > 2 && conjuction_temp[index + 1] == '&')
                            res_replace = conjuction_temp.Replace("-" + unknow + "&", "");
                        else res_replace = conjuction_temp.Replace("-" + unknow, "");
                    }
                    else
                    {
                        if ((conjuction_temp.Length - index) > 1 && conjuction_temp[index + 1] == '&')
                            res_replace = conjuction_temp.Replace(unknow + "&", "");
                        else res_replace = conjuction_temp.Replace(unknow, "");
                    }

                    conjuction_temp = res_replace.TrimStart('&').TrimEnd('&');

                    if (conjuction_temp != "")
                    {
                        if (resultDerivative == "") resultDerivative += conjuction_temp;
                        else resultDerivative += $"V{conjuction_temp}";
                    }
                }
            }
            resultDerivative = resultDerivative.TrimStart('(').TrimEnd(')');
            if (resultDerivative == "") resultDerivative = "0";
            return resultDerivative;
        }

        public string getMultiConjuction(string equation)
        {
            string[] splitEquation = equation.Split('*');
            if (splitEquation.Contains("(0)")) return "0";
            string res = "";
            for (int i = 0; i < splitEquation.Length; i++)
            {
                res = getConjuction(res, splitEquation[i].TrimStart('(').TrimEnd(')'));
                if (res.Contains('V')) res = String.Join("V", general.ReductionEquation(res));
            }
            return res;
        }

        public string getConjuction(string tempRes, string elem)
        {
            if (tempRes == "") return elem;
            if (elem == "") return tempRes;
            string[][] splitTempRes, splitElem;
            bool flag = true;
            string conjunction = "";
            string res = "";

            string[] split = tempRes.Split('V');
            splitTempRes = new string[split.Length][];
            for (int i = 0; i < split.Length; i++) splitTempRes[i] = split[i].Split('&');

            split = elem.Split('V');
            splitElem = new string[split.Length][];
            for (int i = 0; i < split.Length; i++) splitElem[i] = split[i].Split('&');

            for (int i = 0; i < splitTempRes.Length; i++)
            {
                for (int j = 0; j < splitElem.Length; j++)
                {
                    foreach (string str_temp in splitTempRes[i])
                    {
                        foreach (string str_elem in splitElem[j])
                        {
                            if ((str_temp.Contains(str_elem) || str_elem.Contains(str_temp))
                                && str_temp.Length != str_elem.Length)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (!flag) break;
                    }
                    if (flag)
                    {
                        foreach (string str_temp in splitTempRes[i])
                        {
                            if (conjunction == "") conjunction += str_temp;
                            else conjunction += '&' + str_temp;
                        }
                        foreach (string str_elem in splitElem[j])
                        {
                            if (!conjunction.Contains(str_elem)) conjunction += '&' + str_elem;
                        }
                        res += conjunction + 'V';
                        conjunction = "";
                    }
                    flag = true;
                }
            }

            if (res != "") res = res.TrimEnd('V');

            if (res.Contains('V'))
            {
                string[] splitRes = res.Split('V');
                res = "";
                foreach (string res1 in splitRes)
                {
                    if (res == "") res += general.DistinctWithNegative(res1);
                    else res += 'V' + general.DistinctWithNegative(res1);
                }
            }
            else res = general.DistinctWithNegative(res);

            if (res == "") res = "0";
            return res;
        }

        public string pseudoDeMorgan(string input)
        {
            if (input == "1") return "0";
            if (input == "0") return "1";
            string result = "";
            string[] split = input.Split('V');
            string[][] splitInput = new string[split.Length][];
            for (int i = 0; i < split.Length; i++) splitInput[i] = split[i].Split('&');

            for (int i = 0; i < splitInput.Length; i++)
            {
                if (result == "") result += '(';
                else result += "*(";

                foreach (string str in splitInput[i])
                {
                    if (str[0] == '-') result += str.Replace(Convert.ToString('-'), "") + "V";
                    else result += "-" + str + "V";
                }
                result = result.TrimEnd('V') + ')';
            }
            return result;
        }

        public string checkConditions(string input, bool neg, string[] conditionsSolvavility)
        {
            if (conditionsSolvavility == null) return input;
            string[] splitInput = new string[] { general.ReductionEquation(input) };
            splitInput = splitInput[0].Split('V');
            string result = "";
            int count = 0;
            string[] splitCondition = conditionsSolvavility[0].Split('V');
            int[] indexs = new int[splitCondition.Length];
            for (int i = 0; i < indexs.Length; i++) indexs[i] = -1;
            bool finded = true;

            int countIndex = 0;
            foreach (string elemCondition in splitCondition)
            {
                for (int i = 0; i < splitInput.Length; i++)
                {
                    string[] splitElemCondition = elemCondition.Split('&');
                    string[] splitElemInput = splitInput[i].Split('&');

                    foreach(string elem in splitElemCondition)
                    {
                        if (Array.Exists(splitElemInput, element => element == elem)) count++;
                    }

                    if (count == splitElemCondition.Length)
                    {
                        indexs[countIndex] = i;
                        countIndex++;
                        count = 0;
                        break;
                    }
                    count = 0;
                }
            }

            foreach (int index in indexs) if (index == -1) finded = false;
            if (finded) foreach (int index in indexs) splitInput[index] = "";
            foreach (string res in splitInput) if (res != "") result += res + 'V';
            result = result.TrimEnd('V');
            if (result == "" && neg) return "1";
            if (result == "" && !neg) return "";
            return result;
        }

        public string substitution(string input, Dictionary<string, string> arguments)
        {
            string[] split = input.Split('V');
            input = "";
            string str = "";

            foreach (string elem in split)
            {
                str = elem;
                foreach (string key in arguments.Keys)
                {
                    if (str.Contains(key))
                    {
                        int index = str.IndexOf(key);
                        if (index > 0 && str[index - 1] == '-')
                        {
                            if ((str.Length - index) > 2 && str[index + 1] == '&') str = str.Replace($"-{key}&", "");
                            else str = str.Replace($"-{key}", "");
                        }
                        else if (index > 0 && elem[index - 1] != '-' || index == 0)
                        {
                            if ((str.Length - index) > 1 && str[index + 1] == '&')
                                str = str.Replace($"{key}&", "");
                            else str = str.Replace($"{key}", "");
                        }

                        //if (str.Contains('&') && (str.Length == 2 || (str.Length == 3 && str.Contains('-')))) str = str.Replace("&", "");
                        str = str.TrimStart('&').TrimEnd('&');
                    }
                }
                str = $"({str})*";
                foreach (string key in arguments.Keys)
                {
                    if (elem.Contains(key))
                    {
                        int index = elem.IndexOf(key);
                        if (index > 0 && elem[index - 1] == '-') str += $"({general.ReductionEquation(getMultiConjuction(pseudoDeMorgan(arguments[key])))})*";
                        else if (index > 0 && elem[index - 1] != '-' || index == 0) str += $"({general.ReductionEquation(getMultiConjuction(arguments[key]))})*";
                    }
                }
                str = general.ReductionEquation(getMultiConjuction(str.TrimEnd('*')));
                if (str != "") input += str + 'V';
                str = "";
            }

            if (input != "")
            {
                input = general.ReductionEquation(input.TrimEnd('V'));
            }
            return input;
        }

        public string getTempResult(string equation, string unknows)
        {
            string binary = "", temp = "", resultDerivative = "", resultTemp = "";
            string[] splitEquation;
            int binarySize = 2;
            if (unknows.Length > 1) binarySize = (int)Math.Pow(unknows.Length, 2);
            for (int i = 0; i < binarySize; i++)
            {
                binary = Convert.ToString(i, 2);
                if (binary.Length < unknows.Length)
                {
                    for (int r = unknows.Length - binary.Length; r > 0; r--) temp += "0"; //?
                    binary = temp + binary;
                    temp = "";
                }

                splitEquation = equation.Split('V');
                foreach (string conjuction in splitEquation)
                {
                    bool flag = true;
                    for (int u = 0; u < unknows.Length; u++)
                    {
                        int index = conjuction.IndexOf(unknows[u]);
                        if (index > 0 && conjuction[index - 1] == '-' && binary[u] == '1' ||
                            index > 0 && conjuction[index - 1] != '-' && binary[u] == '0' ||
                            index == 0 && binary[u] == '0')
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        string conjuction_temp = conjuction, res_replace;
                        foreach (char s in unknows)
                        {
                            int index = conjuction_temp.IndexOf(s);
                            if (index > 0 && conjuction_temp[index - 1] == '-')
                            {
                                if ((conjuction_temp.Length - index) > 2 && conjuction_temp[index + 1] == '&')
                                    res_replace = conjuction_temp.Replace("-" + Convert.ToString(s) + "&", "");
                                else res_replace = conjuction_temp.Replace("-" + Convert.ToString(s), "");
                            }
                            else
                            {
                                if ((conjuction_temp.Length - index) > 1 && conjuction_temp[index + 1] == '&')
                                    res_replace = conjuction_temp.Replace(Convert.ToString(s) + "&", "");
                                else res_replace = conjuction_temp.Replace(Convert.ToString(s), "");
                            }

                            //if (res_replace.Contains('&') && (res_replace.Length == 2 || (res_replace.Length == 3 && res_replace.Contains('-')))) res_replace = res_replace.Replace("&", "");
                            //conjuction_temp = res_replace;
                            conjuction_temp = res_replace.TrimStart('&').TrimEnd('&');
                        }
                        if (resultTemp == "") resultTemp += conjuction_temp;
                        else resultTemp += $"V{conjuction_temp}";
                    }
                }
                if (resultTemp != "")
                {
                    if (resultDerivative == "") resultDerivative += $"({resultTemp})";
                    else resultDerivative += $"*({resultTemp})";
                    resultTemp = "";
                }
            }
            return resultDerivative;
        }
    }
}
