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

    public class QuestionSetter
    {
        public IList<MathProblem> Create(int quantity)
        {
            IList<MathProblem> result = new List<MathProblem>();
            for (int i = 0; i < quantity; i++)
            {
                result.Add(new MathProblem() { Problem="1+1",Except=2});
            }
            return result;
        }
    }

    public class Addition2FiguresQuestionSetter
    {

    }

    public class MathProblem
    {
        public decimal? Act { get; set; }
        public decimal Except { get; set; }
        public string Problem { get; set; }
    }
}
