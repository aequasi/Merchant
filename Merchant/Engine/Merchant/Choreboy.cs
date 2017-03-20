using Merchant.Engine.Navigator;
using System.Collections.Generic;
using ZzukBot.Constants;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Merchant.Engine.Merchant
{
    public class ChoreBoy
    {
        private Inventory Inventory { get; }
        private ObjectManager ObjectManager { get; }
        private Pather Pather { get; }

        public ChoreBoy(Inventory inventory, ObjectManager objectManager, Pather pather)
        {
            Inventory = Inventory;
            ObjectManager = objectManager;
            Pather = pather;
        }
        public bool NeedToMerchant()
        {
            if (Inventory.CountFreeSlots(false) <= 3)
                return true;
            else return false;
        }
        public void PathToVendor()
        {
            if (VendorPosition() == null)
                Pather.Traverse(Pather.GetNextVendorHotspot());
            else
                Pather.Traverse(VendorPosition());
        }
        public Location VendorPosition()
        {
            List<WoWUnit> npcs = ObjectManager.Npcs;
            WoWUnit npc;
            Location npcLoc;

            bool checker = npcs.Exists(x => (x.NpcFlags & Enums.NpcFlags.Vendor) == Enums.NpcFlags.Vendor);
            if (checker == true)
            {
                npc = npcs.Find(x => (x.NpcFlags & Enums.NpcFlags.Vendor) == Enums.NpcFlags.Vendor);
                npcLoc = npc.Position;
            }
            else
                npcLoc = null;

            return npcLoc;
        }
    }
}