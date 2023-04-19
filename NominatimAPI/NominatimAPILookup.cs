using System;
namespace NominatimAPI
{
	public class NominatimAPILookup : NominatimAPI
	{
		NominatimLookup Lookup;

        public NominatimAPILookup(NominatimLookup _lookup)
		{
			this.Lookup = _lookup;
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
            qList.Add("addressdetails=1");
            qList.Add("extratags=1");
            qList.Add("namedetails=1");
            qList.Add($"format={this.Output[output]}");

            return $"{url}{GetQueryFromList(qList)}";
        }
    }
}

