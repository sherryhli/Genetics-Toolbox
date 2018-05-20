using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticCodeLibrary
{
    public class CodingStrand : DnaStrand
    {

        public CodingStrand(string sequence) : base(sequence) { }

        public string GetOpenReadingFrame()
        {
            bool startFound = false;
            bool endFound = false;
            int start = -1;
            int end = -1;
            int strandLength = DnaSequence.Length;
            char[] baseArray = DnaSequence.ToCharArray();

            if (strandLength <= 6)
            {
                throw new Exception("This strand is too short to contain an open reading frame.");
            }
            else // search for start codon ATG
            {
                char x; // position 1
                char y; // position 2
                char z; // position 3
                for (int i = 0; i < strandLength; ++i)
                {
                    x = baseArray[i];
                    if (i + 1 < strandLength)
                    {
                        y = baseArray[i + 1];
                        if (i + 2 < strandLength)
                        {
                            z = baseArray[i + 2];
                        }
                        else
                        {
                            throw new Exception("This strand does not contain a start codon and thus does " +
                                                "not contain an open reading frame.");
                        }
                    }
                    else
                    {
                        throw new Exception("This strand does not contain a start codon and thus does " +
                                            "not contain an open reading frame.");
                    }

                    if (x == 'A' && y == 'T' && z == 'G')
                    {
                        start = i;
                        startFound = true;
                        break;
                    }
                }

                if (!startFound)
                {
                    throw new Exception("This strand does not contain a start codon and thus does " +
                                        "not contain an open reading frame.");
                }
                else // search for stop codon TAG, TGA or TAA
                {
                    char a; // position 1
                    char b; // position 2
                    char c; // position 3
                    for (int i = start + 3; i < strandLength; i += 3)
                    {
                        a = baseArray[i];
                        if (i + 1 < strandLength)
                        {
                            b = baseArray[i + 1];
                            if (i + 2 < strandLength)
                            {
                                c = baseArray[i + 2];
                            }
                            else
                            {
                                throw new Exception("This strand does not contain a stop codon and thus " +
                                                    "does not contain an open reading frame.");
                            }
                        }
                        else
                        {
                            throw new Exception("This strand does not contain a stop codon and thus " +
                                                "does not contain an open reading frame.");
                        }

                        if ((a == 'T' && b == 'A' && c == 'G') ||
                            (a == 'T' && b == 'G' && c == 'A') ||
                            (a == 'T' && b == 'A' && c == 'A'))
                        {
                            end = i + 2;
                            endFound = true;
                            break;
                        }
                    }
                }

                if (!endFound)
                {
                    throw new Exception("This strand does not contain a stop codon and thus " +
                                        "does not contain an open reading frame.");
                }
            }

            return DnaSequence.Substring(0, start) + "|" + DnaSequence.Substring(start, end - start + 1) +
                   "|" + DnaSequence.Substring(end + 1, strandLength - end - 1);
        }


        public string Complementary()
        {
            char[] baseArray = DnaSequence.ToCharArray();
            Array.Reverse(baseArray); // changes to 3' to 5' orientation
            String output = new string(baseArray);
            TemplateStrand ts = new TemplateStrand(output); // treat re-oriented strand as template strand
            StringBuilder sb = new StringBuilder();
            sb.Append(ts.Complementary());
            return sb.ToString();
        }


        public override string Transcribe()
        {
            char[] baseArray = DnaSequence.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int strandLength = DnaSequence.Length;
            for (int i = 0; i < strandLength; ++i)
            {
                if (baseArray[i] == 'T')
                {
                    sb.Append("U");
                }
                else
                {
                    sb.Append(baseArray[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
