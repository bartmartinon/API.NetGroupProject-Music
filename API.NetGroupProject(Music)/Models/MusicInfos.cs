using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NetGroupProject_Music_.Models
{

    public class MusicInfos
    {
        public string country_iso { get; set; }
        public string country { get; set; }
        public bool open { get; set; }
        public string pop { get; set; }
        public string upload_token { get; set; }
        public int upload_token_lifetime { get; set; }
        public object user_token { get; set; }
        public Hosts hosts { get; set; }
        public Ads ads { get; set; }
        public bool has_podcasts { get; set; }
        public Offer[] offers { get; set; }
    }

    public class Hosts
    {
        public string stream { get; set; }
        public string images { get; set; }
    }

    public class Ads
    {
        public Audio audio { get; set; }
        public Display display { get; set; }
        public Big_Native_Ads_Home big_native_ads_home { get; set; }
    }

    public class Audio
    {
        public Default _default { get; set; }
    }

    public class Default
    {
        public int start { get; set; }
        public int interval { get; set; }
        public string unit { get; set; }
    }

    public class Display
    {
        public Interstitial interstitial { get; set; }
    }

    public class Interstitial
    {
        public int start { get; set; }
        public int interval { get; set; }
        public string unit { get; set; }
    }

    public class Big_Native_Ads_Home
    {
        public Iphone iphone { get; set; }
        public Ipad ipad { get; set; }
        public Android android { get; set; }
        public Android_Tablet android_tablet { get; set; }
    }

    public class Iphone
    {
        public bool enabled { get; set; }
    }

    public class Ipad
    {
        public bool enabled { get; set; }
    }

    public class Android
    {
        public bool enabled { get; set; }
    }

    public class Android_Tablet
    {
        public bool enabled { get; set; }
    }

    public class Offer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string displayed_amount { get; set; }
        public string tc { get; set; }
        public string tc_html { get; set; }
        public string tc_txt { get; set; }
        public int try_and_buy { get; set; }
    }

}
