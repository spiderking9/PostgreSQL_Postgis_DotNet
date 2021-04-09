using System;
using System.Collections.Generic;

namespace GeoTronic.Models
{
    public partial class Wojewodztwa
    {
        public int Gid { get; set; }
        public string JptSjrKo { get; set; }
        public string JptKodJe { get; set; }
        public string JptNazwa { get; set; }
        public string JptOrgan { get; set; }
        public int? JptJorId { get; set; }
        public DateTime? WersjaOd { get; set; }
        public DateTime? WersjaDo { get; set; }
        public DateTime? WaznyOd { get; set; }
        public DateTime? WaznyDo { get; set; }
        public string JptKod1 { get; set; }
        public string JptNazwa1 { get; set; }
        public string JptOrgan1 { get; set; }
        public string JptWazna { get; set; }
        public decimal? IdBufora { get; set; }
        public decimal? IdBufora1 { get; set; }
        public int? IdTechnic { get; set; }
        public string IipPrzest { get; set; }
        public string IipIdenty { get; set; }
        public string IipWersja { get; set; }
        public string JptKjIip { get; set; }
        public string JptKjI1 { get; set; }
        public string JptKjI2 { get; set; }
        public string JptOpis { get; set; }
        public string JptSpsKo { get; set; }
        public int? IdBufor1 { get; set; }
        public int? JptId { get; set; }
        public string JptKjI3 { get; set; }
        public decimal? ShapeLeng { get; set; }
        public decimal? ShapeArea { get; set; }
        public string Geom { get; set; }
    }
}
