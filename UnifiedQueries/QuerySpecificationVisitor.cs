using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnifiedQueries
{
    public abstract class QuerySpecificationVisitor
    {
        private readonly QuerySpecification querySpecification;

        protected QuerySpecificationVisitor(QuerySpecification querySpecification)
        {
            this.querySpecification = querySpecification;
        }

        protected QuerySpecification QuerySpecification
        {
            get { return this.querySpecification; }
        }

        public void Visit()
        {
            if (this.querySpecification.Item == null)
                throw new InvalidOperationException("Can't visit the query specification as there is no items defined under it.");
            ProcessItem(this.querySpecification.Item);
        }

        private void ProcessItem(object item)
        {
            if (item is Expression)
                VisitExpression(item as Expression);
            else if (item is LogicalOperation)
                ProcessOperation(item as LogicalOperation);
            else if (item is UnaryLogicalOperation)
                ProcessOperation(item as UnaryLogicalOperation);
            else
                throw new InvalidOperationException("Can't process the item under query specification as its type is neither Expression, LogicalOperation, nor UnaryLogicalOperation.");
        }

        private void ProcessOperation(UnaryLogicalOperation unaryLogicalOperation)
        {
            VisitUnaryLogicalOperation(unaryLogicalOperation);
            ProcessItem(unaryLogicalOperation.Item);
        }

        private void ProcessOperation(LogicalOperation logicalOperation)
        {
            VisitLogicalOperation(logicalOperation);
            ProcessItem(logicalOperation.Item);
            ProcessItem(logicalOperation.Item1);
        }

        protected abstract void VisitExpression(Expression expression);

        protected abstract void VisitLogicalOperation(LogicalOperation logicalOperation);

        protected abstract void VisitUnaryLogicalOperation(UnaryLogicalOperation unaryLogicalOperation);
    }
}
