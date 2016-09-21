using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormday.MomoMath.Biz
{
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
