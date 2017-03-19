using Merchant.Engine.Navigator;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Merchant.Engine
{
    public class Controller
    {
        private ObjectManager ObjectManager { get; }
        private Pather Pather { get; }

        public Controller(ObjectManager objectManager, Pather pather)
        {
            ObjectManager = objectManager;
            Pather = pather;
        }
        public void Behavior()
        {
            LocalPlayer player = ObjectManager.Player;

            switch (StatusSwitch())
            {
                case Status.ALIVE:
                    Pather.Traverse(Pather.GetNextHotspot());
                    break;
                case Status.DEAD:
                    break;
                case Status.GHOST:
                    Pather.Traverse(player.CorpsePosition);
                    break;
                case Status.NEED2VENDOR:
                    break;
                case Status.NEED2RESTOCK:
                    break;
                case Status.NEED2REPAIR:
                    break;
            }
        }
        public Status StatusSwitch()
        {
            LocalPlayer player = ObjectManager.Player;

            if (player.InGhostForm)
                return Status.GHOST;
            else if (player.IsDead)
                return Status.DEAD;
            else
            {
                return Status.ALIVE;
            }
        }
    }
    public enum Status
    {
        ALIVE,
        DEAD,
        GHOST,
        NEED2VENDOR,
        NEED2RESTOCK,
        NEED2REPAIR
    }
}