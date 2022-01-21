using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations.helpers
{
    class parseMultioperations
    {
        public int[][] parseMOtoVectorsRang2(int[] MO)
        {
            int n = MO.Length;
            int[][] codeForInt = new int[][] {
                new int[] { 0, 0 },
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                new int[] { 1, 1 }
            };
            
            int[][] codeRepresentation = new int[2][];
            int[] newElementOne = new int[n],
                  newElementTwo = new int[n];
            
            for (int k = 0; k < n; k++)
            {
                newElementOne[k] = codeForInt[MO[k]][0];
                newElementTwo[k] = codeForInt[MO[k]][1];
            }

            codeRepresentation[0] = newElementOne;
            codeRepresentation[1] = newElementTwo;

            return codeRepresentation;
        }
    }
}
