using Merchant.Engine.Merchant;
using Merchant.Engine.Navigator;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Merchant.Engine
{
    public class Controller
    {
        private ChoreBoy ChoreBoy { get; }
        private ObjectManager ObjectManager { get; }
        private Pather Pather { get; }

        public Controller(ChoreBoy choreBoy, ObjectManager objectManager, Pather pather)
        {
            ChoreBoy = choreBoy;
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
                case Status.MERCHANTING:
                    ChoreBoy.PathToVendor();
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
                if (ChoreBoy.NeedToMerchant() == true)
                    return Status.MERCHANTING;
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
        MERCHANTING
    }
}