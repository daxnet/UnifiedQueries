using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnifiedQueries
{
	partial class QuerySpecification
	{
        public override string ToString()
        {
            return this.Item.ToString();
        }
	}
}
