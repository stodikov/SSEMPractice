using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class Controller
    {
        TransformationMultioperationToSystemEquationBF MOtoSEBF = new TransformationMultioperationToSystemEquationBF();
        NumericalMethod NM = new NumericalMethod();
        Form_Output formOutput = new Form_Output();

        public Dictionary<string, string[][]> start(Dictionary<string, Multioperation> multioperations, string[] conditionsInput, string equation, string constants, string unknows)
        {
            string[][] systemEquation = MOtoSEBF.transformation(multioperations, equation);
            if (conditionsInput.Length == 1 && conditionsInput[0] == "") return NM.getSolution(systemEquation, constants, unknows);
            else return NM.getSolution(systemEquation, constants, unknows, conditionsInput);


            //formOutput.showResult(resultEquation, equation, unknows);
        }
    }
}
