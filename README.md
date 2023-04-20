# NominatimAPI

.Net Package to search OSM data by name and address by [Nominatim.org](https://nominatim.org) API.

## Install

```bash
dotnet add package Nominatim --version 1.2
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

NominatimAPISearch search = new();

search.SetParameters(searchData);
search.SetLimitation(searchLimit);

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

NominatimAPIReverse reverse = new();

reverse.SetParameters(reverseData);
reverse.SetLimitation(reverseLimit);

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

lookup.SetParameters(lookupData);

/** Get Features Collection */
FeatureCollection? fl = await lookup.ToGeoJson();

/** Get Json Data */
NominatimResponse[]? rl = await lookup.ToJson();

/** Get Xml data */
LookupResultsXML? xl = await lookup.ToXml();

```

## Dependency Injection

In `Program.cs` of your ASP.Net Core project configure the services:

```C#
builder.Services.AddScoped<INominatimAPISearchInterface, NominatimAPISearch>();
builder.Services.AddScoped<INominatimAPIReverseInterface, NominatimAPIReverse>();
builder.Services.AddScoped<INominatimAPILookupInterface, NominatimAPILookup>();
```

Inject the service like this Controller:

```C#

using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Features;
using NominatimAPI;

[Route("api/[controller]")]
public class NominatimController : ControllerBase
{
    private readonly INominatimAPISearchInterface? _nominatim;
    
    public NominatimController(INominatimAPISearchInterface? nominatim)
    {
        this._nominatim = nominatim;
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(FeatureCollection))]
    [ProducesResponseType(204, Type = typeof(FeatureCollection))]
    [ProducesResponseType(400)]
    public async Task<IActionResult?> Post([FromBody] NominatimSearch parameters)
    {
        try
        {
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

            this._nominatim!.SetParameters(parameters);
            this._nominatim!.SetLimitation(searchLimit);
            FeatureCollection? featuresCollection = await this._nominatim.ToGeoJson();
            return Ok(featuresCollection);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
```

## Custom Docker Image Nominatim

You can configure a nominatim docker image to query your own docker stack. Just configure the new address from the Url property.

You can download docker image from git repository [docker-nominatim](https://github.com/gzileni/docker-nominatim).

```C#
using NominatimAPI;
using NetTopologySuite.Features;

/** setting search data */
NominatimSearch searchData = new()
{
    City = "Gioia del Colle"
};

NominatimAPISearch search = new();

search.SetParameters(searchData);

search.Url = "http://my-container-nominatim";
FeatureCollection? fs = await search.ToGeoJson();
```

