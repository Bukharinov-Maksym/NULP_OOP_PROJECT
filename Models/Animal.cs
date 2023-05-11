using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Models
{
    [KnownType(typeof(Models.Donkey))]
    [KnownType(typeof(Models.Horse))]
    [DataContract]
    public abstract class Animal
    {
        [DataMember]
        public string Name { get; set; } = null!;
        [DataMember]
        public int YearOfBirth { get; set; }
    }
}