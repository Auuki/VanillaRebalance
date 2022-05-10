using BepInEx.Configuration;
using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VanillaRebalance.Items
{
	internal class UnstableTeslaCoil : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("UnstableTeslaCoil", "Enable Changes"), true, new ConfigDescription("Enables changes to Unstable Tesla Coil.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			On.RoR2.ItemCatalog.Init += (orig) =>
			{
				orig();

				if (!RoR2Content.Items.ShockNearby.ContainsTag(ItemTag.AIBlacklist))
				{
					List<ItemTag> tags = RoR2Content.Items.ShockNearby.tags.ToList();
					tags.Add(ItemTag.AIBlacklist);
					RoR2Content.Items.ShockNearby.tags = tags.ToArray();
				}
			};
		}
	}
}
