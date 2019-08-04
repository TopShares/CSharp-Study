using System;

namespace Ruanmou.CoreDemo.Framework
{
    public class JsonHelper
    {
        public T Deserialize<T>(string text)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
        }

        public static string Serialize<T>(T t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }
    }
}
