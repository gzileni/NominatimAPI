using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace NominatimAPI
{
    [XmlRoot(ElementName = "LinearRing")]
    public class LinearRing
    {
        [XmlElement(ElementName = "coordinates")]
        public string? Coordinates { get; set; }
    }

    [XmlRoot(ElementName = "outerBoundaryIs")]
    public class OuterBoundaryIs
    {
        [XmlElement(ElementName = "LinearRing")]
        public LinearRing? LinearRing { get; set; }
    }

    [XmlRoot(ElementName = "Polygon")]
    public class Polygon
    {
        [XmlElement(ElementName = "outerBoundaryIs")]
        public OuterBoundaryIs? OuterBoundaryIs { get; set; }
    }

    [XmlRoot(ElementName = "geokml")]
    public class Geokml
    {
        [XmlElement(ElementName = "Polygon")]
        public Polygon? Polygon { get; set; }
    }

    [XmlRoot(ElementName = "place")]
    public class Place
    {
        [XmlElement(ElementName = "geokml")]
        public Geokml? Geokml { get; set; }
        [XmlElement(ElementName = "house_number")]
        public string? House_number { get; set; }
        [XmlElement(ElementName = "road")]
        public string? Road { get; set; }
        [XmlElement(ElementName = "village")]
        public string? Village { get; set; }
        [XmlElement(ElementName = "town")]
        public string? Town { get; set; }
        [XmlElement(ElementName = "city")]
        public string? City { get; set; }
        [XmlElement(ElementName = "county")]
        public string? County { get; set; }
        [XmlElement(ElementName = "postcode")]
        public string? Postcode { get; set; }
        [XmlElement(ElementName = "country")]
        public string? Country { get; set; }
        [XmlElement(ElementName = "country_code")]
        public string? Country_code { get; set; }
        [XmlAttribute(AttributeName = "place_id")]
        public string? Place_id { get; set; }
        [XmlAttribute(AttributeName = "osm_type")]
        public string? Osm_type { get; set; }
        [XmlAttribute(AttributeName = "osm_id")]
        public string? Osm_id { get; set; }
        [XmlAttribute(AttributeName = "boundingbox")]
        public string? Boundingbox { get; set; }
        [XmlAttribute(AttributeName = "lat")]
        public string? Lat { get; set; }
        [XmlAttribute(AttributeName = "lon")]
        public string? Lon { get; set; }
        [XmlAttribute(AttributeName = "display_name")]
        public string? Display_name { get; set; }
        [XmlAttribute(AttributeName = "class")]
        public string? Class { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }
        [XmlElement(ElementName = "state_district")]
        public string? State_district { get; set; }
        [XmlElement(ElementName = "state")]
        public string? State { get; set; }
        [XmlAttribute(AttributeName = "place_rank")]
        public string? Place_rank { get; set; }
        [XmlAttribute(AttributeName = "address_rank")]
        public string? Address_rank { get; set; }
        [XmlAttribute(AttributeName = "importance")]
        public string? Importance { get; set; }
        [XmlElement(ElementName = "tourism")]
        public string? Tourism { get; set; }
        [XmlElement(ElementName = "suburb")]
        public string? Suburb { get; set; }
    }

    [XmlRoot(ElementName = "searchresults")]
    public class SearchResultsXML
    {
        [XmlElement(ElementName = "place")]
        public Place? Place { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string? Timestamp { get; set; }
        [XmlAttribute(AttributeName = "querystring")]
        public string? Querystring { get; set; }
        [XmlAttribute(AttributeName = "polygon")]
        public string? Polygon { get; set; }
    }

    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlAttribute(AttributeName = "place_id")]
        public string? Place_id { get; set; }
        [XmlAttribute(AttributeName = "osm_type")]
        public string? Osm_type { get; set; }
        [XmlAttribute(AttributeName = "osm_id")]
        public string? Osm_id { get; set; }
        [XmlText]
        public string? Text { get; set; }
    }

    [XmlRoot(ElementName = "addressparts")]
    public class Addressparts
    {
        [XmlElement(ElementName = "house_number")]
        public string? House_number { get; set; }
        [XmlElement(ElementName = "road")]
        public string? Road { get; set; }
        [XmlElement(ElementName = "village")]
        public string? Village { get; set; }
        [XmlElement(ElementName = "town")]
        public string? Town { get; set; }
        [XmlElement(ElementName = "city")]
        public string? City { get; set; }
        [XmlElement(ElementName = "county")]
        public string? County { get; set; }
        [XmlElement(ElementName = "postcode")]
        public string? Postcode { get; set; }
        [XmlElement(ElementName = "country")]
        public string? Country { get; set; }
        [XmlElement(ElementName = "country_code")]
        public string? Country_code { get; set; }
    }

    [XmlRoot(ElementName = "reversegeocode")]
    public class ReverseGeocodeXML
    {
        [XmlElement(ElementName = "result")]
        public Result? Result { get; set; }
        [XmlElement(ElementName = "addressparts")]
        public Addressparts? Addressparts { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string? Timestamp { get; set; }
        [XmlAttribute(AttributeName = "querystring")]
        public string? Querystring { get; set; }
    }

    [XmlRoot(ElementName = "lookupresults")]
    public class LookupResultsXML
    {
        [XmlElement(ElementName = "place")]
        public List<Place>? Place { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string? Timestamp { get; set; }
        [XmlAttribute(AttributeName = "attribution")]
        public string? Attribution { get; set; }
        [XmlAttribute(AttributeName = "querystring")]
        public string? Querystring { get; set; }
        [XmlAttribute(AttributeName = "more_url")]
        public string? More_url { get; set; }
    }
}