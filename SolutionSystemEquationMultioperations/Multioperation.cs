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
        public string[] arguments { get; set; }
        public string[][] equationPresent { get; set; }

        public Multioperation(string designation, int[][] codeRepresentation = null, string[] arguments = null, string[][] equationPresent = null)
        {
            this.designation = designation;
            this.arguments = arguments;
            this.codeRepresentation = codeRepresentation;
            this.equationPresent = equationPresent;
        }
    }
}
