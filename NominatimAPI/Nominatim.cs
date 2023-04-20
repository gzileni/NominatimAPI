using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

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
        public string? Country { get; set; }
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

    public class SearchResultLimitation
    {
        /** 
         * Limit search results to one or more countries. 
         * <countrycode> must be the ISO 3166-1alpha2 code, 
         * e.g. gb for the United Kingdom, de for Germany.
         * Each place in Nominatim is assigned to one country code based on OSM country boundaries. 
         * In rare cases a place may not be in any country at all, for example, in international waters. */
        public List<string>? CountryCodes { get; set; }
        /**
         * If you do not want certain OSM objects to appear in the search result, give a comma separated list of the place_ids you want to skip. 
         * This can be used to retrieve additional search results. 
         * For example, if a previous query only returned a few results, then including those here would cause the search to return other, 
         * less accurate, matches (if possible).
         */
        public List<string>? ExcludePlaceIds { get; set; }
        /**
         * The preferred area to find search results. 
         * Any two corner points of the box are accepted as long as they span a real box. x is longitude, y is latitude.
         */
        public List<double>? ViewBox { get; set; }
        /**
         * When a viewbox is given, restrict the result to items contained within that viewbox (see above). 
         * When viewbox and bounded=1 are given, an amenity only search is allowed. 
         * Give the special keyword for the amenity in square brackets, e.g. [pub] and a selection of objects of this type is returned. 
         * There is no guarantee that the result is complete. (Default: 0)
         * */
        public int Bounded { get; set; } = 0;

        /**
         * Limit the number of returned results. (Default: 10, Maximum: 50)
         */
        public int Limit { get; set; } = 10;

        /**
         * If you are making large numbers of request please include an appropriate email address to identify your requests.
         * Info: https://operations.osmfoundation.org/policies/nominatim/
         */
        public string? Email { get; set; }
    }

    public class ReverseResultLimitation
    {
        /**
         * Level of detail required for the address. Default: 18. 
         * This is a number that corresponds roughly to the zoom level used in XYZ tile sources in frameworks like Leaflet.js, Openlayers etc. 
         * In terms of address details the zoom levels are as follows:

            zoom	address detail
            ----------------------
            3	    country
            5	    state
            8	    county
            10	    city
            12	    town / borough
            13	    village / suburb
            14	    neighbourhood
            15	    locality
            16	    major streets
            17	    major and minor streets
            18	    building
        */
        public int Zoom { get; set; } = 18;
    }
}


