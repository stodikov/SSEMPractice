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
        Dictionary<string, List<string[]>> setsForResult = new Dictionary<string, List<string[]>>();
        Dictionary<string, string[][]> solution = new Dictionary<string, string[][]>();
        string argumentsConditions = "";

        public Dictionary<string, string[][]> GetSolution(int rang, string[] equation, string coefficients, string unknowns, string[] conditionsInput = null)
        {
            string[] coefficientsArr = coefficients == "" ? new string[0] : coefficients.Split(',');
            string[] unknownsArr = unknowns.Split(',');

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

            SetsForResult(equation, coefficientsArr, unknownsArr);
            if (setsForResult.Keys.Count != 0) GetResultEquation(rang, unknownsArr);
            else solution.Add("no solution", new string[][] { new string[] { "no solution" } });

            return solution;
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

        /*
         * Неправильно формируются пары
         * */

        private void SetsForResult(string[] equation, string[] coefficientsArr, string[] unknownsArr)
        {
            int truthLimit = (int)Math.Pow(2, keysArguments.Count);
            int setsLimit = (int)Math.Pow(2, unknownsArr.Length); //? А если условий нет?
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
                    if (!(currentRes == "")) AddSets(currentRes.TrimEnd(',').Split(','), coefficientsArr, unknownsArr);
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

        private void AddSets(string[] currentRes, string[] coefficientsArr, string[] unknowsArr)
        {
            string key = "";
            if (argumentsConditions == "" && keysArguments.Count == unknowsArr.Length) key = "no conditions"; //1 Все неизвестные - no conditions (Если есть условие с неизвестными - они будут отражены в ответе)
            else if (argumentsConditions != "" && keysArguments.Count != unknowsArr.Length) key = BuildKeyOnCondition(currentRes[0]); //2 Есть коэфициенты и условия на них - ключ по условию на коэфициента
            else key = BuildKeyOnCoefficients(currentRes[0], coefficientsArr); //3 Есть коэфициенты, но нет условий - ключ по коэфициентам | Зачем?
            /*
             * У нас не может быть вектора, потому что под каждый вариант строится свой ключ. Зачем? Не знаю.
             * Скорее всего была логика, когда было несколько неизвестных (но никаких предпосылок в коде для данного предположения не нашел)
             * Нужно понять зачем 3 условие и ничего ли я не сломаю, когда опущу его
             */

            if (!setsForResult.ContainsKey(key)) setsForResult.Add(key, new List<string[]>());
            setsForResult[key].Add(BuildSet(currentRes, unknowsArr));
        }

        private string[] BuildSet(string[] currentRes, string[] unknowns)
        {
            string[] res = new string[currentRes.Length];
            for (int i = 0; i < currentRes.Length; i++)
            {
                foreach (string unknow in unknowns)
                {
                    res[i] += currentRes[i][keysArguments[unknow]];
                }
            }
            return res;
        }

        private string BuildKeyOnCondition(string elem)
        {
            string key = "";
            foreach (string argument in argumentsConditions.Split(','))
            {
                key += $"{argument}={elem[keysArguments[argument]]},";
            }
            return key.TrimEnd(',');
        }

        private string BuildKeyOnCoefficients(string elem, string[] coefficientsArr)
        {
            string key = "";
            foreach (string coefficient in coefficientsArr)
            {
                key += $"{coefficient}={elem[keysArguments[coefficient]]},";
            }
            return key.TrimEnd(',');
        }

        private void GetResultEquation(int rang, string[] unknowns)
        {
            foreach (string condition in setsForResult.Keys)
            {
                string[][] resultOnSet = GetResultOnSets(rang, setsForResult[condition], unknowns);
                solution.Add(condition, resultOnSet);
            }
        }

        private string[][] GetResultOnSets(int rang, List<string[]> sets, string[] unknowns)
        {
            //sets.Clear();
            //sets.Add(new string[] { "0111", "1000" });
            //sets.Add(new string[] { "0010", "0110", "0111" });
            //sets.Add(new string[] { "1111" });
            int countResSets = sets[0].Length, slice = 0, count = 0;
            string[][] result;

            if (sets.Count == 1)
            {
                result = new string[sets[0].Length][];
                for (int i = 0; i < result.Length; i++) result[i] = new string[unknowns.Length];
                for (int i = 0; i < sets[0].Length; i++)
                {
                    for (int u = 0; u < unknowns.Length; u++)
                    {
                        if (result[count][u] == null) result[count][u] = $"{unknowns[u]}=";
                        result[count][u] += sets[0][i][u];
                    }
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
                                    if (result[count][j] == null) result[count][j] = $"{unknowns[j]}="; //? Работает ли?
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
