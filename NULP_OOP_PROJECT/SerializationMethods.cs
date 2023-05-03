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
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            using var sw = new StreamWriter(path);
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, animals, typeof(Animal));

            Log.Debug("Array serialized into .json successfully");
        }
        // Json Deserialization
        public static void JsonDeserialize(string path, Animal[] animals)
        {
            if (animals == null) throw new ArgumentNullException(nameof(animals));
#pragma warning disable CS8600
#pragma warning disable IDE0059
            animals = JsonConvert.DeserializeObject<Animal[]>(File.ReadAllText(path), new Newtonsoft.Json.JsonSerializerSettings
#pragma warning restore IDE0059
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });
#pragma warning restore CS8600
            Log.Debug("Array deserialized from a .json successfully");
        }
    }
}
