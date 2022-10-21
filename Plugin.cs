using Microsoft.Extensions.DependencyInjection;
using NodeBlock.Engine.Interop.Plugin;
using System;

namespace NodeBlock.Plugin.News
{
    public class Plugin : BasePlugin
    {

        public static bool PluginAlive = true;

        public static ServiceProvider Services;

        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public override void Load()
        {
            Console.WriteLine("News Plugin Loaded");
        }

    }
}
