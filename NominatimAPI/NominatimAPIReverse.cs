using System;
using System.Xml.Serialization;
using NetTopologySuite.Features;

namespace NominatimAPI
{
    public interface INominatimAPIReverseInterface : INominatimAPIInterface
    {
        void SetLimitation(ReverseResultLimitation? _limitations = null);
        void SetParameters(NominatimReverse _reverse);
        abstract Task<ReverseGeocodeXML?> ToXml();
    }

    public class NominatimAPIReverse: NominatimAPI, INominatimAPIReverseInterface
    {
        public NominatimReverse? Reverse;
        public ReverseResultLimitation? Limitations;

        public NominatimAPIReverse()
        {
        }

        public void SetLimitation(ReverseResultLimitation? _limitations = null) => this.Limitations = _limitations;
        public void SetParameters(NominatimReverse _reverse) => this.Reverse = _reverse;

        protected static ReverseGeocodeXML? DeSerializeToXML(string xml)
        {
            var serializer = new XmlSerializer(typeof(ReverseGeocodeXML));
            ReverseGeocodeXML? result;

            using (TextReader reader = new StringReader(xml))
            {
                result = (ReverseGeocodeXML?)serializer.Deserialize(reader);
            }

            return result;
        }

        private void SetResultLimitations(ref List<string> qList)
        {
            if (this.Limitations is not null)
                qList.Add($"zoom={this.Limitations.Zoom}");
        }

        public override string GetUrl(EOutuputFormat output)
        {
            List<string> qList = new();
            string url = $"{this.Url}/reverse";

            qList.Add($"lat={this.Reverse!.Lat}");
            qList.Add($"lon={this.Reverse!.Lon}");

            /** result limitation */
            this.SetResultLimitations(ref qList);
            this.SetOutputDetails(ref qList);
            this.SetPolygonOutput(ref qList);
            this.SetFormatOutput(ref qList, output);

            return $"{url}{GetQueryFromList(qList)}";
        }

        public override async Task<NominatimResponse[]?> ToJson()
        {
            string url = this.GetUrl(EOutuputFormat.JSON);
            string result = $"[{await GetData(url)}]";
            return DeSerializeToJsonArray(result);
        }

        public virtual async Task<ReverseGeocodeXML?> ToXml()
        {
            string url = this.GetUrl(EOutuputFormat.XML);
            string result = await GetData(url);
            return DeSerializeToXML(result);
        }

    }
}

