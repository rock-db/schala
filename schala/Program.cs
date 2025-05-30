using schala;
using CommandLine;
using System;
using CommandLine.Text;



class Options
{
    [Option('v', "verbose", Required = false, HelpText = "Enable verbose output.")]
    public bool Verbose { get; set; }

    [Option('I', "init", Required = false, HelpText = "Initialize a Schala.")]
    public bool Init { get; set; }

}

namespace Schala
{
    class Program
    {
        static string SchalaVersion = "0.1.0-alpha";
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Schala v" + SchalaVersion);
            Console.ResetColor();

            var parser = new Parser(with => with.HelpWriter = null);

            var result = parser.ParseArguments<Options>(args);

            result
                .WithParsed(options =>
                {
                    if (options.Init)
                    {
                        Init.InitializeProject(options.Verbose);
                    }
                    else
                    {
                        Console.WriteLine("No valid command provided. Use --help for more information.");
                    }
                })
                .WithNotParsed(errors =>
                {
                    var helpText = HelpText.AutoBuild<Options>(result, h =>
                    {
                        h.Heading = "";
                        h.Copyright = "Copyright (c) 2025 rock-db";
                        return HelpText.DefaultParsingErrorsHandler(result, h);
                    }, e=>e);

                    Console.WriteLine(helpText);
                });
        }
    }
}


