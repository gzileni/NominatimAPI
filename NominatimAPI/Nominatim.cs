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
        int? Node { get; set; }
        int? Relation { get; set; }
        int? Way { get; set; }
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
        public int? Node { get; set; }
        public int? Relation { get; set; }
        public int? Way { get; set; }
    }

    public class NominatimAddress
    {
        [JsonPropertyName("city")]
        public string? City { get; set; }
        [JsonPropertyName("city_district")]
        public string? CityDistrict { get; set; }
        [JsonPropertyName("construction")]
        public string? Construction { get; set; }
        [JsonPropertyName("continent")]
        public string? Continent { get; set; }
        [JsonPropertyName("country")]
        public string? Country { get; set; }
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }
        [JsonPropertyName("house_number")]
        public string? HouseNumber { get; set; }
        [JsonPropertyName("neighbourhood")]
        public string? Neighbourhood { get; set; }
        [JsonPropertyName("postcode")]
        public string? Postcode { get; set; }
        [JsonPropertyName("public_building")]
        public string? PublicBuilding { get; set; }
        [JsonPropertyName("state")]
        public string? State { get; set; }
        [JsonPropertyName("suburb")]
        public string? Suburb { get; set; }
        [JsonPropertyName("road")]
        public string? Road { get; set; }
        [JsonPropertyName("village")]
        public string? Village { get; set; }
        [JsonPropertyName("state_district")]
        public string? StateDistrict { get; set; }
    }

    public class NominatinResponse
    {
        [JsonPropertyName("address")]
        public NominatimAddress? Address { get; set; }
        [JsonPropertyName("boundingbox")]
        public string[]? BoundingBox { get; set; }
        [JsonPropertyName("class")]
        public string? Class { get; set; }
        [JsonPropertyName("display_name")]
        public string? DisplayName { get; set; }
        [JsonPropertyName("importance")]
        public string? Importance { get; set; }
        [JsonPropertyName("lat")]
        public string? Lat { get; set; }
        [JsonPropertyName("lon")]
        public string? Lon { get; set; }
        [JsonPropertyName("license")]
        public string? License { get; set; }
        [JsonPropertyName("osm_id")]
        public string? OsmId { get; set; }
        [JsonPropertyName("osm_type")]
        public string? OsmType { get; set; }
        [JsonPropertyName("place_id")]
        public string? PlaceId { get; set; }
        [JsonPropertyName("svg")]
        public string? Svg { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("place_rank")]
        public string? PlaceRank { get; set; }
        [JsonPropertyName("category")]
        public string? Category { get; set; }
        [JsonPropertyName("addresstype")]
        public string? AddressType { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
