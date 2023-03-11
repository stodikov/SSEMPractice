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

        public Dictionary<string, string[][]> Start(string rang, string equation, string multioperation, string coefficients, string unknowns, string conditions)
        {
            Dictionary<string, string[][]> result = new Dictionary<string, string[][]>();
            data.PreparingData(rang, equation, multioperation, coefficients, unknowns, conditions);

            if (data.error != "")
            {
                result.Add("error", new string[][] { new string[] { data.error } });
                return result;
            }

            string[] systemEquation = transition.GetSystemEquation(data.rang, data.equations, data.multioperations);
            Dictionary<string, string[][]> solution;

            //?? Если неизвестных несколько, то как их искать?

            if (data.conditions == null) solution = NM.GetSolution(data.rang, systemEquation, data.coefficients, data.unknowns);
            else solution = NM.GetSolution(data.rang, systemEquation, data.coefficients, data.unknowns, data.conditions);

            //return solution;
            //??
            return transition.SolutionInMultioperations(solution, data.rang);
        }
    }
}
