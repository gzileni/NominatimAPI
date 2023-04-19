using NominatimAPI;
using NetTopologySuite.Features;

NominatimSearch searchData = new()
{
    City = "Gioia del Colle"
};

NominatimAPISearch search = new();
FeatureCollection? fs = await search.Search(searchData);

