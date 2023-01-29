using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class PrepairingData
    {
        public int rang { get; set; }
        public Dictionary<string, Multioperation> multioperations { get; set; }
        public string[] conditions { get; set; }
        public string coefficients { get; set; }
        public string unknowns { get; set; }
        public string[] equations { get; set; }
        public string method { get; set; }
        public string error { get; set; }

        //Для декомпозиции уравнений
        private Dictionary<string, int> elementsOfEquation = new Dictionary<string, int>();
        private ArrayList resultDecomposition = new ArrayList();
        private int count = 0;
        private string mainEquation = "", notConstants = "";
        //Для декомпозиции уравнений

        private void ClearData()
        {
            rang = 0;
            error = "";
            coefficients = "";
            unknowns = "";
            equations = new string[0];
            conditions = new string[0];
            elementsOfEquation.Clear();

            if (multioperations == null) multioperations = new Dictionary<string, Multioperation>();
            else multioperations.Clear();
        }

        public void PreparingData(string rang, string equation, string multioperations, string coefficients, string unknowns, string conditions)
        {
            ClearData();
            //Проверка ранга
            ValidateRang(rang);
            if (error != "") return;
            //Проверка мультиопераций
            Dictionary<string, int[]> vectorsMultioperations = ValidateMultioperations(multioperations.Replace("\r", "").Split('\n'), this.rang);
            if (error != "") return;
            //Проверка коэффициентов
            if (coefficients != "") ValidateCoefficients(coefficients.Split(','));
            //Проверка неизвестных
            ValidateUnknowns(unknowns.Split(','));
            //Проверка условий
            if (conditions != "") ValidateConditions(conditions.Replace("\r", "").Split('\n'));
            if (error != "") return;
            //Проверка уравнения
            ValidateEquation(equation.Replace("\r", "").Split('\n'), vectorsMultioperations);
            if (error != "") return;
        }

        private void ValidateRang(string rang)
        {
            int rangEquation;
            bool isNumber = int.TryParse(rang, out rangEquation);
            if (isNumber) this.rang = rangEquation;
            else error += $"Ранг должен быть задан числом|";
        }

        private Dictionary<string, int[]> ValidateMultioperations(string[] multioperations, int rang)
        {
            Dictionary<string, int[]> vectorsMultioperations = new Dictionary<string, int[]>();
            foreach (string s in multioperations)
            {
                int[] multioperation;
                string[] input = s.Split('=');
                if (input.Length != 2) error = $"Неправильно задача мультиоперация {input[0]}|";

                if (rang < 4)
                {
                    if (input[1].Length % rang != 0) error = $"Размер вектора мультиоперации {input[0]} не кратен рангу ({rang})|";

                    multioperation = new int[input[1].Length];
                    for (int i = 0; i < input[1].Length; i++)
                    {
                        bool isNumber = int.TryParse($"{input[1][i]}", out multioperation[i]);
                        if (!isNumber) error += $"Ошибка в мультиоперации {input[0]} - элементы мультиоперации должны быть от 0 до {Math.Pow(2, rang) - 1}|";
                    }
                }
                else
                {
                    string[] elementsMO = input[1].Split(new char[] { ',', ' ' });
                    if (elementsMO.Length % rang != 0) error = $"Размер вектора мультиоперации {input[0]} не кратен рангу ({rang})|";

                    multioperation = new int[elementsMO.Length];
                    for (int i = 0; i < elementsMO.Length; i++)
                    {
                        bool isNumber = int.TryParse($"{elementsMO[i]}", out multioperation[i]);
                        if (!isNumber) error += $"Ошибка в мультиоперации {input[0]} - элементы мультиоперации должны быть от 0 до {Math.Pow(2, rang) - 1}|";
                    }
                }
                if (elementsOfEquation.ContainsKey(input[0])) error = $"Обозначение мультиоперации {input[0]} уже используется|";
                else elementsOfEquation.Add(input[0], 1);

                if (error == "") vectorsMultioperations.Add(input[0], multioperation);
            }
            return vectorsMultioperations;
        }

        private void ValidateCoefficients(string[] coefficients)
        {
            multioperations = new Dictionary<string, Multioperation>();
            string coefficientsOfEquation = "";
            foreach (string coefficient in coefficients)
            {
                string[][] newEquation = new string[rang][];
                for (int i = 0; i < rang; i++)
                {
                    newEquation[i] = new string[] { $"{coefficient}_{i + 1}" };
                    coefficientsOfEquation += $"{coefficient}_{i + 1},";
                }
                if (elementsOfEquation.ContainsKey(coefficient)) error = $"Обозначение коэффициента {coefficient} уже используется|";
                else elementsOfEquation.Add(coefficient, 1);

                if (error == "") multioperations.Add(coefficient, new Multioperation(coefficient, null, null, newEquation));
            }
            this.coefficients = coefficientsOfEquation.TrimEnd(',');
        }

        private void ValidateUnknowns(string[] unknowns)
        {
            string unknownsOfEquation = "";
            foreach (string unknown in unknowns)
            {
                string[][] newEquation = new string[rang][];
                for (int i = 0; i < rang; i++)
                {
                    newEquation[i] = new string[] { $"{unknown}_{i + 1}" };
                    unknownsOfEquation += $"{unknown}_{i + 1},";
                }
                if (elementsOfEquation.ContainsKey(unknown)) error = $"Обозначение неизвестной {unknown} уже используется|";
                else elementsOfEquation.Add(unknown, 1);

                if (error == "") multioperations.Add(unknown, new Multioperation(unknown, null, null, newEquation));
            }
            this.unknowns = unknownsOfEquation.TrimEnd(',');
        }

        private void ValidateConditions(string[] conditions)
        {
            string[] unknowns = this.unknowns.Split(',');
            string[] coefficients = this.coefficients.Split(',');
            foreach (string condition in conditions)
            {
                string[] elementsOfCondition = condition.Split('|');
                if (elementsOfCondition.Length < 2) error += $"Неправильно задано условие - {condition}|";
                if (elementsOfCondition[0] != "!=") error += $"Неизвестный символ условия - {condition}|";

                elementsOfCondition = elementsOfCondition[1].Split(',');
                foreach (string element in elementsOfCondition)
                    if (!Array.Exists(unknowns, unknown => unknown == element) && !Array.Exists(coefficients, coefficient => coefficient == element)) error += $"Неизвестный коэффициент в условие - {condition} - {element}|";
            }
            if (error == "") this.conditions = conditions;
        }

        private void ValidateEquation(string[] equations, Dictionary<string, int[]> vectorsMultioperations)
        {
            string[] decompositionEquation;
            string[] notConstantsArr;
            this.equations = new string[equations.Length];
            helpers.ParseMultioperations parse = new helpers.ParseMultioperations();

            for (int i = 0; i < equations.Length; i++)
            {
                ArrayList list = DecompositionEquation(equations[i], i);
                if (error != "") return;

                decompositionEquation = new string[list.Count];
                for (int j = 0; j < decompositionEquation.Length; j++) decompositionEquation[j] = list[j].ToString();

                foreach (string elemDecomposition in decompositionEquation)
                {
                    if (elemDecomposition.Contains('<')) this.equations[i] = elemDecomposition;
                    else
                    {
                        string designationDecomposition = elemDecomposition.Split('=')[0];
                        string designationMultioperation = elemDecomposition.Split('=')[1].Split('|')[0];
                        string[] arguments = elemDecomposition.Split('=')[1].Split('|')[1].Split(',');

                        if (vectorsMultioperations.ContainsKey(designationMultioperation))
                        {
                            if (vectorsMultioperations[designationMultioperation].Length != Math.Pow(rang, arguments.Length)) error += $"Ошибка между соотношением переменных и векторной формы мультиоперации {designationMultioperation}|";

                            notConstants += designationMultioperation + ',';
                            int[][] codeRepresentation = parse.ParseMOtoVectors(vectorsMultioperations[designationMultioperation], rang);
                            Multioperation newMO = new Multioperation(designationMultioperation, codeRepresentation, arguments, null);
                            multioperations.Add(designationDecomposition, newMO);
                        }
                    }
                }
            }

            notConstantsArr = notConstants.TrimEnd(',').Split(',').Distinct().ToArray();
            foreach (KeyValuePair<string, int[]> kvp in vectorsMultioperations)
            {
                if (notConstantsArr.Contains(kvp.Key)) continue;
                if (vectorsMultioperations[kvp.Key].Length != rang) error = $"Количество элементов в константе должно быть равно {rang}|";
                string[][] equationPresent = parse.ParseMOtoVectorsEquation(vectorsMultioperations[kvp.Key], rang);
                Multioperation newMO = new Multioperation(kvp.Key, null, null, equationPresent);
                multioperations.Add(kvp.Key, newMO);
            }
        }

        private ArrayList DecompositionEquation(string equation, int indexEquation)
        {
            resultDecomposition.Clear();
            count = 0;
            mainEquation = "";

            Decomposition(equation, indexEquation);

            return resultDecomposition;
        }

        private string Decomposition(string equation, int indexEquation)
        {
            string function = "", functionArguments = "", arguments = "", codeFunction = "";
            while (count < equation.Length)
            {
                switch (equation[count])
                {
                    case '(':
                        count++;
                        arguments = Decomposition(equation, indexEquation);
                        string[] argumentsArr = arguments.Split(',');
                        foreach (string argument in argumentsArr)
                            if (!elementsOfEquation.ContainsKey(argument.Split('_')[0]))
                                error += $"Неизвестный аргумент {argument} в мультиоперации {function}|";

                        if (elementsOfEquation.ContainsKey(function))
                        {
                            codeFunction = $"{function}_{Convert.ToString(elementsOfEquation[function])}_{indexEquation}";
                            elementsOfEquation[function] = elementsOfEquation[function] + 1;
                        }
                        else error += $"Неизвестная мультиоперация {function}|";

                        resultDecomposition.Add($"{codeFunction}={function}|{arguments}");
                        functionArguments = functionArguments.Substring(0, functionArguments.LastIndexOf(function)) + codeFunction;
                        function = "";
                        break;
                    case ')':
                        return functionArguments;
                    case '<':
                        function = "";
                        functionArguments = "";
                        if (resultDecomposition.Count != 0) mainEquation = resultDecomposition[resultDecomposition.Count - 1].ToString().Split('=')[0] + '<';
                        else mainEquation = equation.Substring(0, count) + '<';
                        break;
                    default:
                        if (equation[count] != ',') function += equation[count];
                        else function = "";
                        functionArguments += equation[count];
                        break;
                }
                count++;
            }
            if (function != "") mainEquation += function;
            else mainEquation += resultDecomposition[resultDecomposition.Count - 1].ToString().Split('=')[0];
            resultDecomposition.Add(mainEquation);
            return "";
        }
    }
}
