using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticCodeLibrary
{
    public class TemplateStrand : DnaStrand
    {
        public TemplateStrand(string sequence) : base(sequence) { }

        public string Complementary()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"5'-");
            sb.Append(ComplementaryBaseFunction());
            sb.Append(@"-3'");
            return sb.ToString();
        }

        public override string Transcribe()
        {
            char[] baseArray = DnaSequence.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int strandLength = DnaSequence.Length;
            for (int i = 0; i < strandLength; ++i)
            {
                if (baseArray[i] == 'A')
                {
                    sb.Append("U");
                } else if (baseArray[i] == 'C')
                {
                    sb.Append("G");
                } else if (baseArray[i] == 'T')
                {
                    sb.Append("A");
                }
                else
                {
                    sb.Append("C");
                }
            }

            return sb.ToString();
        }

    }
}
