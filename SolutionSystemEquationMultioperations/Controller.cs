using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class Controller
    {
        PrepairingData data = new PrepairingData();
        Transition transition = new Transition();
        methods.NumericalMethod NM = new methods.NumericalMethod();
        methods.AnalyticalMethod AM = new methods.AnalyticalMethod();

        public Dictionary<string, string[][]> Start(string rang, string equation, string multioperation, string coefficients, string unknowns, string conditions, bool method)
        {
            Dictionary<string, string[][]> result = new Dictionary<string, string[][]>();
            data.PreparingData(rang, equation, multioperation, coefficients, unknowns, conditions, method);

            if (data.error != "")
            {
                result.Add("error", new string[][] { new string[] { data.error } });
                return result;
            }

            string[][] systemEquation = transition.getSystemEquation(data.rang, data.equations, data.multioperations);


            switch (data.method)
            {
                //case "analytical":
                //    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return AM.getSolution(systemEquation, coefficients, unknowns);
                //    else return AM.getSolution(systemEquation, coefficients, unknowns, conditionsInput);
                case "numeric":
                    if (data.conditions == null) return NM.getSolution(data.rang, systemEquation, data.coefficients, data.unknowns);
                    else return NM.getSolution(data.rang, systemEquation, data.coefficients, data.unknowns, data.conditions);
                default:
                    if (data.conditions == null) return NM.getSolution(data.rang, systemEquation, data.coefficients, data.unknowns);
                    else return NM.getSolution(data.rang, systemEquation, data.coefficients, data.unknowns, data.conditions);
            }
        }

        //public Dictionary<string, string[][]> start(int rang, Dictionary<string, Multioperation> multioperations, string[] conditionsInput, string[] equations, string coefficients, string unknowns, string method)
        //{
        //    int rowSystem = 0;
        //    string[][] systemEquation = new string[rang * equations.Length][];
        //    foreach(string equation in equations)
        //    {
        //        string[][] system = MOtoSEBF.transformation(rang, multioperations, equation);
        //        for (int i = 0; i < system.Length; i++)
        //        {
        //            systemEquation[rowSystem] = system[i];
        //            rowSystem++;
        //        }
        //    }
            
        //    switch (method)
        //    {
        //        //case "analytical":
        //        //    if (conditionsInput.Length == 1 && conditionsInput[0] == "") return AM.getSolution(systemEquation, coefficients, unknowns);
        //        //    else return AM.getSolution(systemEquation, coefficients, unknowns, conditionsInput);
        //        case "numeric":
        //            if (conditionsInput.Length == 1 && conditionsInput[0] == "") return NM.getSolution(rang, systemEquation, coefficients, unknowns);
        //            else return NM.getSolution(rang, systemEquation, coefficients, unknowns, conditionsInput);
        //        default:
        //            if (conditionsInput.Length == 1 && conditionsInput[0] == "") return NM.getSolution(rang, systemEquation, coefficients, unknowns);
        //            else return NM.getSolution(rang, systemEquation, coefficients, unknowns, conditionsInput);
        //    }
        //}
    }
}
