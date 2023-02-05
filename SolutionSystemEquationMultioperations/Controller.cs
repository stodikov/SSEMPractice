using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class Controller
    {
        /*
         * 1) Подсказки: короткая - для быстрого запуска программы, и большая - подробное описание как все работает
         * 2) Сохранение и загрузка файлов
         * 3) Как задавать условия?
         * 
         * 1) Ввод правил вывода: реализация импликации и конъюнкции
         * 2) Подвод программы под экспертную системы (Реализация множества по методичке)
         */
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

            return solution;
            //??
            //return transition.SolutionInMultioperations(solution, data.rang);
        }
    }
}
