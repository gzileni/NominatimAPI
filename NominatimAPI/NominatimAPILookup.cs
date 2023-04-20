using System;
using System.Xml.Serialization;

namespace NominatimAPI
{
	public class NominatimAPILookup : NominatimAPI
	{
		NominatimLookup Lookup;

        public NominatimAPILookup(NominatimLookup _lookup)
		{
			this.Lookup = _lookup;
		}

        protected static LookupResultsXML? DeSerializeToXML(string xml)
        {
            var serializer = new XmlSerializer(typeof(LookupResultsXML));
            LookupResultsXML? result;

            using (TextReader reader = new StringReader(xml))
            {
                result = (LookupResultsXML?)serializer.Deserialize(reader);
            }

            return result;
        }

        public override string GetUrl(EOutuputFormat output)
        {
            List<string> qList = new();
            string url = $"{this.Url}/lookup";

            string? qIDS = null;

            if (this.Lookup.Node is not null)
                qIDS += $"N{this.Lookup.Node}";
            if (this.Lookup.Way is not null)
            {
                if (qIDS is not null)
                    qIDS += ",";
                qIDS += $"W{this.Lookup.Way}";
            }
                
            if (this.Lookup.Relation is not null)
            {
                if (qIDS is not null)
                    qIDS += ",";
                qIDS += $"R{this.Lookup.Relation}";
            }

            qList.Add($"osm_ids={qIDS}");

            this.SetOutputDetails(ref qList);
            this.SetPolygonOutput(ref qList);
            this.SetFormatOutput(ref qList, output);

            return $"{url}{GetQueryFromList(qList)}";
        }

        public virtual async Task<LookupResultsXML?> ToXml()
        {
            string url = this.GetUrl(EOutuputFormat.XML);
            string result = await GetData(url);
            return DeSerializeToXML(result);
        }
    }
}

