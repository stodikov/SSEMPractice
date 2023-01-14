using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class Transition
    {
        public string[][] getSystemEquation(int rang, string[] equations, Dictionary<string, Multioperation> multioperations)
        {
            int rowSystem = 0;
            string[][] systemEquation = new string[rang * equations.Length][];
            foreach (string equation in equations)
            {
                string[][] system = getTransition(rang, multioperations, equation);
                for (int i = 0; i < system.Length; i++)
                {
                    systemEquation[rowSystem] = system[i];
                    rowSystem++;
                }
            }
            return systemEquation;
        }

        private string[][] getTransition(int rang, Dictionary<string, Multioperation> multioperations, string equation)
        {
            Redefinition(rang, multioperations);
            string[] equationSplit = equation.Split('<');
            string[][] equationLeftPart = multioperations[equationSplit[0]].equationPresent;
            string[][] equationRightPart = multioperations[equationSplit[1]].equationPresent;
            string[][] result = new string[equationLeftPart.Length][];

            for (int i = 0; i < equationLeftPart.Length; i++)
            {
                string[] s = new string[1];
                s[0] = equationLeftPart[i][0] + "<" + equationRightPart[i][0];
                result[i] = s;
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
                            TMToSEBF.getEquationPresent(rang, multioperations, kvp.Key);
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
    }
}
