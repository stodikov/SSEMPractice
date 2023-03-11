using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public Dictionary<string, string[][]> SolutionInMultioperations(Dictionary<string, string[][]> solutionBF, int rang)
        {
            if (solutionBF.ContainsKey("no solution")) return solutionBF;
            Dictionary<string, string[][]> solutionMO = new Dictionary<string, string[][]>();
            foreach (KeyValuePair<string, string[][]> kvp in solutionBF)
            {
                bool noConditions = solutionBF.ContainsKey("no conditions");
                string key = noConditions ? "no conditions" : BuildKeyMultioperation(kvp.Key, rang);
                string[][] result = BuildValueMultioperation(kvp.Value, rang);
                solutionMO.Add(key, result);
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
                key += $"{kvp.Key} = ";
                for (int i = 0; i < elems.Length; i++)
                    if (elems[i] != 0) logElem += (int)Math.Pow(2, i);
                key += $"{logElem},";
            }
            return key.TrimEnd(',');
        }

        private string[][] BuildValueMultioperation(string[][] resultBF, int rang)
        {
            string[][] newValue = new string[resultBF.Length][];
            for (int r = 0; r < resultBF.Length; r++)
            {
                Dictionary<string, int[]> multioperations = new Dictionary<string, int[]>();
                string answer = "";
                int countNewValue = 0;

                foreach (string elem in resultBF[r])
                {
                    string arg = elem.Split('_')[0];
                    int index = Convert.ToInt32(elem.Split('_')[1].Split('=')[0]) - 1;
                    int value = Convert.ToInt32(elem.Split('_')[1].Split('=')[1]);
                    if (!multioperations.ContainsKey(arg))
                        multioperations.Add(arg, new int[rang]);
                    multioperations[arg][index] = value;
                }

                newValue[r] = new string[multioperations.Count];
                foreach (KeyValuePair<string, int[]> kvp in multioperations)
                {
                    int logElem = 0;
                    int[] elems = kvp.Value;
                    answer = $"{kvp.Key} = ";
                    for (int i = 0; i < elems.Length; i++)
                    {
                        if (elems[i] != 0)
                        {
                            logElem += (int)Math.Pow(2, i);
                        }
                    }
                    answer += $"{logElem}";
                    newValue[r][countNewValue] = answer;
                    countNewValue++;
                }
            }
            return newValue;
        }
    }
}
