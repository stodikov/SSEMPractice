using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.methods
{
    class AnalyticalMethod
    {
        helpers.forTMToSEBF TMT = new helpers.forTMToSEBF();
        helpers.GeneralFunctionsAnalyticalMethod gf = new helpers.GeneralFunctionsAnalyticalMethod();

        Dictionary<string, string> formulsUnknows = new Dictionary<string, string>();
        Dictionary<string, string> disclosedFormulsUnknows = new Dictionary<string, string>();

        Dictionary<string, string> formulsArbitraryBF = new Dictionary<string, string>();
        Dictionary<string, string> formulsArbitraryBFWithConditions = new Dictionary<string, string>();

        Dictionary<string, string[][]> resultsPairs = new Dictionary<string, string[][]>();
        string[] conditionsSolvavility;
        string fullEquation;
        char[] indexs = { 'S', 'T', 'D' };
        int countIndexs;
        string allIndexs;
        string conditionIndex;

        public Dictionary<string, string[][]> getSolution(string[][] equation, string constants, string unknows, string[] conditionsInput = null)
        {
            formulsUnknows.Clear();
            disclosedFormulsUnknows.Clear();
            formulsArbitraryBF.Clear();
            formulsArbitraryBFWithConditions.Clear();
            resultsPairs.Clear();
            conditionsSolvavility = null;
            countIndexs = 0;
            allIndexs = "";
            conditionIndex = "";

            if (!solvabilityTest(equation, unknows, conditionsInput)) return null;

            getFormulasUnknows(unknows);
            prepareArbitraryBF(constants);
            if (conditionsSolvavility == null) getResultWithoutConditions();
            else getResultWithConditions();

            return resultsPairs;
        }

        private bool solvabilityTest(string[][] equation, string unknows, string[] conditionInput)
        {
            string[] equationTemp = new string[equation.Length];
            string resultDerivative = "";
            fullEquation = "";

            for (int i = 0; i < equation.Length; i++) equationTemp[i] = equation[i][0]; //костыль!
            for (int i = 0; i < equationTemp.Length; i++)
            {
                string[] splitEquation = equationTemp[i].Split('<');
                string leftPartEquation = $"({translateFormul(splitEquation[0])})";
                string rightPartEquation = $"({gf.getMultiConjuction(gf.pseudoDeMorgan(translateFormul(splitEquation[1])))})";

                if (rightPartEquation == "()") continue;
                if (rightPartEquation == "(1)") fullEquation += leftPartEquation.Trim(new char[] { '(', ')' }) + 'V';
                else fullEquation += gf.getMultiConjuction($"{leftPartEquation}*{rightPartEquation}") + 'V';
            }
            fullEquation = fullEquation.TrimEnd('V');
            //тест
            //fullEquation = "x*yVa*bV-x*-y*-a*-b";
            //fullEquation = "x&yVa&bV-x&-y&-a&-b";
            //тест
            //fullEquation = translateFormul(fullEquation);
            if (conditionInput != null) fullEquation += 'V' + translateFormul(equationForConditions(conditionInput));
            fullEquation = String.Join("V", TMT.deleteRepeatElementsAM(new string[] { fullEquation }));
            resultDerivative = gf.getMultiConjuction(gf.getDerivativesGivesUnknows(fullEquation, unknows));
            if (resultDerivative == "1") return false;
            if (resultDerivative != "") conditionsSolvavility = TMT.deleteRepeatElementsAM(new string[] { resultDerivative });
            return true;
        }

        private string equationForConditions(string[] conditionsInput)
        {
            string equationConditions = "";
            foreach (string condition in conditionsInput)
            {
                string operatorCondition = condition.Split('|')[0];
                string[] arguments = condition.Split('|')[1].Split(',');
                switch (operatorCondition)
                {
                    case "!=":
                        equationConditions += $"{arguments[0]}{arguments[1]}V-{arguments[0]}-{arguments[1]}V";
                        break;
                }
            }
            return equationConditions.TrimEnd('V');
        }

        private string translateFormul(string formula)
        {
            string res = "";
            foreach (char c in formula)
            {
                if (c == '-') res += c;
                else if (c == 'V') res = res.TrimEnd('&') + c;
                else res += $"{c}&";
            }
            res = res.TrimEnd('&');
            return res;
        }
        
        private void getFormulasUnknows(string unknows)
        {
            unknows = new string(unknows.ToCharArray().Reverse().ToArray());
            string unknowsTemp = unknows, m = "", derivative0 = "", derivative1 = "";
            string equation_temp = fullEquation;

            for (int i = 0; i < unknows.Length; i++)
            {
                unknowsTemp = unknowsTemp.Replace(Convert.ToString(unknows[i]), "");
                if (unknowsTemp.Length > 0) m = gf.getMultiConjuction(gf.getDerivativesGivesUnknows(equation_temp, unknowsTemp));
                else m = equation_temp;

                derivative0 = gf.checkConditions(gf.getDerivative(m, Convert.ToString(unknows[i]), 0), false, conditionsSolvavility);
                derivative1 = gf.checkConditions(gf.getDerivative(m, Convert.ToString(unknows[i]), 1), true, conditionsSolvavility);

                if (derivative0 != "" && derivative1 != "") formulsUnknows.Add(Convert.ToString(unknows[i]), gf.getMultiConjuction($"A{i}*{derivative0}") + "V" + gf.getMultiConjuction($"(-A{i})*{gf.pseudoDeMorgan(derivative1)}"));
                if (derivative0 == "" && derivative1 != "") formulsUnknows.Add(Convert.ToString(unknows[i]), gf.getMultiConjuction($"(-A{i})*{gf.pseudoDeMorgan(derivative1)})"));
                if (derivative0 != "" && derivative1 == "") formulsUnknows.Add(Convert.ToString(unknows[i]), gf.getMultiConjuction($"A{i}*{derivative0}"));
                if (derivative0 == "" && derivative1 == "") formulsUnknows.Add(Convert.ToString(unknows[i]), "");

                if (formulsUnknows[Convert.ToString(unknows[i])] != "") formulsArbitraryBF.Add($"A{i}", "");

                equation_temp = gf.substitution(equation_temp, formulsUnknows);
            }
        }

        private void prepareArbitraryBF(string constants)
        {
            int binarySize = 2;
            if (constants.Length > 1) binarySize = (int)Math.Pow(2, constants.Length);
            string tempFormula = "";

            for (int i = 0; i < binarySize; i++)
            {
                string binary = Convert.ToString(i, 2);
                string temp = "";
                if (binary.Length < constants.Length)
                {
                    for (int r = constants.Length - binary.Length; r > 0; r--) temp += "0"; //?
                    binary = temp + binary;
                }

                for (int b = 0; b < binary.Length; b++)
                {
                    if (binary[b] == '0') tempFormula += $"-{constants[b]}&";
                    else tempFormula += $"{constants[b]}&";
                }
                tempFormula = tempFormula.TrimEnd('&') + 'V';
            }
            tempFormula = tempFormula.TrimEnd('V');
            
            foreach (KeyValuePair<string, string> kvp in formulsArbitraryBF.ToArray())
            {
                string formula = "";
                string[] split = tempFormula.Split('V');
                for (int i = 0; i < split.Length; i++)
                {
                    formula += $"{indexs[countIndexs]}{i}&{split[i]}V";
                    allIndexs += $"{indexs[countIndexs]}{i}&";
                }
                formula = formula.TrimEnd('V');
                formulsArbitraryBF[kvp.Key] = formula;
                countIndexs++;
            }
            allIndexs = allIndexs.TrimEnd('&');
        }

        private void getResultWithConditions()
        {
            //тест
            //conditionsSolvavility[0] = "a&b";
            //тест
            //string[] conditions = new string[1];
            string[] splitV = conditionsSolvavility[0].Split('V');
            string[][] splitCon = new string[splitV.Length][];
            Dictionary<string, Dictionary<string, int>> conditions = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < splitV.Length; i++) splitCon[i] = splitV[i].Split('&');
            conditions = gf.getConditions(splitCon, conditionsSolvavility[0]);
            foreach (KeyValuePair<string, Dictionary<string, int>> condition in conditions)
            {
                string unnecessaryIndexs = allIndexs;
                conditionIndex = allIndexs;
                string[] splitIndexs = allIndexs.Split('&');

                foreach (KeyValuePair<string, string> kvp in formulsArbitraryBF.ToArray())
                {
                    string formula = kvp.Value;
                    foreach (KeyValuePair<string, int> arguments in condition.Value) formula = gf.getDerivative(formula, arguments.Key, arguments.Value); 

                    if (!formulsArbitraryBFWithConditions.ContainsKey(kvp.Key))
                        formulsArbitraryBFWithConditions.Add(kvp.Key, formula);
                    else formulsArbitraryBFWithConditions[kvp.Key] = formula;
                }

                foreach (KeyValuePair<string, string> kvp in formulsUnknows.ToArray())
                {
                    string formula = kvp.Value;
                    foreach (KeyValuePair<string, int> arguments in condition.Value) formula = gf.getDerivative(formula, arguments.Key, arguments.Value);

                    formula = gf.substitution(formula, formulsArbitraryBFWithConditions);

                    if (!disclosedFormulsUnknows.ContainsKey(kvp.Key))
                        disclosedFormulsUnknows.Add(kvp.Key, formula);
                    else disclosedFormulsUnknows[kvp.Key] = formula;
                    foreach (string index in splitIndexs) if (formula.Contains(index)) unnecessaryIndexs = deleteIndex(unnecessaryIndexs, index);
                }

                splitIndexs = unnecessaryIndexs.Split('&');
                foreach (string index in splitIndexs) if (conditionIndex.Contains(index)) conditionIndex = deleteIndex(conditionIndex, index);
                conditionIndex = conditionIndex.TrimStart('&').TrimEnd('&');
                getResult(condition.Key);
            }
        }

        private string deleteIndex(string indexs, string index)
        {
            string res = "";
            string[] splitIndexs = indexs.Split('&');
            for (int i = 0; i < splitIndexs.Length; i++) {
                if (splitIndexs[i] != index) res += splitIndexs[i] + '&';
            }
            return res.TrimEnd('&');
        }
        
        private void getResultWithoutConditions()
        {
            conditionIndex = allIndexs;
            foreach (KeyValuePair<string, string> kvp in formulsUnknows.ToArray())
            {
                string formula = kvp.Value;
                formula = gf.substitution(formula, formulsArbitraryBF);

                if (!disclosedFormulsUnknows.ContainsKey(kvp.Key))
                    disclosedFormulsUnknows.Add(kvp.Key, formula);
                else disclosedFormulsUnknows[kvp.Key] = formula;
            }
            getResult();
        }

        private void getResult(string condition = "")
        {
            string binary = "", temp = "", globalRes = "";
            string[] splitIndexs = conditionIndex.Split('&'), splitRes;
            string[][] tempForPairs;
            int binarySize = (int)Math.Pow(2, splitIndexs.Length);
            for (int i = 0; i < binarySize; i++)
            {
                binary = Convert.ToString(i, 2);
                if (binary.Length < splitIndexs.Length)
                {
                    for (int r = splitIndexs.Length - binary.Length; r > 0; r--) temp += "0"; //?
                    binary = temp + binary;
                    temp = "";
                }

                string res = "";
                foreach (KeyValuePair<string, string> kvp in disclosedFormulsUnknows.ToArray())
                {
                    string formula = kvp.Value;
                    string[] splitV = formula.Split('V');
                    for (int j = 0; j < splitV.Length; j++)
                    {
                        if (splitV[j] == "") continue;
                        string[] splitCon = splitV[j].Split('&');
                        for (int e = 0; e < splitIndexs.Length; e++)
                        {
                            if (Array.Exists<string>(splitCon, con => con.TrimStart('-') == splitIndexs[e]))
                            {
                                int index = splitV[j].IndexOf(splitIndexs[e]);
                                if (index > 0 && splitV[j][index - 1] == '-' && binary[e] == '1' ||
                                    index > 0 && splitV[j][index - 1] != '-' && binary[e] == '0' ||
                                    index == 0 && binary[e] == '0')
                                {
                                    splitV[j] = "";
                                    break;
                                }
                                if (index > 0 && splitV[j][index - 1] == '-' && binary[e] == '0') splitV[j] = splitV[j].Replace($"-{splitIndexs[e]}", "1");
                                if (index > 0 && splitV[j][index - 1] != '-' && binary[e] == '1') splitV[j] = splitV[j].Replace($"{splitIndexs[e]}", "1");
                                if (index == 0 && binary[e] == '1') splitV[j] = splitV[j].Replace($"{splitIndexs[e]}", "1");
                            }
                        }
                    }

                    string tempglobal_res = "";
                    foreach (string elemV in splitV)
                    {
                        if (elemV == "") continue;
                        string templocal_res = "1";
                        string[] splitCon = elemV.Split('&');
                        foreach (string con in splitCon) if (con != "1") templocal_res += con;
                        if (templocal_res == "1")
                        {
                            tempglobal_res = "1";
                            break;
                        }
                        else tempglobal_res += $"{templocal_res.Replace("1", "")}V";
                    }

                    if (tempglobal_res == "") res = "0|" + res;
                    else
                    {
                        tempglobal_res = TMT.deleteRepeatElementsAM(new string[] { tempglobal_res })[0].TrimEnd('V');
                        res = $"{tempglobal_res}|" + res;
                    }
                }
                res = $"[{res.TrimEnd('|')}]";
                
                if (!globalRes.Contains(res)) globalRes += $"{res}/";
            }

            globalRes = globalRes.TrimEnd('/');
            splitRes = globalRes.Split('/').Distinct().ToArray();
            tempForPairs = new string[splitRes.Length][];
            for (int i = 0; i < splitRes.Length; i++)
            {
                splitRes[i] = splitRes[i].TrimStart('[').TrimEnd(']');
                string[] splitElem = splitRes[i].Split('|');
                tempForPairs[i] = splitElem;
            }
            resultsPairs.Add(condition, tempForPairs);
        }
    }
}
