using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Models
{
    [DataContract]
    public class Donkey : Animal
    {
        [XmlElement]
        [DataMember]
        public string Type { get; set; } = null!;
        [XmlElement]
        [DataMember]
        public double Height { get; set; }
    }
}
