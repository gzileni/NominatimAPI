# NominatimAPI

.Net Package to search OSM data by name and address by [Nominatim.org](https://nominatim.org) API.

## Install

```bash
dotnet add package Nominatim --version 1.0.0
```

## [Search](https://nominatim.org/release-docs/develop/api/Search/)

The search API allows you to look up a location from a textual description or address.

```C#
using NominatimAPI;
using NetTopologySuite.Features;

/** setting search data */
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

NominatimAPISearch search = new(searchData, searchLimit);

/** Get Features Collection */
FeatureCollection? fs = await search.ToGeoJson();

/** Get Json Data */
NominatimResponse[]? rs = await search.ToJson();

/** Get Xml data */
SearchResultsXML? xs = await search.ToXml();

```

## [Reverse](https://nominatim.org/release-docs/develop/api/Reverse/)

Reverse geocoding generates an address from a latitude and longitude.

```C#
using NominatimAPI;
using NetTopologySuite.Features;

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

NominatimAPIReverse reverse = new(reverseData, reverseLimit);

/** Get Features Collection */
FeatureCollection? fr = await reverse.ToGeoJson();

/** Get Json Data */
NominatimResponse[]? rr = await reverse.ToJson();

/** Get Xml data */
ReverseGeocodeXML? xr = await reverse.ToXml();

```

## [Address Lookup](https://nominatim.org/release-docs/develop/api/Lookup/)

The lookup API allows to query the address and other details of one or multiple OSM objects like node, way or relation.

```C#
using NominatimAPI;
using NetTopologySuite.Features;

// must contain a IDS of OSM each prefixed with its type, one of node(N), way(W) or relation(R)
NominatimLookup lookupData = new()
{
    Relation = 146656,
    Way = 104393803,
    Node = 240109189
};

NominatimAPILookup lookup = new(lookupData);

/** Get Features Collection */
FeatureCollection? fl = await lookup.ToGeoJson();

/** Get Json Data */
NominatimResponse[]? rl = await lookup.ToJson();

/** Get Xml data */
LookupResultsXML? xl = await lookup.ToXml();

```
