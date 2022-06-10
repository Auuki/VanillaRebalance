using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class BlindPest : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("BlindPest", "Enable Changes"), true, new ConfigDescription("Enables changes to Blind Pest.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var BlindVermin = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/FlyingVermin/FlyingVerminMaster.prefab").WaitForCompletion();
			BlindVermin.GetComponent<RoR2.CharacterAI.AISkillDriver>().maxDistance = 50f;
		}
	}
}