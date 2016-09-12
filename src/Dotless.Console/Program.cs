using System.IO;
using dotless.Core;
using dotless.Core.configuration;

namespace Dotless.Console
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("Usage: Dotless.Core <path to less directory> <less file name>\n\nWrites the output to stdout.");
                return -1;
            }

            var path = args[0];
            var fileName = args[1];

            var config = new DotlessConfiguration();
            var engineFactory = new EngineFactory(config);
            var engine = engineFactory.GetEngine();
            engine.CurrentDirectory = path;

            var filePath = Path.Combine(path, fileName);
            var content = File.ReadAllText(filePath);
            var result = engine.TransformToCss(content, fileName);

            System.Console.WriteLine(result);

            return 0;
        }
    }
}
