using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Aetherytes;
using Dalamud.Game.ClientState.Buddy;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Fates;
using Dalamud.Game.ClientState.GamePad;
using Dalamud.Game.ClientState.JobGauge;
using Dalamud.Game.ClientState.Keys;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.ClientState.Party;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Game.Gui.FlyText;
using Dalamud.Game.Gui.PartyFinder;
using Dalamud.Game.Gui.Toast;
using Dalamud.Game.Libc;
using Dalamud.Game.Network;
using Dalamud.IoC;
using Dalamud.Plugin;

#pragma warning disable 8618
namespace PortraitHelper
{
    internal class Service
    {
        [PluginService][RequiredVersion("1.0")] public static AetheryteList AetheryteList { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static BuddyList BuddyList { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static ChatGui ChatGui { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static ChatHandlers ChatHandlers { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static ClientState ClientState { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static CommandManager CommandManager { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static Condition Condition { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static DalamudPluginInterface PluginInterface { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static DataManager DataManager { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static DtrBar DtrBar { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static FateTable FateTable { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static FlyTextGui FlyTextGui { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static Framework Framework { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static GameGui GameGui { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static GameNetwork GameNetwork { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static GamepadState GamePadState { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static JobGauges JobGauges { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static KeyState KeyState { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static LibcFunction LibcFunction { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static ObjectTable ObjectTable { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static PartyFinderGui PartyFinderGui { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static PartyList PartyList { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static SigScanner SigScanner { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static TargetManager TargetManager { get; private set; }
        [PluginService][RequiredVersion("1.0")] public static ToastGui ToastGui { get; private set; }


        internal static void Initialize(DalamudPluginInterface pluginInterface)
        {
            pluginInterface.Create<Service>();
        }
    }
}
