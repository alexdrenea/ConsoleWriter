using System;
using ConsoleWriter;

namespace ConsoleWriter.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelpers.WriteLine("Hello World!");

            ConsoleHelpers.WriteLine("Hello World! in Yellow", ConsoleColor.DarkYellow);

            ConsoleHelpers.WriteInLine("Hello World! partially ");
            ConsoleHelpers.WriteLine("in Yellow", ConsoleColor.DarkYellow);

        }
    }
}
