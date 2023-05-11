using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Models
{
    [DataContract]
    public class Donkey : Animal
    {
        [DataMember]
        public string Type { get; set; } = null!;
        [DataMember]
        public double Height { get; set; }
    }
}
