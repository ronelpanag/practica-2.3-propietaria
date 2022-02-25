using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dgii.Models
{
    public class Reporte
    {
        public int Formato { get; set; }
        public string Identificacion { get; set; } = ""; 
        public int Periodo { get; set; }
        public int CantidadRegistros { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public DateTime FechaCarga { get; set; }

        [XmlArray("Detalles")]
        [XmlArrayItem("Detalle")]
        public List<Detalle> Detalles { get; set; } = new List<Detalle> { new Detalle() };
        
        [XmlIgnore]
        [JsonIgnore]
        public int IdCarga { get; set; }
    }
}
