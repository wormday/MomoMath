using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormday.MomoMath.Biz
{
    public class QuestionFactory
    {

    }

    public class NumberRange
    {
        public NumberRange(int max=100, int min = 0)
        {
            this.Max = max;
            this.Min = min;
        }

        public int Max { get; set; }
        public int Min { get; set; }
    }

    public class QuestionSetter
    {
        public IList<MathProblem> Create(int quantity)
        {
            BaseQuestionSetter b = new SimpleAdditionQuestionSetter()
            {
                AddendRange = new NumberRange() { Max = 10, Min = 1 },
                SumRange = new NumberRange() { Max = 100, Min=1 },
            };
            IList<MathProblem> result = new List<MathProblem>();
            for (int i = 0; i < quantity; i++)
            {
                result.Add(b.CreateMathProblem());
            }
            return result;
        }
    }

    public abstract class BaseQuestionSetter
    {
        public abstract MathProblem CreateMathProblem();
    }

    /// <summary>
    /// 两个数字的加法
    /// </summary>
    public class SimpleAdditionQuestionSetter : BaseQuestionSetter
    {
        /// <summary>加数范围</summary>
        public NumberRange AddendRange { get; set; }

        /// <summary>和的最大值</summary>
        public NumberRange SumRange { get; set; }

        /// <summary>进位</summary>
        public bool Carry { get; set; }

        /// <summary>可以凑整</summary>
        public bool CanMakeUpRound { get; set; }

        public override MathProblem CreateMathProblem()
        {
            if (this.SumRange.Max < this.AddendRange.Max)
            {
                this.AddendRange = new NumberRange(this.SumRange.Max, this.AddendRange.Min);
            }

            NumberRange addend2Range = new NumberRange()
            {
                Min = this.AddendRange.Min,
                Max = this.SumRange.Max - this.AddendRange.Max,
            };

            int addend1 = RandomCreator.GetRandomNumber(this.AddendRange);
            int addend2 = RandomCreator.GetRandomNumber(addend2Range);
            return new MathProblem() { Problem = string.Format("{0} + {1} = ", addend1, addend2), Except = addend1 + addend2 };
        }
    }

    public static class RandomCreator
    {
        private static Random r = new Random(DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second);
        public static int GetRandomNumber(NumberRange range)
        {
            return r.Next(range.Min, range.Max + 1);
        }
    }

    /// <summary>
    /// 两个数字的减法
    /// </summary>
    public class SimpleSubtractionQuestionSetter
    {

    }

    /// <summary>
    /// 多数字加减混合计算
    /// </summary>
    public class MixedQuestionSetter
    {

    }

    public class MathProblem
    {
        public decimal? Act { get; set; }
        public decimal Except { get; set; }
        public string Problem { get; set; }
    }
}
