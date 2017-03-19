using Merchant.Loaders;
using System;
using ZzukBot.Game.Statics;
using ZzukBot.Mem;

namespace Merchant.Engine
{
    public class Manager
    {
        private Controller Controller { get; }
        private ObjectManager ObjectManager { get; }
        private ProfileLoader ProfileLoader { get; }
        private Action stopCallback;
        private readonly MainThread.Updater pulse;
        private readonly object master;
        private bool running;

        public Manager(Controller controller, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            Controller = controller;
            ObjectManager = objectManager;
            ProfileLoader = profileLoader;
            pulse = new MainThread.Updater(Pulse, 100);
            master = new object();
        }
        public bool Start(Action stopCallback)
        {
            lock (master)
            {
                if (running) return false;
                if (!ObjectManager.IsIngame) return false;
                if (ObjectManager.Player == null) return false;
                try { if (ProfileLoader.hotspots == null) return false; } catch { return false; }
                running = true;
            }
            this.stopCallback = stopCallback;
            pulse.Start();

            return running;
        }
        public void Stop() => running = false;
        public void Dispose() { }
        public void Pause() { }
        public bool Resume() => true;
        private void Pulse()
        {
            Controller.Behavior();
            if (running) return;
            pulse.Stop();
            stopCallback();
        }
    }
}