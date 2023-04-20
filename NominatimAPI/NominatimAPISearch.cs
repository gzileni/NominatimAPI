using System;
using System.IO;
using System.Xml.Serialization;
using NetTopologySuite.Features;

namespace NominatimAPI
{
	public class NominatimAPISearch : NominatimAPI
    {
        public NominatimSearch? Search;
        public SearchResultLimitation? Limitations;

        public NominatimAPISearch(NominatimSearch _search, SearchResultLimitation? _limitations = null)
		{
            this.Search = _search;
            this.Limitations = _limitations;
		}

        protected static SearchResultsXML? DeSerializeToXML(string xml)
        {
            var serializer = new XmlSerializer(typeof(SearchResultsXML));
            SearchResultsXML? result;

            using (TextReader reader = new StringReader(xml))
            {
                result = (SearchResultsXML?)serializer.Deserialize(reader);
            }

            return result;
        }

        private void SetResultLimitations(ref List<string> qList)
        {
            if (this.Limitations is not null)
            {
                qList.Add($"limit={this.Limitations.Limit}");
                qList.Add($"bounded={this.Limitations.Bounded}");

                if (this.Limitations.ViewBox is not null && this.Limitations.ViewBox.Count > 0)
                {
                    string viewBox = "";
                    for (var i = 0; i < this.Limitations.ViewBox.Count; i++)
                    {
                        viewBox += this.Limitations.ViewBox[i].ToString();
                        if (i < this.Limitations.ViewBox.Count - 1)
                            viewBox += ",";
                    };
                    qList.Add($"viewbox={viewBox}");
                }

                if (this.Limitations.ExcludePlaceIds is not null && this.Limitations.ExcludePlaceIds.Count > 0)
                {
                    string excludeIds = "";
                    for (var i = 0; i < this.Limitations.ExcludePlaceIds.Count; i++)
                    {
                        excludeIds += this.Limitations.ExcludePlaceIds[i].ToString();
                        if (i < this.Limitations.ExcludePlaceIds.Count - 1)
                            excludeIds += ",";
                    };
                    qList.Add($"exclude_place_ids={excludeIds}");
                }

                if (this.Limitations.CountryCodes is not null && this.Limitations.CountryCodes.Count > 0)
                {
                    string countryCodes = "";
                    for (var i = 0; i < this.Limitations.CountryCodes.Count; i++)
                    {
                        countryCodes += this.Limitations.CountryCodes[i].ToLower();
                        if (i < this.Limitations.CountryCodes.Count - 1)
                            countryCodes += ",";
                    };
                    qList.Add($"countrycodes={countryCodes}");
                }

                if (this.Limitations.Email is not null)
                    qList.Add($"email={this.Limitations.Email}");

            }
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

            /** result limitation */
            this.SetResultLimitations(ref qList);
            /** set output details */
            this.SetOutputDetails(ref qList);
            this.SetPolygonOutput(ref qList);
            this.SetFormatOutput(ref qList, output);

            return $"{url}{GetQueryFromList(qList)}";
        }

        public virtual async Task<SearchResultsXML?> ToXml()
        {
            string url = this.GetUrl(EOutuputFormat.XML);
            string result = await GetData(url);
            return DeSerializeToXML(result);
        }
    }
}