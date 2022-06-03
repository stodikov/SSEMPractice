using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class Controller
    {
        TransformationMultioperationToSystemEquationBF MOtoSEBF = new TransformationMultioperationToSystemEquationBF();
        methods.NumericalMethod NM = new methods.NumericalMethod();
        methods.AnalyticalMethod AM = new methods.AnalyticalMethod();
        Form_Output formOutput = new Form_Output();

        public Dictionary<string, string[][]> start(int rang, Dictionary<string, Multioperation> multioperations, string[] conditionsInput, string[] equations, string coefficients, string unknowns, string method)
        {
            int rowSystem = 0;
            string[][] systemEquation = new string[rang * equations.Length][];
            foreach(string equation in equations)
            {
                string[][] system = MOtoSEBF.transformation(rang, multioperations, equation);
                for (int i = 0; i < system.Length; i++)
                {
                    systemEquation[rowSystem] = system[i];
                    rowSystem++;
                }
            }
            
            switch (method)
            {
                //case "analytical":
                //    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return AM.getSolution(systemEquation, coefficients, unknowns);
                //    else return AM.getSolution(systemEquation, coefficients, unknowns, conditionsInput);
                case "numeric":
                    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return NM.getSolution(rang, systemEquation, coefficients, unknowns);
                    else return NM.getSolution(rang, systemEquation, coefficients, unknowns, conditionsInput);
                default:
                    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return NM.getSolution(rang, systemEquation, coefficients, unknowns);
                    else return NM.getSolution(rang, systemEquation, coefficients, unknowns, conditionsInput);
            }
        }
    }
}
