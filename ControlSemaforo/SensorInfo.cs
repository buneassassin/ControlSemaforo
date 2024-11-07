using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControlSemaforo
{
    public class SensorInfo
    {
        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }


        [JsonProperty("Unidad")]
        public string Unidad {  get; set; }
    }

    public class Root 
    {
        public Dictionary<string, SensorInfo> Sensores { get; set; }
    }

}
