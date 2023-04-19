using System;
using NetTopologySuite.Features;
using System.Net.Http;
using System.Collections.Specialized;
using NetTopologySuite.Index.HPRtree;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace NominatimAPI
{
    public abstract class NominatimAPI
    {
		public string Path { get; set; } = "";
		public string Url { get; set; } = "https://nominatim.openstreetmap.org";

        public Dictionary<EOutuputFormat, string> Output = new()
        {
            { EOutuputFormat.XML, "xml" },
            { EOutuputFormat.JSON, "json" },
            { EOutuputFormat.GEOJSON, "geojson" }
        };

        public NominatimAPI() {}

        private static FeatureCollection? DeSerializeFeatureCollection(string? features)
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

        private static NominatinResponse[]? DeSerializeToJsonArray(string? features)
        {
            if (features is not null)
            {
                var serializer = GeoJsonSerializer.Create();
                using (var stringReader = new StringReader(features))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    return serializer.Deserialize<NominatinResponse[]>(jsonReader);
                }
            }

            return null;
        }

        private static NominatinResponse? DeSerializeToJson(string? features)
        {
            if (features is not null)
            {
                var serializer = GeoJsonSerializer.Create();
                using (var stringReader = new StringReader(features))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    return serializer.Deserialize<NominatinResponse>(jsonReader);
                }
            }

            return null;
        }

        protected static string GetQueryFromList(List<string> query)
        {
            string result = "?";

            for (var i = 0; i < query.Count; i++)
            {
                result += query[i];
                if (i < query.Count - 1)
                    result += "&";
            }

            return result;
        }

        protected static async Task<string> GetData(string url)
        {
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(15)
            };

            var productValue = new ProductInfoHeaderValue("NominatimAPI", "1.0");

            using HttpClient client = new(handler);
            client.DefaultRequestHeaders.UserAgent.Add(productValue);
            using HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("Non sono riuscito a leggere i dati");
        }

        public abstract string GetUrl(EOutuputFormat output);

        protected static async Task<FeatureCollection?> GetFeatures(string url)
        {
            string result = await GetData(url);
            return DeSerializeFeatureCollection(result);
        }

        public virtual async Task<FeatureCollection?> Features()
        {
            string url = this.GetUrl(EOutuputFormat.GEOJSON);
            return await GetFeatures(url);
        }

        public virtual async Task<NominatinResponse[]?> ToJsonArray()
        {
            string url = this.GetUrl(EOutuputFormat.JSON);
            string result = await GetData(url);
            return DeSerializeToJsonArray(result);
        }

        public virtual async Task<NominatinResponse?> ToJson()
        {
            string url = this.GetUrl(EOutuputFormat.JSON);
            string result = await GetData(url);
            return DeSerializeToJson(result);
        }
    }
}

