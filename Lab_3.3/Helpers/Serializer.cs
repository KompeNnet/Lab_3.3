using Newtonsoft.Json;

namespace Lab_3._3.Helpers
{
    class Serializer
    {
        public static string Serialize(dynamic smth)
        {
            return JsonConvert.SerializeObject(smth);
        }

        public static dynamic Deserialize<T>(dynamic smth)
        {
            return JsonConvert.DeserializeObject<T>(smth);
        }
    }
}