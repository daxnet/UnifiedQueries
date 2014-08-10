using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable CheckNamespace
namespace UnifiedQueries
    // ReSharper restore CheckNamespace
{
	partial class QuerySpecification
	{
        public override string ToString()
        {
            return this.Item.ToString();
        }
	}
}
