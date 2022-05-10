using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class GreaterWisp : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("GreaterWisp", "Enable Changes"), true, new ConfigDescription("Enables changes to Greater Wisp.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var GreaterWisp = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/GreaterWisp/GreaterWispBody.prefab").WaitForCompletion();
			GreaterWisp.GetComponent<CharacterBody>().baseMaxHealth = 700f;
			GreaterWisp.GetComponent<CharacterBody>().levelMaxHealth = 210f;
		}
	}
}
