using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormday.MomoMath.Biz
{
    public class NumberRange
    {
        public NumberRange(int max = 100, int min = 0)
        {
            this.Max = max;
            this.Min = min;
        }

        public int Max { get; set; }
        public int Min { get; set; }

        /// <summary>
        /// 计算交集
        /// </summary>
        /// <param name="other">另外一个数字范围</param>
        /// <returns>交集</returns>
        public NumberRange Intersection(NumberRange other)
        {
            int max = Math.Min(this.Max, other.Max);
            int min = Math.Max(this.Min, other.Min);
            return new NumberRange(max, min);
        }

        public bool IsValid
        {
            get
            {
                return this.Max >= this.Min;
            }
        }
    }
}