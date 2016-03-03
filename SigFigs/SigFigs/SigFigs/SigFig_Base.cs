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

        #region Conversions and Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SigFig"/> class.
        /// </summary>
        /// <param name="value">The value to be put into the SigFig.</param>
        public SigFig(short value)
        {
            sigFigs = value;
            trailingZeroes = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SigFig"/> class.
        /// </summary>
        /// <param name="value">The value to be put into the SigFig.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SigFig"/> class.
        /// </summary>
        /// <param name="value">The value to be put into the SigFig.</param>
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

        /// <summary>
        /// Converts the SigFig into a short, returning 0 if there is no values stored within the scope of the short.
        /// </summary>
        /// <param name="value">The value that will be made into a short.</param>
        /// <returns></returns>
        public short toShort(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt16(temp.Substring(temp.Length - 5));
        }

        public static implicit operator short(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt16(temp.Substring(temp.Length - 5));
        }

        /// <summary>
        /// Converts the SigFig into an int, returning 0 if there is no value stored within the scope of the int.
        /// </summary>
        /// <param name="value">The value that will be made into an int.</param>
        /// <returns></returns>
        public int toInt(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt32(temp.Substring(temp.Length - 10));
        }

        public static implicit operator int(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt32(temp.Substring(temp.Length - 10));
        }

        /// <summary>
        /// Converts the SigFig into a long, returning 0 if there is no value stored within the scope of the long.
        /// </summary>
        /// <param name="value">The value that will be made into a long.</param>
        /// <returns></returns>
        public long toLong(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt64(temp.Substring(temp.Length - 18));
        }

        public static implicit operator long(SigFig value)
        {
            string temp = value.ToString(true);
            return Convert.ToInt64(temp.Substring(temp.Length - 18));
        }
        #endregion

        #region Math Operations
        #region Addition Operations
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

        /// <summary>
        /// Increments the specified amount to the end of the significant digits.
        /// </summary>
        /// <param name="amount">The amount to be incremented.</param>
        /// <returns></returns>
        public SigFig Increment(int amount = 1)
        {
            sigFigs += amount;
            return this;
        }

        public static SigFig operator ++(SigFig first)
        {
            if (first.trailingZeroes > 0)
                return first;
            else
            {
                first.sigFigs++;
                return first;
            }
        }
        #endregion

        /// <summary>
        /// Decrements the specified amount from the end of the SigFig.
        /// </summary>
        /// <param name="amount">The amount to decrement.</param>
        /// <returns></returns>
        public SigFig Decrement(int amount = 1)
        {
            sigFigs -= amount;
            return this;
        }

        public static SigFig operator --(SigFig first)
        {
            if (first.trailingZeroes > 0)
                return first;
            else
            {
                first.sigFigs--;
                return first;
            }
        }

        public static SigFig operator %(SigFig first, int second)
        {
            return first.sigFigs % second;
        }
        #endregion

        #region Logical Operations
        public static bool operator ==(SigFig first, SigFig second)
        {
            if (first.sigFigs == second.sigFigs && first.trailingZeroes == second.trailingZeroes)
                return true;
            else return false;

        }

        public static bool operator !=(SigFig first, SigFig second)
        {
            if (first.sigFigs != second.sigFigs || first.trailingZeroes != second.trailingZeroes)
                return true;
            else return false;
        }

        public static bool operator >(SigFig first, SigFig second)
        {
            if (first.trailingZeroes > second.trailingZeroes)
            {
                return true;
            }
            else if (first.trailingZeroes == second.trailingZeroes && first.sigFigs > second.sigFigs)
                return true;
            else return false;
        }

        public static bool operator <(SigFig first, SigFig second)
        {
            if (second.trailingZeroes > first.trailingZeroes)
                return true;
            else if (second.trailingZeroes == first.trailingZeroes && second.sigFigs > first.sigFigs)
                return true;
            else return false;
        }

        public static bool operator >=(SigFig first, SigFig second)
        {
            if (first.sigFigs == second.sigFigs && first.trailingZeroes == second.trailingZeroes)
                return true;
            else if (second.trailingZeroes > first.trailingZeroes)
                return true;
            else if (second.trailingZeroes == first.trailingZeroes && second.sigFigs > first.sigFigs)
                return true;
            else return false;
        }

        public static bool operator <=(SigFig first, SigFig second)
        {
            if (first.sigFigs == second.sigFigs && first.trailingZeroes == second.trailingZeroes)
                return true;
            else if (second.trailingZeroes > first.trailingZeroes)
                return true;
            else if (second.trailingZeroes == first.trailingZeroes && second.sigFigs > first.sigFigs)
                return true;
            else return false;
        }
        #endregion

        #region Object Overloads
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance always holding the 3 most significant digits with e_ after it showing the amount of trailing zeroes.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (sigFigs < 99999 && sigFigs > -99999)
                return sigFigs.ToString();
            return (getSigFigs(3) + "e" + (trailingZeroes + 6));
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance always holding the most significant digits that you define with e_ after it showing the amount of trailing zeroes.
        /// </summary>
        /// <param name="numberOfFigs">The number of digits to be shown.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(int numberOfFigs)
        {
            return (getSigFigs(numberOfFigs).ToString() + "e" + (trailingZeroes + (9 - numberOfFigs)).ToString());
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
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance SHOULD ONLY BE OF TYPE SIGFIG AS OF THIS TIME.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>

        public override bool Equals(object obj)
        {
            return this == obj as SigFig;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

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
