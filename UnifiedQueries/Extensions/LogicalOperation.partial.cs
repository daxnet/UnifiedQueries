using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable CheckNamespace
namespace UnifiedQueries
    // ReSharper restore CheckNamespace
{
    partial class LogicalOperation
    {
        public override string ToString()
        {
            return string.Format("({0} {1} {2})", this.Item, this.Operator, this.Item1);
        }
    }
}
