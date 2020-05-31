using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleWriter.Test.Domain
{
    /// <summary>
    /// A line of data from the movies csv saple file
    /// </summary>
    public class Movie
    {
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Runtime { get; set; }
        public long Budget { get; set; }
        public long Revenue { get; set; }


        public string Language { get; set; }
        public string Genres { get; set; }
        public string Keywords { get; set; }

        public decimal Rating { get; set; }
        public int Votes { get; set; }

    }
}
