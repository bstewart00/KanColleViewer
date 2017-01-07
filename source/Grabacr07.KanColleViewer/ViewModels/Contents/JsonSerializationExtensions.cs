using System.IO;
using Newtonsoft.Json;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
    public static class JsonSerializationExtensions
    {
        public static string ToJson(this object o)
        {
            JsonSerializer jsonSerializer = JsonSerializer.Create(JsonSerializationSettings.Clean);
            using (StringWriter sw = new StringWriter())
            {
                jsonSerializer.Serialize(new JsonTextWriter(sw), o);
                return sw.ToString();
            }
        }
    }
}