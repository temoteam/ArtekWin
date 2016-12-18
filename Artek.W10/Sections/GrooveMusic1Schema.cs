using System;
using AppStudio.DataProviders;

namespace Artek.Sections
{
    /// <summary>
    /// Implementation of the GrooveMusic1Schema class.
    /// </summary>
    public class GrooveMusic1Schema : SchemaBase
    {

        public DateTime? ReleaseDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string LabelName { get; set; }

        public string Genre { get; set; }

        public string Link { get; set; }
    }
}
