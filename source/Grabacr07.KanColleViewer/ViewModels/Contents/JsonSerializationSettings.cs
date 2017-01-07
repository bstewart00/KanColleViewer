using Newtonsoft.Json;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
    public class JsonSerializationSettings
    {
        public static JsonSerializerSettings Clean => new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };
    }
}
