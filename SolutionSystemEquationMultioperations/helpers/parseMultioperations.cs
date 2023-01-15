using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class ParseMultioperations
    {
        public int[][] ParseMOtoVectors(int[] MO, int rang)
        {
            int n = MO.Length;
            int[][] codeForInt = GetCodeForInt(rang);
            int[][] codeRepresentation = new int[rang][];

            for (int r = 0; r < rang; r++)
            {
                int[] newElementRang = new int[n];
                for (int k = 0; k < n; k++)
                {
                    newElementRang[k] = codeForInt[MO[k]][r];
                }
                codeRepresentation[r] = newElementRang;
            }

            return codeRepresentation;
        }

        public string[][] ParseMOtoVectorsEquation(int[] MO, int rang)
        {
            int n = MO.Length;
            int[][] codeForInt = GetCodeForInt(rang);
            string[][] codeRepresentation = new string[rang][];

            for (int r = 0; r < rang; r++)
            {
                string[] newElementRang = new string[n];
                for (int k = 0; k < n; k++)
                {
                    newElementRang[k] = Convert.ToString(codeForInt[MO[k]][r]);
                }
                codeRepresentation[r] = newElementRang;
            }

            return codeRepresentation;
        }

        public int[][] GetCodeForInt(int rang)
        {
            int logicElements = (int)Math.Pow(2, rang);
            int[][] codeForInt = new int[logicElements][];
            string binary = "", temp = "";
            for (int i = 0; i < logicElements; i++)
            {
                binary = Convert.ToString(i, 2);
                if (binary.Length < rang)
                {
                    for (int r = rang - binary.Length; r > 0; r--) temp += "0"; //?
                    binary = temp + binary;
                    temp = "";
                }
                binary = new string(binary.Reverse().ToArray());
                int[] codeElement = new int[rang];
                for (int j = 0; j < codeElement.Length; j++) codeElement[j] = binary[j] - '0';
                codeForInt[i] = codeElement;
            }
            return codeForInt;
        }
    }
}
