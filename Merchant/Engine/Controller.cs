using Merchant.Engine.Navigator;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Merchant.Engine
{
    public class Controller
    {
        private Inventory Inventory { get; }
        private ObjectManager ObjectManager { get; }
        private Pather Pather { get; }

        public Controller(Inventory inventory, ObjectManager objectManager, Pather pather)
        {
            Inventory = inventory;
            ObjectManager = objectManager;
            Pather = pather;
        }
        public void Behavior()
        {
            LocalPlayer player = ObjectManager.Player;

            switch (SwitchLogic())
            {
                case Status.ALIVE:
                    Pather.Traverse(Pather.GetNextHotspot());
                    break;
                case Status.DEAD:
                    player.RepopMe();
                    break;
                case Status.GHOST:
                    Pather.Traverse(player.CorpsePosition);
                    player.RetrieveCorpse();
                    break;
                case Status.NEED2VENDOR:
                    break;
                case Status.NEED2RESTOCK:
                    break;
                case Status.NEED2REPAIR:
                    break;
            }
        }
        public Status SwitchLogic()
        {
            LocalPlayer player = ObjectManager.Player;

            if (player.IsDead)
                return Status.DEAD;
            else if (player.InGhostForm)
                return Status.GHOST;
            else
            {
                if (Inventory.CountFreeSlots(false) <= 3)
                    return Status.NEED2VENDOR;
                else
                    return Status.ALIVE;
            }
        }
    }
    public enum Status
    {
        ALIVE,
        DEAD,
        GHOST,
        NEED2REPAIR,
        NEED2RESTOCK,
        NEED2VENDOR
    }
}