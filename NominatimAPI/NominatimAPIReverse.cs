using System;
using NetTopologySuite.Features;

namespace NominatimAPI
{
    public class NominatimAPIReverse: NominatimAPI
    {
        NominatimReverse? Reverse;
        public NominatimAPIReverse(NominatimReverse _reverse)
        {
            this.Reverse = _reverse;
        }

        public override string GetUrl(EOutuputFormat ouput)
        {
            List<string> qList = new();
            string url = $"{this.Url}/reverse";

            qList.Add($"lat={this.Reverse!.Lat}");
            qList.Add($"lon={this.Reverse!.Lon}");
            qList.Add("addressdetails=1");
            qList.Add("extratags=1");
            qList.Add("namedetails=1");
            qList.Add($"format={this.Output[ouput]}");

            return $"{url}{GetQueryFromList(qList)}";
        }

    }
}

