using NominatimAPI;
using NetTopologySuite.Features;

NominatimSearch searchData = new()
{
    City = "Gioia del Colle"
};

/** setup search response limit */
/** Info: https://nominatim.org/release-docs/develop/api/Search/#result-limitation */
SearchResultLimitation searchLimit = new SearchResultLimitation()
{
    Limit = 1,
    Bounded = 0,
    CountryCodes = new List<string>()
    {
        "it"
    },
    ExcludePlaceIds = null,
    ViewBox = null
};

NominatimReverse reverseData = new()
{
    Lat = 40.798838,
    Lon = 16.921660
};

/** setup reverse response limitation */
/** Info: https://nominatim.org/release-docs/develop/api/Reverse/#result-limitation */
ReverseResultLimitation reverseLimit = new ReverseResultLimitation()
{
    Zoom = 18
};

NominatimLookup lookupData = new()
{
    Relation = 146656,
    Way = 104393803,
    Node = 240109189
};

NominatimAPISearch search = new(searchData, searchLimit);
NominatimAPIReverse reverse = new(reverseData, reverseLimit);
NominatimAPILookup lookup = new(lookupData);

/** Get Features Collection */
FeatureCollection? fs = await search.ToGeoJson();
FeatureCollection? fr = await reverse.ToGeoJson();
FeatureCollection? fl = await lookup.ToGeoJson();

/** Get Json Data */
NominatimResponse[]? rs = await search.ToJson();
NominatimResponse[]? rr = await reverse.ToJson();
NominatimResponse[]? rl = await lookup.ToJson();

/** Get Xml data */
SearchResultsXML? xs = await search.ToXml();
ReverseGeocodeXML? xr = await reverse.ToXml();
LookupResultsXML? xl = await lookup.ToXml();

Console.WriteLine(fs);
