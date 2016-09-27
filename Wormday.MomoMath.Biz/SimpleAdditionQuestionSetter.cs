using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormday.MomoMath.Biz
{
    public class SimpleAdditionQuestionSetter : BaseQuestionSetter
    {
        /// <summary>加数范围</summary>
        public NumberRange AddendRange { get; set; }

        /// <summary>结果的范围</summary>
        public NumberRange SumRange { get; set; }

        /// <summary>需要进位</summary>
        public bool Carry { get; set; }

        /// <summary>可以凑整</summary>
        public bool CanMakeUpRound { get; set; }

        /// <summary>
        /// 创建题目
        /// </summary>
        /// <returns></returns>
        public override MathProblem CreateMathProblem()
        {
            NumberRange finalSumRange = SumRange.Intersection(new NumberRange(this.AddendRange.Max * 2, this.AddendRange.Min * 2));
            if (!finalSumRange.IsValid)
            {
                throw new ArgumentException();
            }
            NumberRange finalAddendRange = new NumberRange((int)Math.Ceiling(finalSumRange.Max / 2.0), (int)Math.Floor(finalSumRange.Min / 2.0));
            int addend1 = RandomCreator.GetRandomNumber(new NumberRange((int)Math.Ceiling(finalSumRange.Max / 2.0), (int)Math.Floor(finalSumRange.Min / 2.0)));
            int expected = RandomCreator.GetRandomNumber(new NumberRange(finalAddendRange.Max + addend1 + 1, finalAddendRange.Min + addend1));
            int addend2 = expected - addend1;
            return new MathProblem() { Problem = string.Format("{0} + {1} = ", addend1, addend2), ExpectedAnswer = expected };
        }
    }
}
