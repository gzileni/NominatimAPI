using NominatimAPI;
using NetTopologySuite.Features;

NominatimSearch searchData = new()
{
    City = "Gioia del Colle"
};

NominatimReverse reverseData = new()
{
    Lat = 40.798838,
    Lon = 16.921660
};

NominatimLookup lookupData = new()
{
    Relation = 146656,
    Way = 104393803,
    Node = 240109189
};

NominatimAPISearch search = new(searchData);
NominatimAPIReverse reverse = new(reverseData);
NominatimAPILookup lookup = new(lookupData);

FeatureCollection? fs = await search.Features();
FeatureCollection? fr = await reverse.Features();
FeatureCollection? fl = await lookup.Features();

NominatinResponse[]? rs = await search.ToJsonArray();
NominatinResponse? rr = await reverse.ToJson();

Console.WriteLine(fs);
