using Merchant.DependencyMap;
using Merchant.Engine;
using Merchant.Engine.Merchant;
using Merchant.Engine.Navigator;
using Merchant.GUI;
using Merchant.Loaders;
using Merchant.Loaders.Profile;
using System;
using System.ComponentModel.Composition;
using ZzukBot.ExtensionFramework.Interfaces;
using ZzukBot.Game.Statics;

namespace Merchant
{
    [Export(typeof(IBotBase))]
    public class Merchant : IBotBase
    {
        private Router r = new Router();

        public Merchant()
        {
            r.Add(this);
            r.Add(Inventory.Instance);
            r.Add(Navigation.Instance);
            r.Add(ObjectManager.Instance);
            r.Add(new Loader());
            r.Add(new ProfileLoader(r.Get<Loader>()));
            r.Add(new Pather(r.Get<Navigation>(), r.Get<ObjectManager>(), r.Get<ProfileLoader>()));
            r.Add(new ChoreBoy(r.Get<Inventory>(), r.Get<ObjectManager>(), r.Get<Pather>()));
            r.Add(new Controller(r.Get<ChoreBoy>(), r.Get<ObjectManager>(), r.Get<Pather>()));
            r.Add(new Manager(r.Get<Controller>(), r.Get<ObjectManager>(), r.Get<ProfileLoader>()));
            r.Add(new CMD(r.Get<Merchant>(), r.Get<ProfileLoader>()));
        }
        public string Author { get; } = "krycess";
        public string Name { get; } = "Merchant";
        public int Version { get; } = 1;
        public void ShowGui()
        {
            CMD settings = r.Get<CMD>();
            if (settings.Visible)
                settings.Hide();
            settings.Show();
        }
        public bool Start(Action stopCallback) => r.Get<Manager>().Start(stopCallback);
        public void Stop() => r.Get<Manager>().Stop();
        public void Dispose() => r.Get<Manager>().Dispose();
        public void PauseBotbase(Action onPauseCallback) => r.Get<Manager>().Pause();
        public bool ResumeBotbase() => r.Get<Manager>().Resume();
    }
}