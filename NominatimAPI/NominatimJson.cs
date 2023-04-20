using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NominatimAPI
{
    public class NominatimExtraTags
    {
        [JsonPropertyName("image")]
        public string? Image { get; set; }
        [JsonPropertyName("heritage")]
        public string? Heritage { get; set; }
        [JsonPropertyName("wikidata")]
        public string? Wikidata { get; set; }
        [JsonPropertyName("architect")]
        public string? Architect { get; set; }
        [JsonPropertyName("wikipedia")]
        public string? Wikipedia { get; set; }
        [JsonPropertyName("wheelchair")]
        public string? Wheelchair { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("heritage:website")]
        public string? HeritageWebsite { get; set; }
        [JsonPropertyName("heritage:operator")]
        public string? HeritageOperator { get; set; }
        [JsonPropertyName("architect:wikidata")]
        public string? ArchitectWikidata { get; set; }
        [JsonPropertyName("year_of_construction")]
        public string? YearOfConstruction { get; set; }
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
        [JsonPropertyName("tourism")]
        public string? Tourism { get; set; }
    }

    public class NominatimResponse
    {
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
        [JsonPropertyName("address")]
        public NominatimAddress? Address { get; set; }
        [JsonPropertyName("extratags")]
        public NominatimExtraTags? ExtraTags { get; set; }
    }
}

