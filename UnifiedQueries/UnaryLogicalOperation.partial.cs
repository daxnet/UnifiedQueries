using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnifiedQueries
{
    partial class UnaryLogicalOperation
    {
        public override string ToString()
        {
            return string.Format("({0} {1})", this.Operator, this.Item);
        }
    }
}
