using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using Dalamud.Interface.Windowing;
using PortraitHelper.Windows;
using Dalamud.Logging;
using Dalamud.Game.Gui;
using PortraitHelper.Events;

namespace PortraitHelper
{
    public sealed class PortraitPlugin : IDalamudPlugin
    {
        public string Name => "Potrait Helper";

        private const string CommandName = "/pportrait";

        public Configuration Configuration { get; }

        public WindowSystem WindowSystem { get; }

        private ConfigWindow ConfigWindow { get; }

        private MainWindow MainWindow { get; }

        private PortraitEventHandler PortraitEventHandler { get; }

        public PortraitPlugin(DalamudPluginInterface pluginInterface)
        {
            Service.Initialize(pluginInterface);

            Configuration = pluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            Configuration.Initialize(pluginInterface);

            // you might normally want to embed resources and load them from the manifest stream
            var imagePath = Path.Combine(pluginInterface.AssemblyLocation.Directory?.FullName!, "goat.png");
            var goatImage = pluginInterface.UiBuilder.LoadImage(imagePath);

            ConfigWindow = new ConfigWindow(this);
            MainWindow = new MainWindow(this, goatImage);

            WindowSystem = new WindowSystem("PortraitHelper");
            WindowSystem.AddWindow(ConfigWindow);
            WindowSystem.AddWindow(MainWindow);

            Service.CommandManager.AddHandler(CommandName, new CommandInfo(OnMainCommand)
            {
                HelpMessage = "Displays configuration window"
            });

            pluginInterface.UiBuilder.Draw += DrawUI;
            pluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;

            PortraitEventHandler = new PortraitEventHandler(Configuration);

#if DEBUG
            Service.ChatGui.Print("Portrait helper loaded in DEBUG mode");
#endif
        }

        public void Dispose()
        {
            WindowSystem.RemoveAllWindows();
            
            ConfigWindow.Dispose();
            MainWindow.Dispose();
            
            Service.CommandManager.RemoveHandler(CommandName);
        }

        private void OnMainCommand(string command, string args)
        {
            MainWindow.IsOpen = !MainWindow.IsOpen;
        }

        private void DrawUI()
        {
            WindowSystem.Draw();
        }

        public void DrawConfigUI()
        {
            ConfigWindow.IsOpen = !ConfigWindow.IsOpen;
        }
    }
}
