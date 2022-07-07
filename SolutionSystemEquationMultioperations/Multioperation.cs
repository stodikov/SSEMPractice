using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionSystemEquationMultioperations
{
    class Multioperation
    {
        public string designation { get; set; }
        public int[][] codeRepresentation { get; set; }
        public string[] coefficients { get; set; }
        public string[][] equationPresent { get; set; }

        public Multioperation(string designation, int[][] codeRepresentation = null, string[] coefficients = null, string[][] equationPresent = null)
        {
            this.designation = designation;
            this.coefficients = coefficients;
            this.codeRepresentation = codeRepresentation;
            this.equationPresent = equationPresent;
        }
    }
}
