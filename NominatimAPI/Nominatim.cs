using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NominatimAPI
{
    public enum EOutuputFormat
    {
        XML,
        JSON,
        JSONV2,
        GEOJSON,
        GEOCODEJSON
    }

    public interface INominatimInterfaceSearch
    {
        string City { get; set; }
        string? Street { get; set; }
        string? Country { get; set; }
        string? County { get; set; }
        string? State { get; set; }
        string? Postalcode { get; set; }
    }

    public interface INominatimReverseInterface
    {
        double Lat { get; set; }
        double Lon { get; set; }
    }

    public interface INominatimLookupInterface
    {
        string Node { get; set; }
        string Relation { get; set; }
        string Way { get; set; }
    }

    public class NominatimSearch : INominatimInterfaceSearch
    {
        public string City { get; set; } = "";
        public string? Street { get; set; }
        public string? Country { get; set; } = "Italy";
        public string? County { get; set; }
        public string? State { get; set; }
        public string? Postalcode { get; set; }
    }

    public class NominatimReverse : INominatimReverseInterface
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class NominatimLookup : INominatimLookupInterface
    {
        public string Node { get; set; } = "N";
        public string Relation { get; set; } = "R";
        public string Way { get; set; } = "W";
    }
}

