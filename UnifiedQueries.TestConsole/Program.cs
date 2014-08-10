using System;

namespace UnifiedQueries.TestConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            var querySpecification = QuerySpecification.LoadFromFile("QuerySpecificationSample.xml");

            
        }
    }

    class PrintNameVisitor : QuerySpecificationVisitor
    {
        public PrintNameVisitor(QuerySpecification spec) : base(spec) { }

        protected override void VisitExpression(Expression expression)
        {
            Console.WriteLine(expression.Name);
        }

        protected override void VisitLogicalOperation(LogicalOperation logicalOperation)
        {
            //throw new NotImplementedException();
        }

        protected override void VisitUnaryLogicalOperation(UnaryLogicalOperation unaryLogicalOperation)
        {
            //throw new NotImplementedException();
        }
    }

}
