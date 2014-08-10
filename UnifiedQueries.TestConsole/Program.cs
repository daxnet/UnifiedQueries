namespace UnifiedQueries.TestConsole
{
    using System;
    using UnifiedQueries.Compilers;

    class Program
    {
        static void Main(string[] args)
        {
            var querySpecification = QuerySpecification.LoadFromFile("QuerySpecificationSample.xml");
            var compiler = new SqlWhereClauseCompiler(true);
            Console.WriteLine(compiler.Compile(querySpecification));
        }
    }
}
