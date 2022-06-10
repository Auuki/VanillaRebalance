using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using R2API;
using R2API.Utils;
using System;
using System.Reflection;

namespace VanillaRebalance
{
	//This attribute specifies that we have a dependency on R2API, as we're using it to add our item to the game.
	//You don't need this if you're not using R2API in your plugin, it's just to tell BepInEx to initialize R2API before this plugin so it's safe to use R2API.
	[BepInDependency(R2API.R2API.PluginGUID)]

	//This attribute is required, and lists metadata for your plugin.
	[BepInPlugin(PluginGUID, PluginName, PluginVersion)]

	//We will be using 2 modules from R2API: ItemAPI to add our item and LanguageAPI to add our language tokens.
	[R2APISubmoduleDependency(nameof(LanguageAPI), nameof(RecalculateStatsAPI))]

	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]

	public class VanillaRebalance : BaseUnityPlugin
	{
		//The Plugin GUID should be a unique ID for this plugin, which is human readable (as it is used in places like the config).
		//If we see this PluginGUID as it is on thunderstore, we will deprecate this mod. Change the PluginAuthor and the PluginName !
		public const string PluginGUID = PluginAuthor + "." + PluginName;
		public const string PluginAuthor = "Hayaku";
		public const string PluginName = "VanillaRebalance";
		public const string PluginVersion = "1.0.8";

		//The Awake() method is run at the very start when the game is initialized.
		public void Awake()
		{
			//Init our logging class so that we can properly log for debugging
			Log.Init(Logger);

			RebalanceComponent.Initialize(Logger, Config);
		}
	}

	public abstract class RebalanceComponent
	{
		protected virtual ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return null;
		}

		public virtual void Load()
		{

		}

		public static void Initialize(ManualLogSource logger, ConfigFile configFile)
		{
			foreach (var type in Assembly.GetCallingAssembly().GetTypes())
			{
				if (type.IsAbstract) continue;
				if (!typeof(RebalanceComponent).IsAssignableFrom(type)) continue;
				if (Activator.CreateInstance(type) is not RebalanceComponent component)
				{
					logger.LogError($"Failed to make instance of {type}");
					continue;
				}

				var toggle = component.GetConfigToggle(configFile);

				if (!toggle?.Value ?? false) continue;
				component.Load();
			}
		}
	}
}
