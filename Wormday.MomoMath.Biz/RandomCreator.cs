using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormday.MomoMath.Biz
{
    public class RandomCreator
    {
        private static Random r = new Random(DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second);
        public static int GetRandomNumber(NumberRange range)
        {
            return r.Next(range.Min, range.Max + 1);
        }
    }
}
