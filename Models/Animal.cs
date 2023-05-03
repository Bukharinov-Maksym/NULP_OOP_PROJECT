using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Models
{
    [XmlInclude(typeof(Models.Donkey))]
    [XmlInclude(typeof(Models.Horse))]
    [XmlRoot]
    [KnownType(typeof(Models.Donkey))]
    [KnownType(typeof(Models.Horse))]
    [DataContract]
    public abstract class Animal
    {
        [XmlElement]
        [DataMember]
        public string Name { get; set; } = null!;
        [XmlElement]
        [DataMember]
        public int YearOfBirth { get; set; }
    }
}