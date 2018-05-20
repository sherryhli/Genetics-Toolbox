using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticCodeLibrary
{
    public abstract class DnaStrand
    {
        private string _dnaSequence;

        public string DnaSequence
        {
            get { return _dnaSequence; }
            set // ensures sequence only contains valid DNA bases
            {
                char[] baseArray = value.ToCharArray();
                int strandLength = value.Length;
                for (int i = 0; i < strandLength; ++i)
                {
                    if (!((baseArray[i].ToString().ToUpper() == "A") ||
                          (baseArray[i].ToString().ToUpper() == "C") ||
                          (baseArray[i].ToString().ToUpper() == "T") ||
                          (baseArray[i].ToString().ToUpper() == "G")))
                    {
                        throw new Exception("This sequence contains an invalid base. " +
                                            "Ensure that the sequence only contains A, C, T, G.");
                    }
                    else
                    {
                        _dnaSequence = value.ToUpper();
                    }

                }
            }
        }

        public DnaStrand(string sequence)
        {
            DnaSequence = sequence;
        }

        public string ComplementaryBaseFunction()
        {
            char[] baseArray = DnaSequence.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int strandLength = DnaSequence.Length;
            for (int i = 0; i < strandLength; ++i)
            {
                if (baseArray[i] == 'A')
                {
                    sb.Append("T");
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

        public abstract string Transcribe();

    }
}
