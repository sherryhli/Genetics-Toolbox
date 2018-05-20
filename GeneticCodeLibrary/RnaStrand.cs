using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticCodeLibrary
{
    public class RnaStrand
    {
        public string RnaSequence { get; set; }

        public RnaStrand(string sequence)
        {
            RnaSequence = sequence;
        }

        public string Translate()
        {
            char x;
            char y;
            char z;
            char[] baseArray = RnaSequence.ToCharArray();
            int strandLength = RnaSequence.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strandLength; i += 3)
            {
                x = baseArray[i];
                y = baseArray[i + 1];
                z = baseArray[i + 2];

                if (x == 'U')
                {
                    if (y == 'U')
                    {
                        if (z == 'U' || z == 'C')
                        {
                            sb.Append("Phe ");
                        }
                        else
                        {
                            sb.Append("Leu ");
                        }
                    }
                    else if (y == 'C')
                    {
                        sb.Append("Ser ");
                    }
                    else if (y == 'A')
                    {
                        if (z == 'U' || z == 'C')
                        {
                            sb.Append("Tyr ");
                        }
                        else
                        {
                            return sb.ToString().Trim();
                        }
                    }
                    else if (y == 'G')
                    {
                        if (z == 'U' || z == 'C')
                        {
                            sb.Append("Cys ");
                        }
                        else if (z == 'A')
                        {
                            return sb.ToString().Trim();
                        }
                        else
                        {
                            sb.Append("Trp ");
                        }
                    }
                }
                else if (x == 'C')
                {
                    if (y == 'U')
                    {
                        sb.Append("Leu ");
                    }
                    else if (y == 'C')
                    {
                        sb.Append("Pro ");
                    }
                    else if (y == 'A')
                    {
                        if (z == 'U' || z == 'C')
                        {
                            sb.Append("His ");
                        }
                        else
                        {
                            sb.Append("Gln ");
                        }
                    }
                    else
                    {
                        sb.Append("Arg ");
                    }
                }
                else if (x == 'A')
                {
                    if (y == 'U')
                    {
                        if (z == 'U' || z == 'C' || z == 'A')
                        {
                            sb.Append("Ile ");
                        }
                        else
                        {
                            sb.Append("Met ");
                        }
                    }
                    else if (y == 'C')
                    {
                        sb.Append("Thr ");
                    }
                    else if (y == 'A')
                    {
                        if (z == 'U' || z == 'C')
                        {
                            sb.Append("Asn ");
                        }
                        else
                        {
                            sb.Append("Lys ");
                        }
                    }
                    else
                    {
                        if (z == 'U' || z == 'C')
                        {
                            sb.Append("Ser ");
                        }
                        else
                        {
                            sb.Append("Arg ");
                        }
                    }
                }
                else
                {
                    if (y == 'U')
                    {
                        sb.Append("Val ");
                    }
                    else if (y == 'C')
                    {
                        sb.Append("Ala ");
                    }
                    else if (y == 'A')
                    {
                        if (z == 'U' || z == 'C')
                        {
                            sb.Append("Asp ");
                        }
                        else
                        {
                            sb.Append("Glu ");
                        }
                    }
                    else
                    {
                        sb.Append("Gly ");
                    }
                }
            }

            throw new Exception("Unknown error occurred."); // Should never reach this point
        }

    }
}
