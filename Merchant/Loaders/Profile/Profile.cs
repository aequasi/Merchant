using System.Collections.Generic;

namespace Merchant.Loaders.Profile
{
    public class Profile
    {
        public List<Hotspots> Hotspots { get; set; }
        public List<Hotspots> VendorHotspots { get; set; }
        public List<Hotspots> Repair { get; set; }
    }
}