using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Models
{
    [DataContract]
    public class Horse : Animal
    {
        [DataMember]
        public string Color { get; set; } = null!;
        [DataMember]
        public string Breed { get; set; } = null!;
    }
}
