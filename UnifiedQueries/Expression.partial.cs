using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnifiedQueries
{
    partial class Expression
    {
        public override string ToString()
        {
            return string.Format("({0} {1} {2})", this.Name,
                this.Operator, this.Value);
        }
    }
}
