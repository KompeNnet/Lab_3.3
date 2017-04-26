using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab_3._3.Helpers
{
    class Serializer
    {
        public static dynamic Serialize(dynamic smth)
        {
            return JsonConvert.SerializeObject(smth);
        }

        public static dynamic Deserialize<T>(dynamic smth)
        {
            return JsonConvert.DeserializeObject<T>(smth);
        }
    }
}
