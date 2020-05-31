using System;
using System.Collections.Generic;
using System.IO;
using ConsoleWriter;
using ConsoleWriter.Test.Domain;
using Newtonsoft.Json;

namespace ConsoleWriter.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleMovies = LoadMovies();

            ConsoleHelpers.WriteLine("Hello World!");

            ConsoleHelpers.WriteLine("Hello World! in Yellow", ConsoleColor.DarkYellow);
            ConsoleHelpers.WriteInLine("Hello World! partially ");
            ConsoleHelpers.WriteLine("in Yellow", ConsoleColor.DarkYellow);

            sampleMovies.PrintTable();
        
        }



        private static IEnumerable<Movie> LoadMovies()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Movie>>(File.ReadAllText("Domain\\movies.json"));
        }
    }
}
