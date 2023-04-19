using System;
using NetTopologySuite.Features;

namespace NominatimAPI
{
	public class NominatimAPISearch : NominatimAPI
    {
        public NominatimSearch? Search;

        public NominatimAPISearch(NominatimSearch _search)
		{
            this.Search = _search;
		}

        public override string GetUrl(EOutuputFormat output)
        {
            List<string> qList = new();
            string url = $"{this.Url}/search";

            if (this.Search!.Street is not null)
                qList.Add($"street={this.Search.Street}");

            if (this.Search.City is not null)
                qList.Add($"city={this.Search.City}");

            if (this.Search.County is not null)
                qList.Add($"county={this.Search.County}");

            if (this.Search!.Country is not null)
                qList.Add($"country={this.Search.Country}");

            if (this.Search!.Postalcode is not null)
                qList.Add($"postalcode={this.Search.Postalcode}");

            qList.Add("polygon_svg=1");
            qList.Add("addressdetails=1");
            qList.Add("extratags=1");
            qList.Add("namedetails=1");
            qList.Add($"format={this.Output[output]}");

            return $"{url}{GetQueryFromList(qList)}";
        }
    }
}