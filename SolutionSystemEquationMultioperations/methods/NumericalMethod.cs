using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.methods
{
    class NumericalMethod
    {
        int[][] thurthTable;
        Dictionary<char, int> keysArguments = new Dictionary<char, int>();
        Dictionary<string, int[]> conditions = new Dictionary<string, int[]>();
        Dictionary<string, string[][]> resultsPairs = new Dictionary<string, string[][]>();

        public Dictionary<string, string[][]> getSolution(int rang, string[][] equation, string constants, string unknows, string[] conditionsInput = null)
        {
            string[][] pairs;
            string[][] res = null;

            keysArguments.Clear();
            conditions.Clear();
            resultsPairs.Clear();

            if (conditionsInput != null) equation = addConditionsToEquation(equation, conditionsInput);

            buildTruthTable(constants.Length + unknows.Length);
            getVectorBF(equation, constants + unknows);

            // Для быстрой отладки
            //string vector = "";
            //for (int i = 0; i < thurthTable.Length; i++)
            //{
            //    vector += thurthTable[i][thurthTable[i].Length - 1];
            //}
            // Для быстрой отладки

            if (!solvabilityTest(constants, unknows, conditionsInput)) return null;

            if (conditions.Count != 0)
            {
                foreach (KeyValuePair<string, int[]> kvpCondition in conditions)
                {
                    pairs = getPairsForResult(constants, unknows, kvpCondition);
                    res = getResultPairs(rang, pairs, unknows);
                    resultsPairs.Add(kvpCondition.Key, res);
                }
            }
            else
            {
                pairs = getPairsForResult(constants, unknows);
                res = getResultPairs(rang, pairs, unknows);
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
                    equationConditions += $"{arguments[0]}{arguments[1]}V-{arguments[0]}-{arguments[1]}<0";
                    break;
            }
            return equationConditions;
        }

        private void buildTruthTable(int countAgruments)
        {
            int countCols = (int)Math.Pow(2, countAgruments), countSwitch = (int)Math.Pow(2, countAgruments) / 2, count = 0, value = 0;
            thurthTable = new int[countCols][];
            for (int i = 0; i < thurthTable.Length; i++) thurthTable[i] = new int[countAgruments + 1];
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
            for (int i = 0; i < arguments.Length; i++) keysArguments.Add(arguments[i], i);
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

                        //resValue = getValueOnSet(split[1], t);
                        if (resValue != 1)
                        {
                            string[] splitLeftPart = split[0].Split('V');
                            foreach (string e in splitLeftPart)
                            {
                                if (e.Length == 1 && (e == "1" || e == "0")) resValue = e[0] - '0';
                                else resValue = getValueOnSet(e, t);

                                if (resValue == 1)
                                {
                                    tempRes[j] = 1;
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
            int res = 1;
            bool neg = false;
            foreach (char e in equation)
            {
                if (e == '-')
                {
                    neg = true;
                    continue;
                }
                if (neg)
                {
                    int t = thurthTable[set][keysArguments[e]];
                    t = (t == 0) ? 1 : 0;
                    res *= t;
                    neg = false;
                }
                else res *= thurthTable[set][keysArguments[e]];
                if (res == 0) break;
            }
            return res;
        }

        private bool solvabilityTest(string constants, string unknows, string[] conditionInput = null)
        {
            int sizeCol = (int)Math.Pow(2, constants.Length), sizeRow = (int)Math.Pow(2, unknows.Length),
                countResidual = 0, countCleaning = 0, res = 1;
            bool flag = false;
            int[][] residual = new int[sizeRow + 1][];
            for (int i = 0; i < residual.Length; i++) residual[i] = new int[sizeCol];
            string index = "";
            for (int set = 0; set < thurthTable.Length; set++)
            {
                foreach (char u in unknows) index += Convert.ToString(thurthTable[set][keysArguments[u]]);
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
                //Если условие заданы отдельно
                //if (residual[residual.Length - 1][i] == 0) flag = true;
                //Если условие заданы отдельно

                //Если условие через систему уравнений
                if (residual[residual.Length - 1][i] == 0)
                {
                    string binarySet_string = "", temp = "";
                    int[] binarySet_int = new int[constants.Length];
                    binarySet_string = Convert.ToString(i, 2);
                    if (binarySet_string.Length < constants.Length)
                    {
                        for (int r = constants.Length - binarySet_string.Length; r > 0; r--) temp += "0"; //?
                        binarySet_string = temp + binarySet_string;
                    }
                    for (int j = 0; j < binarySet_string.Length; j++) binarySet_int[j] = binarySet_string[j] - '0';
                    binarySet_string = constants + binarySet_string;
                    conditions.Add(binarySet_string, binarySet_int);
                }
                //Если условие через систему уравнений
            }
            //Если условие через систему уравнений
            if (conditions.Count != 0) flag = true;
            if (conditions.Count == residual[residual.Length - 1].Length) conditions.Clear();
            //Если условие через систему уравнений

            //Если условие заданы отдельно
            //if (conditionInput != null)
            //{
            //    if (flag)
            //    {
            //        string binarySet_string = "", temp = "";
            //        for (int i = 0; i < residual[residual.Length - 1].Length; i++)
            //        {
            //            int[] binarySet_int = new int[constants.Length];
            //            binarySet_string = Convert.ToString(i, 2);
            //            if (binarySet_string.Length < constants.Length)
            //            {
            //                for (int r = constants.Length - binarySet_string.Length; r > 0; r--) temp += "0"; //?
            //                binarySet_string = temp + binarySet_string;
            //                temp = "";
            //            }
            //            for (int j = 0; j < binarySet_string.Length; j++)
            //            {
            //                binarySet_int[j] = binarySet_string[j] - '0';
            //                //temp += constants[j] + " = " + binarySet_string[j] + " ";
            //            }
            //            binarySet_string = constants + binarySet_string;
            //            conditions.Add(binarySet_string, binarySet_int);
            //        }

            //        Dictionary<string, int[]> cloneConditions = new Dictionary<string, int[]>();
            //        foreach (KeyValuePair<string, int[]> kvp_condition in conditions) cloneConditions.Add(kvp_condition.Key, kvp_condition.Value);

            //        for (int i = 0; i < conditionInput.Length; i++)
            //        {
            //            string operatorCondition = conditionInput[i].Split('|')[0];
            //            string arguments = conditionInput[i].Split('|')[1];
            //            foreach (char c in arguments) if (c != ',') temp += c;
            //            arguments = temp;
            //            temp = "";

            //            switch (operatorCondition)
            //            {
            //                case "!=":
            //                    foreach (KeyValuePair<string, int[]> kvp_condition in cloneConditions)
            //                    {
            //                        string key = kvp_condition.Key;
            //                        int[] value = kvp_condition.Value;
            //                        int firstValue = -1;
            //                        foreach (char c in arguments)
            //                        {
            //                            for (int j = 0; j < key.Length; j++)
            //                            {
            //                                if (c == key[j])
            //                                {
            //                                    if (firstValue == -1)
            //                                    {
            //                                        firstValue = value[j];
            //                                        break;
            //                                    }
            //                                    else if (firstValue == value[j])
            //                                    {
            //                                        conditions.Remove(kvp_condition.Key);
            //                                        break;
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                    break;
            //            }
            //        }
            //    }
            //}
            //Если условие заданы отдельно
            return flag;
        }

        private string[][] getPairsForResult(string constants, string unknows, KeyValuePair<string, int[]> kvpCondition = new KeyValuePair<string, int[]>())
        {
            int sizePairs = (int)Math.Pow(2, constants.Length), countPairs = 0, countCleaning = 0, sizeKey = 0; //? int sizePairs = (int)Math.Pow(2, constants.Length)
            string[][] pairs = new string[(int)Math.Pow(2, unknows.Length)][]; //? string[][] pairs = new string[sizePairs][];
            string temp = "", value = "";
            bool flag = true;

            if (kvpCondition.Key != null) sizeKey = kvpCondition.Key.Length / 2;

            for (int i = 0; i < thurthTable.Length; i++)
            {
                flag = true;
                if (thurthTable[i][thurthTable[i].Length - 1] == 0)
                {
                    if (kvpCondition.Key == null) flag = true;
                    else for (int j = 0; j < sizeKey; j++) if (thurthTable[i][keysArguments[kvpCondition.Key[j]]] != kvpCondition.Value[j]) flag = false;
                    if (flag)
                    {
                        foreach (char u in unknows) temp += Convert.ToString(thurthTable[i][keysArguments[u]]);
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

        private string[][] getResultPairs(int rang, string[][] pairs, string unknows)
        {
            int countResPairs = pairs[0].Length, slice = 0, count = 0;
            string[][] resPairs;
            if (pairs.Length == 1)
            {
                resPairs = new string[pairs[0].Length][];
                for (int i = 0; i < resPairs.Length; i++) resPairs[i] = new string[unknows.Length];
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
                for (int i = 0; i < resPairs.Length; i++) resPairs[i] = new string[unknows.Length];

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
                                for (int j = 0; j < unknows.Length; j++)
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
