using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.methods
{
    class NumericalMethod
    {
        int[][] thurthTable;
        Dictionary<string, int> keysArguments = new Dictionary<string, int>();
        Dictionary<string, int[]> conditions = new Dictionary<string, int[]>();
        Dictionary<string, string[][]> resultsPairs = new Dictionary<string, string[][]>();

        public Dictionary<string, string[][]> getSolution(int rang, string[][] equation, string coefficients, string unknowns, string[] conditionsInput = null)
        {
            string[][] pairs;
            string[][] res = null;
            string[] coefficientsArr = coefficients == "" ? new string[0] : coefficients.Split(',');
            string[] unknownsArr = unknowns.Split(',');

            keysArguments.Clear();
            conditions.Clear();
            resultsPairs.Clear();

            if (conditionsInput != null) equation = addConditionsToEquation(equation, conditionsInput);

            buildTruthTable(coefficientsArr.Length + unknownsArr.Length);
            getVectorBF(equation, $"{coefficients},{unknowns}".Trim(','));

            // Для быстрой отладки
            string vector = "";
            for (int i = 0; i < thurthTable.Length; i++) vector += thurthTable[i][thurthTable[i].Length - 1];
            // Для быстрой отладки

            if (!solvabilityTest(coefficientsArr, unknownsArr, conditionsInput)) return null;

            resultsPairs.Add("unknowns", new string[][] { unknownsArr });
            if (conditions.Count != 0)
            {
                foreach (KeyValuePair<string, int[]> kvpCondition in conditions)
                {
                    pairs = getPairsForResult(coefficientsArr, unknownsArr, kvpCondition);
                    res = getResultPairs(rang, pairs, unknownsArr);
                    resultsPairs.Add(kvpCondition.Key, res);
                }
            }
            else
            {
                pairs = getPairsForResult(coefficientsArr, unknownsArr);
                res = getResultPairs(rang, pairs, unknownsArr);
                resultsPairs.Add("no conditions", res);
            }
            return resultsPairs;
        }

        private string[][] addConditionsToEquation(string[][] equation, string[] conditionsInput)
        {
            string[][] temp = new string[equation.Length + conditionsInput.Length][];
            int c = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < equation.Length) temp[i] = equation[i];
                else
                {
                    string[] t = new string[1];
                    t[0] = equationForConditions(conditionsInput[c]);
                    temp[i] = t;
                    c++;
                }
            }
            equation = temp;
            return equation;
        }

        private string equationForConditions(string condition)
        {
            string equationConditions = "";
            string operatorCondition = condition.Split('|')[0];
            string[] arguments = condition.Split('|')[1].Split(',');
            switch (operatorCondition)
            {
                case "!=":
                    equationConditions += $"{arguments[0]}&{arguments[1]}V-{arguments[0]}&-{arguments[1]}<0";
                    break;
            }
            return equationConditions;
        }

        private void buildTruthTable(int countCoefficients)
        {
            int countCols = (int)Math.Pow(2, countCoefficients), countSwitch = (int)Math.Pow(2, countCoefficients) / 2, count = 0, value = 0;
            thurthTable = new int[countCols][];
            for (int i = 0; i < thurthTable.Length; i++) thurthTable[i] = new int[countCoefficients + 1];
            for (int i = 0; i < thurthTable[i].Length - 1; i++)
            {
                for (int j = 0; j < countCols; j++)
                {
                    if (count == countSwitch)
                    {
                        if (value == 0) value = 1;
                        else value = 0;
                        count = 0;
                    }
                    thurthTable[j][i] = value;
                    count++;
                }
                countSwitch /= 2;
                count = 0;
                value = 0;
            }
        }

        private void getVectorBF(string[][] equation, string arguments)
        {
            int resValue = -1;
            string[] argumentsArr = arguments.Split(',');
            for (int i = 0; i < argumentsArr.Length; i++) keysArguments.Add(argumentsArr[i], i);
            for (int t = 0; t < thurthTable.Length; t++)
            {
                int[] tempRes = new int[equation.Length];
                for (int i = 0; i < equation.Length; i++)
                {
                    for (int j = 0; j < equation[i].Length; j++)
                    {
                        string[] split = equation[i][j].Split('<');

                        string[] splitRightPart = split[1].Split('V');
                        foreach (string e in splitRightPart)
                        {
                            if (e.Length == 1 && (e == "1" || e == "0")) resValue = e[0] - '0';
                            else resValue = getValueOnSet(e, t);
                            if (resValue == 1) break;
                        }
                        
                        if (resValue != 1)
                        {
                            string[] splitLeftPart = split[0].Split('V');
                            foreach (string e in splitLeftPart)
                            {
                                if (e.Length == 1 && (e == "1" || e == "0")) resValue = e[0] - '0';
                                else resValue = getValueOnSet(e, t);

                                if (resValue == 1)
                                {
                                    tempRes[i] = 1;
                                    break;

                                }
                            }
                        }
                    }
                }
                foreach (int j in tempRes)
                {
                    if (j == 1)
                    {
                        thurthTable[t][thurthTable[t].Length - 1] = 1;
                        break;
                    }
                }
            }
        }

        private int getValueOnSet(string equation, int set)
        {
            string[] equationArr = equation.Split('&');
            int res = 1;
            bool neg = false;
            foreach (string e in equationArr)
            {
                string elem = e;
                if (e[0] == '-')
                {
                    neg = true;
                    elem = e.TrimStart('-');
                }
                if (neg)
                {
                    int t = thurthTable[set][keysArguments[elem]];
                    t = (t == 0) ? 1 : 0;
                    res *= t;
                    neg = false;
                }
                else res *= thurthTable[set][keysArguments[e]];
                if (res == 0) break;
            }
            return res;
        }

        private bool solvabilityTest(string[] coefficients, string[] unknowns, string[] conditionInput = null)
        {
            if (coefficients.Length == 0) return true;
            int sizeCol = (int)Math.Pow(2, coefficients.Length), sizeRow = (int)Math.Pow(2, unknowns.Length),
                countResidual = 0, countCleaning = 0, res = 1;
            bool flag = false;
            int[][] residual = new int[sizeRow + 1][];
            for (int i = 0; i < residual.Length; i++) residual[i] = new int[sizeCol];
            string index = "";
            for (int set = 0; set < thurthTable.Length; set++)
            {
                foreach (string u in unknowns) index += Convert.ToString(thurthTable[set][keysArguments[u]]);
                residual[Convert.ToInt32(index, 2)][countResidual] = thurthTable[set][thurthTable[set].Length - 1];
                index = "";
                countCleaning++;
                if (countCleaning == sizeRow)
                {
                    countCleaning = 0;
                    countResidual++;
                }
            }
            for (int i = 0; i < sizeCol; i++)
            {
                for (int j = 0; j < sizeRow; j++)
                {
                    res *= residual[j][i];
                    if (res == 0) break;
                }
                residual[residual.Length - 1][i] = res;
                res = 1;
                countResidual++;
            }

            for (int i = 0; i < residual[residual.Length - 1].Length; i++)
            {
                if (residual[residual.Length - 1][i] == 0)
                {
                    string binarySet_string = "", temp = "";
                    int[] binarySet_int = new int[coefficients.Length];
                    binarySet_string = Convert.ToString(i, 2);
                    if (binarySet_string.Length < coefficients.Length)
                    {
                        for (int r = coefficients.Length - binarySet_string.Length; r > 0; r--) temp += "0"; //?
                        binarySet_string = temp + binarySet_string;
                    }
                    for (int j = 0; j < binarySet_string.Length; j++) binarySet_int[j] = binarySet_string[j] - '0';
                    binarySet_string = $"{String.Join(",", coefficients)}|{binarySet_string}";
                    conditions.Add(binarySet_string, binarySet_int);
                }
            }
            if (conditions.Count != 0) flag = true;
            if (conditions.Count == residual[residual.Length - 1].Length) conditions.Clear();
            return flag;
        }

        private string[][] getPairsForResult(string[] coefficients, string[] unknowns, KeyValuePair<string, int[]> kvpCondition = new KeyValuePair<string, int[]>())
        {
            int sizePairs = (int)Math.Pow(2, coefficients.Length), countPairs = 0, countCleaning = 0;
            string[][] pairs = new string[(int)Math.Pow(2, unknowns.Length)][];
            string temp = "", value = "";
            bool flag = true;

            for (int i = 0; i < thurthTable.Length; i++)
            {
                flag = true;
                if (thurthTable[i][thurthTable[i].Length - 1] == 0)
                {
                    if (kvpCondition.Key == null) flag = true;
                    else
                    {
                        string[] coefficientsCondition = kvpCondition.Key.Split('|')[0].Split(',');
                        for (int j = 0; j < coefficientsCondition.Length; j++) if (thurthTable[i][keysArguments[coefficientsCondition[j]]] != kvpCondition.Value[j]) flag = false;
                    }
                    if (flag)
                    {
                        foreach (string u in unknowns) temp += Convert.ToString(thurthTable[i][keysArguments[$"{u}"]]);
                        if (temp != "")
                        {
                            if (countCleaning != sizePairs)
                            {
                                if (value == "") value += temp;
                                else value += '|' + temp;
                            }
                            temp = "";
                        }
                    }
                }
                countCleaning++;
                if (countCleaning == sizePairs)
                {
                    pairs[countPairs] = value.Split('|');
                    value = "";
                    countCleaning = 0;
                    countPairs++;
                }
            }
            //?
            sizePairs = 0;
            countPairs = 0;
            for (int i = 0; i < pairs.Length; i++) if (pairs[i][0] != "") sizePairs++;
            string[][] res = new string[sizePairs][];
            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i][0] != "")
                {
                    string[] t = new string[pairs[i].Length];
                    for (int j = 0; j < pairs[i].Length; j++)
                    {
                        t[j] = pairs[i][j];
                    }
                    res[countPairs] = t;
                    countPairs++;
                }
            }
            return res;
        }

        private string[][] getResultPairs(int rang, string[][] pairs, string[] unknowns)
        {
            int countResPairs = pairs[0].Length, slice = 0, count = 0;
            string[][] resPairs;
            if (pairs.Length == 1)
            {
                resPairs = new string[pairs[0].Length][];
                for (int i = 0; i < resPairs.Length; i++) resPairs[i] = new string[unknowns.Length];
                for (int i = 0; i < pairs[0].Length; i++)
                {
                    for (int r = 0; r < rang; r++) resPairs[count][r] += pairs[0][i][r];
                    count++;
                }
            }
            else
            {
                for (int i = 1; i < pairs.Length; i++) countResPairs *= pairs[i].Length;
                resPairs = new string[countResPairs][];
                for (int i = 0; i < resPairs.Length; i++) resPairs[i] = new string[unknowns.Length];

                slice = countResPairs;
                for (int k = 0; k < pairs.Length; k++)
                {
                    slice = slice / pairs[k].Length;
                    while (count != countResPairs)
                    {
                        for (int p = 0; p < pairs[k].Length; p++)
                        {
                            for (int i = 0; i < slice; i++)
                            {
                                for (int j = 0; j < unknowns.Length; j++)
                                {
                                    resPairs[count][j] += pairs[k][p][j];
                                }
                                count++;
                            }
                        }
                    }
                    count = 0;
                }
            }
            return resPairs;
        }
    }
}
