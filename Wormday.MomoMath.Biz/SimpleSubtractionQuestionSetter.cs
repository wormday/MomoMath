using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormday.MomoMath.Biz
{
    public class SimpleSubtractionQuestionSetter : BaseQuestionSetter
    {
        /// <summary>被减数范围</summary>
        public NumberRange MinuendRange { get; set; }

        /// <summary>减数范围</summary>
        public NumberRange SubtrahendRange { get; set; }

        /// <summary>差范围</summary>
        public NumberRange DifferenceRange { get; set; }

        /// <summary>
        /// 创建题目
        /// </summary>
        /// <returns></returns>
        public override MathProblem CreateMathProblem()
        {
            NumberRange finalDifferenceRange = new NumberRange(max: this.MinuendRange.Max - this.SubtrahendRange.Min, min: this.MinuendRange.Min - this.SubtrahendRange.Max);
            if (!finalDifferenceRange.IsValid)
            {
                throw new ArgumentException();
            }
            return null;
        }
    }
}
