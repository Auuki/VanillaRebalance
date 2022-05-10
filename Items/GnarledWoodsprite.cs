using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class GnarledWoodsprite : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("GnarledWoodsprite", "Enable Changes"), true, new ConfigDescription("Enables changes to Gnarled Woodsprite.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var GnarledWoodsprite = Addressables.LoadAssetAsync<EquipmentDef>("RoR2/Base/PassiveHealing/PassiveHealing.asset").WaitForCompletion();
			GnarledWoodsprite.cooldown = 20f;
		}
	}
}
