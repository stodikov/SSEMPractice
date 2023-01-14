using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class GeneralFunctionsTransition
    {
        GeneralFunctionsBF general = new GeneralFunctionsBF();

        public void getEquationPresent(int rang, Dictionary<string, Multioperation> multioperations, string key)
        {
            string[] coefficients = multioperations[key].coefficients;
            string[][] newEquationPresent = new string[multioperations[key].codeRepresentation.Length][];

            Array.Reverse(coefficients);
            foreach (string coefficient in coefficients)
            {
                if (newEquationPresent[0] == null) newEquationPresent = MatrixMultiplication(rang, multioperations[coefficient].equationPresent, multioperations[key].codeRepresentation);
                else newEquationPresent = MatrixMultiplication(rang, multioperations[coefficient].equationPresent, null, newEquationPresent);
            }
            multioperations[key].equationPresent = newEquationPresent;
        }

        private string[][] MatrixMultiplication(int rang, string[][] equationPresent, int[][] codeRepresentation = null, string[][] newEquationPresent = null)
        {
            string[][] result = new string[rang][];
            if (codeRepresentation != null)
            {
                for (int i = 0; i < codeRepresentation.Length; i++)
                {
                    string[] partEquation = new string[codeRepresentation[0].Length / rang];
                    int countPartEquation = 0;
                    int countEquationPresent = 0;
                    for (int j = 0; j < codeRepresentation[i].Length; j+=rang)
                    {
                        string s = "";
                        for (int k = 0; k < rang; k++)
                        {
                            if (codeRepresentation[i][j + k] == 1)
                            {
                                if (equationPresent[k][countEquationPresent] == "1")
                                {
                                    s = "1";
                                    break;
                                } else if (equationPresent[k][countEquationPresent] == "0")
                                {
                                    if (s == "") s += "0";
                                }
                                else
                                {
                                    if (s == "") s += equationPresent[k][countEquationPresent];
                                    else s += "V" + equationPresent[k][countEquationPresent];
                                }
                            }
                        }
                        if (s == "") s = "0";
                        partEquation[countPartEquation] = s;
                        countPartEquation++;
                        countEquationPresent = (countEquationPresent + 1) % equationPresent[0].Length;
                    }
                    partEquation = general.DeleteRepeatElements(partEquation);
                    result[i] = partEquation;
                }
            }
            else
            {
                for (int i = 0; i < newEquationPresent.Length; i++)
                {
                    string[] partEquation = new string[newEquationPresent[0].Length / rang];
                    int countPartEquation = 0;
                    for (int j = 0; j < newEquationPresent[i].Length; j+=rang)
                    {
                        string s = "";
                        for (int k = 0; k < rang; k++)
                        {
                            if (newEquationPresent[i][j + k] == "0") continue;
                            if (newEquationPresent[i][j + k] == "1")
                            {
                                s += equationPresent[k][0] + "V";
                                continue;
                            }

                            if (equationPresent[k][0] == "0") continue;
                            if (equationPresent[k][0] == "1")
                            {
                                s += newEquationPresent[i][j + k] + "V";
                                continue;
                            }
                            
                            if (newEquationPresent[i][j + k].Contains('V') && !equationPresent[k][0].Contains('V'))
                            {
                                string[] split = newEquationPresent[i][j + k].Split('V');
                                foreach(string temp in split) s += $"{temp}&{equationPresent[k][0]}V";
                            }
                            else if (!newEquationPresent[i][j + k].Contains('V') && equationPresent[k][0].Contains('V'))
                            {
                                string[] split = equationPresent[k][0].Split('V');
                                foreach (string temp in split) s += $"{temp}&{newEquationPresent[i][j + k]}V";
                            }
                            else
                            {
                                string[] splitNewEquation = newEquationPresent[i][j + k].Split('V');
                                string[] splitEquation = equationPresent[k][0].Split('V');
                                foreach (string elemNewEquation in splitNewEquation)
                                    foreach (string elemEquation in splitEquation) s += $"{elemNewEquation}&{elemEquation}V";
                            }
                        }
                        s = s.TrimEnd('V');
                        if (s == "") s = "0";
                        s = general.ReductionEquation(s);
                        partEquation[countPartEquation] = s;
                        countPartEquation++;
                    }
                    for (int j = 0; j < partEquation.Length; j++) partEquation[j] = general.ReductionEquation(partEquation[j]);
                    result[i] = partEquation;
                }
            }
            return result;
        }
    }
}
