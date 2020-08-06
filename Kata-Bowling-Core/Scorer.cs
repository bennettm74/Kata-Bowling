using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_Bowling_Core
{
    public static class Scorer
    {
        public static ushort ScoreLine(string line)
        {
            if (null == (line = line?.Replace(" ", "").ToUpper())) throw new ArgumentNullException(nameof(line));

            ushort score = 0;

            byte need1Roll = 0;
            byte need2Rolls = 0;

            byte frame = 1;
            bool isFirstRoll = true;
            byte spareValue = 0;

            foreach (char c in line)
            {
                switch (c)
                {
                    case '/':
                        score += (byte)((need1Roll + need2Rolls) * spareValue);
                        need1Roll = need2Rolls;
                        need2Rolls = 0;
                        if (frame <= 10)
                        {
                            score += spareValue;
                            need1Roll++;
                        }
                        frame++;
                        isFirstRoll = true;
                        break;
                    case 'X':
                        score += (byte)((need1Roll + need2Rolls) * 10);
                        need1Roll = need2Rolls;
                        if (frame <= 10)
                        {
                            score += 10;
                            need2Rolls = 1; 
                        }
                        else
                            need2Rolls = 0; 
                        frame++;
                        isFirstRoll = true;
                        break;
                    default:
                        if ('-' != c && (!Char.IsDigit(c))) throw new ArgumentOutOfRangeException(nameof(line));
                        byte value = (byte)('-' == c ? 0 : (c - '0'));
                        score += (byte)((need1Roll + need2Rolls) * value);
                        need1Roll = need2Rolls;
                        need2Rolls = 0;
                        if (frame <= 10) score += value;
                        if (isFirstRoll)
                        {
                            spareValue = (byte)(10 - value);
                            isFirstRoll = false;
                        }
                        else
                        {
                            frame++;
                            isFirstRoll = true;
                        }
                        break;
                }
            }

            return score;
        }
    }
}
