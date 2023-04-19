using System;
using NetTopologySuite.Features;
using System.Net.Http;
using System.Collections.Specialized;
using NetTopologySuite.Index.HPRtree;
using NetTopologySuite.IO;
using Newtonsoft.Json;

namespace NominatimAPI
{
    public class NominatimAPI
    {
		public string Path { get; set; } = "";
		public string Url { get; set; } = "https://nominatim.openstreetmap.org";
        public Dictionary<EOutuputFormat, string> Output = new()
        {
            { EOutuputFormat.XML, "xml" },
            { EOutuputFormat.JSON, "json" },
            { EOutuputFormat.GEOJSON, "geojson" }
        };

        public NominatimAPI(string? _url = null)
		{
            if (!string.IsNullOrEmpty(_url))
                this.Url = _url;
        }

        protected static FeatureCollection? DeSerializeFeatureCollection(string? features)
        {
            if (features is not null)
            {
                var serializer = GeoJsonSerializer.Create();
                using (var stringReader = new StringReader(features))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    return serializer.Deserialize<FeatureCollection>(jsonReader);
                }
            }

            return null;
        }

        private static string ToQueryString(Dictionary<string, string> query, string? prefix = null)
        {
            string result = prefix is null ? "?" : $"?{prefix}=";
            List<string> qList = query.Select(x => {
                if (!string.IsNullOrEmpty(x.Value))
                    return string.Format("{0}={1}", x.Key, x.Value);
                else
                    return "";
             }).Where(x => !string.IsNullOrEmpty(x))
               .ToList();

            for (var i = 0; i < qList.Count; i++)
            {
                result += qList[i];
                if (i < qList.Count - 1)
                    result += "&";
            }

            return result;
        }

        protected static async Task<string> GetData(string url,
                                                    Dictionary<string, string> query,
                                                    string? prefix = null)
        {
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(15)
            };

            string q = $"{url}{ToQueryString(query, prefix)}";
            using HttpClient client = new(handler);
            using HttpResponseMessage response = await client.GetAsync(q);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("Non sono riuscito a leggere i dati");
        }
    }
}

