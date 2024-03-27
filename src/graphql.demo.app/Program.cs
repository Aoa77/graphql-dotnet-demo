namespace graphql.demo.app;

using System;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("==================================");
        Console.WriteLine(Console.Title = " == GraphQL .NET Core Demo App ==");
        Console.WriteLine("==================================");
        Console.WriteLine();

        var schema = Schema.For(@"
          type Query {
              hello: String
          }
        ");

        var root = new { Hello = "Hello World!" };
        var json = await new DocumentExecuter().ExecuteAsync(_ =>
        {
            _.Schema = schema;
            _.Query = "{ hello }";
            _.Root = root;
        });
        var data = (RootExecutionNode?)json.Data;

        Console.WriteLine($@"Query: {json.Query}");
        Console.WriteLine($@"Result: {data!.Result}");

        Console.WriteLine();
        Console.WriteLine("==================================");
        Console.WriteLine("press any key to exit...");
        Console.ReadKey();
    }
}
