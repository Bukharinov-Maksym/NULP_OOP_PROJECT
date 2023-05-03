using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    [DataContract]
    public class Horse : Animal
    {
        [XmlElement]
        [DataMember]
        public string Color { get; set; } = null!;
        [XmlElement]
        [DataMember]
        public string Breed { get; set; } = null!;
    }
}
