using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class Transition
    {
        public string[] GetSystemEquation(int rang, string[] equations, Dictionary<string, Multioperation> multioperations)
        {
            int rowSystem = 0;
            string[] systemEquation = new string[rang * equations.Length];
            foreach (string equation in equations)
            {
                string[] system = GetTransition(rang, multioperations, equation);
                for (int i = 0; i < system.Length; i++)
                {
                    systemEquation[rowSystem] = system[i];
                    rowSystem++;
                }
            }
            return systemEquation;
        }

        private string[] GetTransition(int rang, Dictionary<string, Multioperation> multioperations, string equation)
        {
            Redefinition(rang, multioperations);
            string[] equationSplit = equation.Split('<');
            string[][] equationLeftPart = multioperations[equationSplit[0]].equationPresent;
            string[][] equationRightPart = multioperations[equationSplit[1]].equationPresent;
            string[] result = new string[equationLeftPart.Length];

            for (int i = 0; i < equationLeftPart.Length; i++)
            {
                result[i] = equationLeftPart[i][0] + "<" + equationRightPart[i][0];
            }

            return result;
        }

        private void Redefinition(int rang, Dictionary<string, Multioperation> multioperations)
        {
            helpers.GeneralFunctionsTransition TMToSEBF = new helpers.GeneralFunctionsTransition();
            bool flag = true;
            while (flag)
            {
                int count = 0;
                foreach (KeyValuePair<string, Multioperation> kvp in multioperations)
                {
                    if (kvp.Value.equationPresent == null)
                    {
                        int countEquations = 0;
                        string[] coefficients = kvp.Value.coefficients;
                        foreach (string coefficient in coefficients)
                        {
                            if (multioperations[coefficient].equationPresent == null) break;
                            countEquations++;
                        }
                        if (countEquations == coefficients.Length)
                        {
                            TMToSEBF.GetEquationPresent(rang, multioperations, kvp.Key);
                            count++;
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count == multioperations.Count) flag = false;
            }
        }

        //1? Как быть если неизвестные состоят не из 0 и 1, а из векторов (z1 = 0011, z2 = 0101)
        //2? Использовать не словари и массивы string, а уже созданный класс multioperation.cs?
        //3? Проверка на no-conditions
        //4? Костыль - первый ключ идет unknowns

        public Dictionary<string, Dictionary<string, string[][]>> SolutionInMultioperations(Dictionary<string, Dictionary<string, string[][]>> solutionBF, int rang)
        {
            if (solutionBF.ContainsKey("no conditions") || solutionBF.ContainsKey("no solution")) return solutionBF;
            Dictionary<string, Dictionary<string, string[][]>> solutionMO = new Dictionary<string, Dictionary<string, string[][]>>();
            foreach (KeyValuePair<string, Dictionary<string, string[][]>> kvp in solutionBF)
            {
                string key = BuildKeyMultioperation(kvp.Key, rang);
                solutionMO.Add(key, kvp.Value);
            }
            return solutionMO;
        }

        private string BuildKeyMultioperation(string keyBF, int rang)
        {
            Dictionary<string, int[]> multioperations = new Dictionary<string, int[]>();
            string[] arguments = keyBF.Split(',');
            string key = "";
            foreach (string argument in arguments)
            {
                string arg = argument.Split('_')[0];
                int index = Convert.ToInt32(argument.Split('_')[1].Split('=')[0]) - 1;
                int value = Convert.ToInt32(argument.Split('_')[1].Split('=')[1]);
                if (!multioperations.ContainsKey(arg))
                    multioperations.Add(arg, new int[rang]);
                multioperations[arg][index] = value;
            }
            foreach (KeyValuePair<string, int[]> kvp in multioperations)
            {
                int logElem = 0;
                int[] elems = kvp.Value;
                key = $"{kvp.Key} = ";
                for (int i = 0; i < elems.Length; i++)
                {
                    if (elems[i] != 0)
                    {
                        logElem += (int)Math.Pow(rang, i);
                    }
                }
                key += $"{logElem},";
            }
            return key.TrimEnd(',');
        }
    }
}
