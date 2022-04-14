using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class parseMultioperations
    {
        public int[][] parseMOtoVectors(int[] MO, int rang)
        {
            int n = MO.Length;
            int logicElements = (int)Math.Pow(2, rang);
            //int[][] codeForInt = new int[][] {
            //    new int[] { 0, 0 },
            //    new int[] { 1, 0 },
            //    new int[] { 0, 1 },
            //    new int[] { 1, 1 }
            //};
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
            
            int[][] codeRepresentation = new int[rang][];
            //int[] newElementOne = new int[n],
            //      newElementTwo = new int[n];

            //for (int k = 0; k < n; k++)
            //{
            //    newElementOne[k] = codeForInt[MO[k]][0];
            //    newElementTwo[k] = codeForInt[MO[k]][1];
            //}

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
    }
}
