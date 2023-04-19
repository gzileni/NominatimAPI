using System;
using NetTopologySuite.Features;

namespace NominatimAPI
{
	public interface INominatimAPISearchInterface
	{
        abstract Task<FeatureCollection?> Search(NominatimSearch search);
    };

	public class NominatimAPISearch : NominatimAPI, INominatimAPISearchInterface
    {
		public NominatimAPISearch(string? _url = null) : base(_url)
		{
		}

        private static Dictionary<string, string> GetQuery(NominatimSearch search)
        {
            Dictionary<string, string> query = new Dictionary<string, string>()
            {
                { "street", search.Street is not null ? search.Street : "" },
                { "city", search.City is not null ? search.City : "" },
                { "county", search.County is not null ? search.County : "" },
                { "state", search.State is not null ? search.State : "" },
                { "country", search.Country is not null ? search.Country : "" },
                { "postalcode", search.Postalcode is not null ? search.Postalcode : "" }
            };

            return query;
        }

        public virtual async Task<FeatureCollection?> Search(NominatimSearch search)
        {
            Dictionary<string, string> query = GetQuery(search);
            query.Add("format", this.Output[EOutuputFormat.GEOJSON]);

            string url = $"{this.Url}/search";
            string result = await GetData(url, query, "q");
            return DeSerializeFeatureCollection(result);
        }
    }
}