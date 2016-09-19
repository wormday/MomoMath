using System;
using System.Collections.Generic;

namespace Wormday.MomoMath.Biz
{
    public class QuestionFactory
    {

    }

    public class NumberRange
    {
        public NumberRange(int max = 100, int min = 0)
        {
            this.Max = max;
            this.Min = min;
        }

        public int Max { get; set; }
        public int Min { get; set; }

        public NumberRange Intersection(NumberRange other)
        {
            int max = Math.Min(this.Max, other.Max);
            int min = Math.Max(this.Min, other.Min);
            return new NumberRange(max, min);
        }
    }

    public class QuestionSetter
    {
        public IList<MathProblem> Create(int quantity)
        {
            BaseQuestionSetter b = new SimpleAdditionQuestionSetter()
            {
                AddendRange = new NumberRange() { Max = 100, Min = 1 },
                SumRange = new NumberRange() { Max = 20, Min = 1 },
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
        /// <summary>
        /// 创建题目
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 创建题目
        /// </summary>
        /// <returns></returns>
        public override MathProblem CreateMathProblem()
        {
            NumberRange finalSumRange = SumRange.Intersection(new NumberRange(this.AddendRange.Max * 2, this.AddendRange.Min * 2));
            if (finalSumRange.Max < finalSumRange.Min)
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

    /// <summary>数学问题</summary>
    public class MathProblem
    {
        /// <summary>实际的答案</summary>
        public decimal? ActualAnswer { get; set; }

        /// <summary>预期的答案</summary>
        public decimal ExpectedAnswer { get; set; }

        /// <summary>问题</summary>
        public string Problem { get; set; }
    }
}
