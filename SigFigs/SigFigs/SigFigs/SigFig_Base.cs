using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigFigs.SigFigs
{
    class SigFig
    {
        /// <summary>
        /// The significant figures
        /// </summary>
        int sigFigs;
        /// <summary>
        /// The trailing zeroes
        /// </summary>
        short trailingZeroes;

        public SigFig(int value)
        {
            if (value < 999999999 && value > -999999999)
            {
                sigFigs = value;
                trailingZeroes = 0;
            }
            else
            {
                sigFigs = value / 10;
                trailingZeroes = 1;
            }
        }

        public SigFig(long value)
        {

        }

        public static implicit operator SigFig (int value)
        {
            return new SigFig(value);
        }

        public static implicit operator SigFig (long value)
        {
            return new SigFig(value);
        }

        public static SigFig operator +(SigFig first, SigFig second)
        {
            long temp = 0;
            if(first.trailingZeroes > second.trailingZeroes)
            {
                if ((first.trailingZeroes -= second.trailingZeroes) > 9)
                    return first;
                temp = first.sigFigs + (second.sigFigs / 10 ^ (first.trailingZeroes - second.trailingZeroes));
                if (temp > 999999999 || temp < -999999999)
                {
                    first.sigFigs = (int)temp / 10;
                    first.trailingZeroes += 1;
                }
                else
                {
                    first.sigFigs = (int)temp;
                }
            }
            else if(second.trailingZeroes > first.trailingZeroes)
            {
                if ((second.trailingZeroes -= first.trailingZeroes) > 9)
                    return second;
                temp = second.sigFigs + (first.sigFigs / 10 ^ (second.trailingZeroes - first.trailingZeroes));
                if (temp > 999999999 || temp < -999999999)
                {
                    first.sigFigs = (int)temp / 10;
                    first.trailingZeroes  = second.trailingZeroes++;
                }
                else
                {
                    first.sigFigs = (int)temp;
                    first.trailingZeroes = second.trailingZeroes;
                }
            }
            else
            {


            }
            return first;
        }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="isFullNumber">if set to <c>true</c> displays number fully written out.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(bool isFullNumber)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append(sigFigs);
            for (int i = 0; i < trailingZeroes; i++)
            {
                temp.Append(0);
            }
            return temp.ToString();
        }
    }
}
