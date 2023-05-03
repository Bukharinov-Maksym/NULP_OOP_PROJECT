using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;
using Newtonsoft.Json;
using Serilog;

namespace OOPProject
{
    public class SerializationMethods
    {
        // Json Serialization
        public static void JsonSerialize(string path, Animal[] animals)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            using var sw = new StreamWriter(path);
            using Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);
            serializer.Serialize(writer, animals, typeof(Animal));

            Log.Debug("Array serialized into .json successfully");
        }
        /* Xml Serialization
        public static void XmlSerialize(string path, Animal[] animals)
        {

            var xmlSerializer = new XmlSerializer(typeof(Animal));
            using var fileStream = new FileStream(path, FileMode.Create);
            foreach (var animal in animals)
            {
                xmlSerializer.Serialize(fileStream, animal);
            }
        }*/
        // Json Deserialization
        public static void JsonDeserialize(string path, Animal[] animals)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
#pragma warning disable CS8600
            animals = JsonConvert.DeserializeObject<Animal[]>(File.ReadAllText(path), new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });
#pragma warning restore CS8600
            Log.Debug("Array deserialized from a .json successfully");
        }
    }
}
