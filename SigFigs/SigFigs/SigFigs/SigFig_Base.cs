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

        public SigFig(short value)
        {
            sigFigs = value;
            trailingZeroes = 0;
        }

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
            if(value < 999999999 && value > -999999999)
            {
                sigFigs = (int)value;
                trailingZeroes = 0;
            }
            else if(value < 9999999999 && value > -9999999999)
            {
                sigFigs = (int)(value / 10);
                trailingZeroes = 1;
            }
            else if(value < 99999999999 && value > -99999999999)
            {
                sigFigs = (int)(value / 100);
                trailingZeroes = 2;
            }
            else if(value < 999999999999 && value > -999999999999)
            {
                sigFigs = (int)(value / 1000);
                trailingZeroes = 3;
            }
            else if(value < 9999999999999 && value > -9999999999999)
            {
                sigFigs = (int)(value / 10000);
                trailingZeroes = 4;
            }
            else if(value < 99999999999999 && value > -99999999999999)
            {
                sigFigs = (int)(value / 100000);
                trailingZeroes = 5;
            }
            else if(value < 999999999999999 && value > -999999999999999)
            {
                sigFigs = (int)(value / 1000000);
                trailingZeroes = 6;
            }
            else if(value < 9999999999999999 && value > -9999999999999999)
            {
                sigFigs = (int)(value / 10000000);
                trailingZeroes = 7;
            }
            else if(value < 99999999999999999 && value > -99999999999999999)
            {
                sigFigs = (int)(value / 100000000);
                trailingZeroes = 8;
            }
            else if(value < 999999999999999999 && value > -999999999999999999)
            {
                sigFigs = (int)(value / 1000000000);
                trailingZeroes = 9;
            }
            else
            {
                sigFigs = (int)(value / 10000000000);
                trailingZeroes = 10;
            }
        }

        public static implicit operator SigFig (short value)
        {
            return new SigFig(value);
        }

        public static implicit operator SigFig (int value)
        {
            return new SigFig(value);
        }

        public static implicit operator SigFig (long value)
        {
            return new SigFig(value);
        }

        public static implicit operator short(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt16(temp.Substring(temp.Length - 5));
        }

        public static implicit operator int(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt32(temp.Substring(temp.Length - 10));
        }

        public static implicit operator long(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt64(temp.Substring(temp.Length - 18));
        }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="second">The value to be added.</param>
        /// <returns></returns>
        public SigFig Add(SigFig second)
        {
            long temp = 0;
            if (trailingZeroes > second.trailingZeroes)
            {
                if ((this.trailingZeroes -= second.trailingZeroes) > 9)
                    return this;
                temp = this.sigFigs + (second.sigFigs / 10 ^ (this.trailingZeroes - second.trailingZeroes));
                if (temp > 999999999 || temp < -999999999)
                {
                    this.sigFigs = (int)temp / 10;
                    this.trailingZeroes += 1;
                }
                else
                {
                    this.sigFigs = (int)temp;
                }
            }
            else if (second.trailingZeroes > this.trailingZeroes)
            {
                if ((second.trailingZeroes -= this.trailingZeroes) > 9)
                    return second;
                temp = second.sigFigs + (this.sigFigs / 10 ^ (second.trailingZeroes - this.trailingZeroes));
                if (temp > 999999999 || temp < -999999999)
                {
                    this.sigFigs = (int)temp / 10;
                    this.trailingZeroes = second.trailingZeroes++;
                }
                else
                {
                    this.sigFigs = (int)temp;
                    this.trailingZeroes = second.trailingZeroes;
                }
            }
            else
            {
                temp = this.sigFigs + second.sigFigs;
                if (temp > 999999999 || temp < -999999999)
                {
                    this.sigFigs = (int)temp / 10;
                    this.trailingZeroes += 1;
                }
                else
                {
                    this.sigFigs = (int)temp;
                }
            }
            return this;
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
                temp = first.sigFigs + second.sigFigs;
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
            return first;
        }

        public override string ToString()
        {
            if (sigFigs < 99999 && sigFigs > -99999)
                return sigFigs.ToString();
            return (getSigFigs(3) + "e" + (trailingZeroes + 6));
        }

        public string ToString(int numberOfFigs)
        {
            return (getSigFigs(numberOfFigs) + 'e' + (trailingZeroes + (9 - numberOfFigs)).ToString());
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

        /// <summary>
        /// Gets the value of a number up to the number of specified significant figures.
        /// </summary>
        /// <param name="numberOfFigs">The number of figures to return.</param>
        /// <returns></returns>
        int getSigFigs(int numberOfFigs)
        {
            if (numberOfFigs >= 9)
                return sigFigs;
            string s = sigFigs.ToString();
            string s2 = "";
            for (int i = 0; i < numberOfFigs; i++)
            {
                s2 += s[i];
            }
            return Convert.ToInt32(s2);
        }
    }
}
