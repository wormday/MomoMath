using System;
using System.Collections.Generic;

namespace Wormday.MomoMath.Biz
{
    public class QuestionFactory
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
}
