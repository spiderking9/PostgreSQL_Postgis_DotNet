using System;
using System.Collections.Generic;

namespace GeoTronic.Models
{
    public partial class PointcloudFormats
    {
        public int Pcid { get; set; }
        public int? Srid { get; set; }
        public string Schema { get; set; }
    }
}
