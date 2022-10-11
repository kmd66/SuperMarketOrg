namespace Kama.Organization.API.Tools
{
    public class ObjectSerializer : AppCore.IObjectSerializer
    {
        public T Deserialize<T>(string serializedValue)
            => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(serializedValue);

        public string Serialize(object obj)
        {
            if (obj == null)
                return null;

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}