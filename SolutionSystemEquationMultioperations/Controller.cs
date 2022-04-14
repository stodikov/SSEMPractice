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

        public Dictionary<string, string[][]> start(int rang, Dictionary<string, Multioperation> multioperations, string[] conditionsInput, string equation, string constants, string unknows, string method)
        {
            string[][] systemEquation = MOtoSEBF.transformation(rang, multioperations, equation);
            
            switch (method)
            {
                case "analytical":
                    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return AM.getSolution(systemEquation, constants, unknows);
                    else return AM.getSolution(systemEquation, constants, unknows, conditionsInput);
                case "numeric":
                    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return NM.getSolution(rang, systemEquation, constants, unknows);
                    else return NM.getSolution(rang, systemEquation, constants, unknows, conditionsInput);
                default:
                    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return NM.getSolution(rang, systemEquation, constants, unknows);
                    else return NM.getSolution(rang, systemEquation, constants, unknows, conditionsInput);
            }
        }
    }
}
