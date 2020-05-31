using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleWriter
{
    public static class ConsoleTable
    {
        public static void PrintTable<T>(this IEnumerable<T> objects)
        {
            var maxColumnWidth = 16;

            //todo paging
            var props = typeof(T).GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var headers = props.Select((p, i) => new Column(p.Name, i)).ToArray();
            var data = objects.Select(o => props.ToDictionary(k => k.Name, v => v.GetValue(o)?.ToString() ?? ""));
            if (!data.Any())
            {
                System.Console.WriteLine("no results");
                return;
            }

            //Calculate width of column by looking at the length of each value in that column and calculate the max (applying the predefined max width)
            var dataByProp = data.SelectMany(k => k).GroupBy(k => k.Key, v => v.Value).ToDictionary(k => k.Key, v => v);

            foreach (var h in headers)
            {
                var dataLen = dataByProp[h.Name].Max(k => k.Length);
                h.Width = Math.Min(maxColumnWidth, Math.Max(h.Width, dataLen));
            }

            //Calculate the total size of the table line
            var lineLength = 1 + headers.Sum(h => h.Width + 1);
            var line = "".PadRight(lineLength, '-');

            //Line
            System.Console.WriteLine(line);

            //Header
            System.Console.Write('|');
            foreach (var h in headers)
            {
                System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.Write(h.Name.TrimToLength(h.Width));
                System.Console.ResetColor();
                System.Console.Write('|');
            }
            System.Console.WriteLine();

            //Line
            System.Console.WriteLine(line);

            //Data
            foreach (var d in data)
            {
                System.Console.Write('|');
                foreach (var kvp in d)
                    System.Console.Write(kvp.Value.TrimToLength(headers.FirstOrDefault(h => h.Name == kvp.Key).Width, ' ') + "|");
                System.Console.WriteLine();
            }


            //Line
            System.Console.WriteLine(line);

        }


        private static string TrimToLength(this string s, int length, char paddingChar = ' ')
        {
            if (s.Length > length)
                return s.Substring(0, length - 3) + "...";

            return s.PadRight(length, paddingChar);
        }
    }

    class Column
    {
        public Column(string name, int order = 0)
        {
            Name = name;
            Width = Name.Length;
            Order = order;
        }

        public string Name { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
    }
}
