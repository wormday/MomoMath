using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormday.MomoMath.Biz
{
    public abstract class BaseQuestionSetter
    {
        /// <summary>
        /// 创建题目
        /// </summary>
        /// <returns></returns>
        public abstract MathProblem CreateMathProblem();
    }
}
