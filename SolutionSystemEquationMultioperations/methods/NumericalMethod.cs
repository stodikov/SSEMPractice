using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace SolutionSystemEquationMultioperations.methods
{
    class NumericalMethod
    {
        Dictionary<string, int> keysArguments = new Dictionary<string, int>();
        Dictionary<string, Dictionary<string, List<string[]>>> setsForResult = new Dictionary<string, Dictionary<string, List<string[]>>>();
        Dictionary<string, Dictionary<string, string[][]>> solution = new Dictionary<string, Dictionary<string, string[][]>>();
        string argumentsConditions = "";

        public Dictionary<string, Dictionary<string, string[][]>> GetSolution(int rang, string[] equation, string coefficients, string unknowns, string[] conditionsInput = null)
        {
            string[] coefficientsArr = coefficients == "" ? new string[0] : coefficients.Split(',');
            string[] unknownsArr = unknowns.Split(',');
            Dictionary<string, string[]> structuringUnknows = StructuringUnknowns(unknownsArr, rang);

            keysArguments.Clear();
            setsForResult.Clear();
            solution.Clear();
            argumentsConditions = "";

            string[] arguments = coefficientsArr.Concat(unknownsArr).ToArray();
            for (int i = 0; i < arguments.Length; i++) keysArguments.Add(arguments[i], i);

            if (conditionsInput != null) equation = AddConditionsToEquation(equation, conditionsInput);

            //Надо убрать переменные, которые являются искомыми
            string[] argumentsConditionsArr = argumentsConditions.Trim(',').Split(',');
            argumentsConditions = DeleteUnknowsFromArgumentCondition(argumentsConditionsArr, unknownsArr);

            SetsForResult(equation, unknownsArr, structuringUnknows, rang);
            if (setsForResult.Keys.Count != 0) GetResultEquation(rang, structuringUnknows);
            else solution.Add("no solution", new Dictionary<string, string[][]>());

            return solution;
        }

        private Dictionary<string, string[]> StructuringUnknowns(string[] unknownsArr, int rang)
        {
            Dictionary<string, string[]> structuringUnknows = new Dictionary<string, string[]>();
            foreach (string unknown in unknownsArr)
            {
                string key = unknown.Split('_')[0];
                int index = Convert.ToInt32(unknown.Split('_')[1]) - 1;
                if (!structuringUnknows.ContainsKey(key)) structuringUnknows.Add(key, new string[rang]);
                structuringUnknows[key][index] = unknown;
            }
            return structuringUnknows;
        }

        private string[] AddConditionsToEquation(string[] equation, string[] conditionsInput)
        {
            string[] temp = new string[equation.Length + conditionsInput.Length];
            int c = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < equation.Length) temp[i] = equation[i];
                else
                {
                    string t = EquationForConditions(conditionsInput[c]);
                    temp[i] = t;
                    c++;
                }
            }
            equation = temp;
            return equation;
        }

        private string DeleteUnknowsFromArgumentCondition(string[] arguments, string[] unknows)
        {
            string res = "";
            for (int i = 0; i < arguments.Length; i++)
            {
                for (int j = 0; j < unknows.Length; j++)
                {
                    if (arguments[i] == unknows[j]) arguments[i] = "";
                }
                if (arguments[i] != "") res += $"{arguments[i]},";
            }
            return res.Trim(',');
        }

        private string EquationForConditions(string condition)
        {
            string equationConditions = "";
            string operatorCondition = condition.Split('|')[0];
            string[] arguments = condition.Split('|')[1].Split(',');
            foreach (string argument in arguments)
            {
                if (!argumentsConditions.Contains(argument)) argumentsConditions += $"{argument},";
            }
            switch (operatorCondition)
            {
                case "!=":
                    equationConditions += $"{arguments[0]}&{arguments[1]}V-{arguments[0]}&-{arguments[1]}<0";
                    break;
            }
            return equationConditions;
        }

        private void SetsForResult(
            string[] equation,
            string[] unknownsArr,
            Dictionary<string, string[]> structuringUnknowns,
            int rang)
        {
            int truthLimit = (int)Math.Pow(2, keysArguments.Count);
            int setsLimit = (int)Math.Pow(2, unknownsArr.Length);
            int currentSetLimit = 0;
            string currentRes = "";
            for (int i = 0; i < truthLimit; i++)
            {
                currentSetLimit++;
                //?
                string binarySet = Convert.ToString(i, 2);
                string temp = "";
                if (binarySet.Length < keysArguments.Count)
                {
                    for (int r = keysArguments.Count - binarySet.Length; r > 0; r--) temp += "0";
                    binarySet = temp + binarySet;
                }
                //?
                int resOnBinarySet = GetResultOnBinarySet(binarySet, equation);
                if (resOnBinarySet == 0) currentRes += $"{binarySet},";

                if (currentSetLimit == setsLimit)
                {
                    currentSetLimit = 0;
                    if (!(currentRes == "")) AddSets(currentRes.TrimEnd(',').Split(','), unknownsArr, structuringUnknowns, rang);
                    currentRes = "";
                }
            }
        }

        private int GetResultOnBinarySet(string binarySet, string[] equation)
        {
            int res = -1;
            int[] equationRes = new int[equation.Length];
            for (int i = 0; i < equation.Length; i++)
            {
                string[] split = equation[i].Split('<');
                res = GetResultPart(binarySet, split[1].Split('V'));
                if (res == 1) continue;
                res = GetResultPart(binarySet, split[0].Split('V'));
                if (res == 1) equationRes[i] = 1;
            }
            foreach (int i in equationRes)
            {
                if (i == 1) return 1;
            }
            return 0;
        }

        private int GetResultPart(string binarySet, string[] disjunctions)
        {
            int res = 0;
            foreach (string disjunction in disjunctions)
            {
                if (disjunction.Length == 1 && (disjunction == "1" || disjunction == "0")) res = disjunction[0] - '0';
                else res = GetResultOnConjuction(binarySet, disjunction);

                if (res == 1) break;
            }
            return res;
        }

        private int GetResultOnConjuction(string binarySet, string disjunction)
        {
            int res = 1;
            bool neg = false;
            string[] conjunctions = disjunction.Split('&');
            foreach (string conjuction in conjunctions)
            {
                string elem = conjuction;
                if (elem[0] == '-')
                {
                    neg = true;
                    elem = conjuction.TrimStart('-');
                }
                if (neg)
                {
                    int t = binarySet[keysArguments[elem]] - '0';
                    t = (t == 0) ? 1 : 0;
                    res *= t;
                    neg = false;
                }
                else res *= binarySet[keysArguments[elem]] - '0';
                if (res == 0) break;
            }
            return res;
        }

        private void AddSets(string[] currentRes, string[] unknowsArr, Dictionary<string, string[]> structuringUnknowns, int rang)
        {
            string key = "";
            if (argumentsConditions == "") key = "no conditions";
            else key = BuildKey(currentRes[0]);

            if (!setsForResult.ContainsKey(key)) setsForResult.Add(key, new Dictionary<string, List<string[]>>());
            BuildSetsFromUnknowns(currentRes, structuringUnknowns, rang, setsForResult[key]);

        }

        private void BuildSetsFromUnknowns(
            string[] currentRes,
            Dictionary<string, string[]> structuringUnknowns,
            int rang,
            Dictionary<string, List<string[]>> sets
            )
        {
            foreach(KeyValuePair<string, string[]> kvp in structuringUnknowns)
            {
                string[] res = new string[currentRes.Length];
                string key = kvp.Key;
                for (int i = 0; i < currentRes.Length; i++)
                {
                    string[] unknows = kvp.Value;
                    foreach (string unknow in unknows)
                    {
                        res[i] += currentRes[i][keysArguments[unknow]];
                    }
                }
                if (!sets.ContainsKey(key)) sets.Add(key, new List<string[]>());
                sets[key].Add(res);
            }
        }

        private string BuildKey(string elem)
        {
            string key = "";
            foreach (string argument in argumentsConditions.Split(','))
            {
                key += $"{argument}={elem[keysArguments[argument]]},";
            }
            return key.TrimEnd(',');
        }

        private void GetResultEquation(int rang, Dictionary<string, string[]> structuringUnknows)
        {
            foreach (string condition in setsForResult.Keys)
            {
                Dictionary<string, string[][]> resultForCondition = new Dictionary<string, string[][]>();
                foreach (string unknown in setsForResult[condition].Keys)
                {
                    string[][] resultOnSet = GetResultOnSets(rang, setsForResult[condition][unknown], structuringUnknows[unknown]);
                    resultForCondition.Add(unknown, resultOnSet);

                }
                solution.Add(condition, resultForCondition);
            }
        }

        private string[][] GetResultOnSets(int rang, List<string[]> sets, string[] unknowns)
        {
            int countResSets = sets[0].Length, slice = 0, count = 0;
            string[][] result;

            if (sets.Count == 1)
            {
                result = new string[sets[0].Length][];
                for (int i = 0; i < result.Length; i++) result[i] = new string[unknowns.Length];
                for (int i = 0; i < sets[0].Length; i++)
                {
                    for (int r = 0; r < rang; r++) result[count][r] += sets[0][i][r];
                    count++;
                }
            }
            else
            {
                for (int i = 1; i < sets.Count; i++) countResSets *= sets[i].Length;
                result = new string[countResSets][];
                for (int i = 0; i < result.Length; i++) result[i] = new string[unknowns.Length];

                slice = countResSets;
                for (int k = 0; k < sets.Count; k++)
                {
                    slice = slice / sets[k].Length;
                    while (count != countResSets)
                    {
                        for (int p = 0; p < sets[k].Length; p++)
                        {
                            for (int i = 0; i < slice; i++)
                            {
                                for (int j = 0; j < unknowns.Length; j++)
                                {
                                    result[count][j] += sets[k][p][j];
                                }
                                count++;
                            }
                        }
                    }
                    count = 0;
                }
            }
            return result;
        }
    }
}
