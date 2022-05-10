using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class ElderLemurian : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("ElderLemurian", "Enable Changes"), true, new ConfigDescription("Enables changes to Elder Lemurian.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var ElderLemurian = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/LemurianBruiser/LemurianBruiserBody.prefab").WaitForCompletion();
			ElderLemurian.GetComponent<CharacterBody>().baseMaxHealth = 800f;
			ElderLemurian.GetComponent<CharacterBody>().levelMaxHealth = 240f;
			ElderLemurian.GetComponent<CharacterBody>().baseMoveSpeed = 12f;

			On.EntityStates.LemurianBruiserMonster.FireMegaFireball.OnEnter += (orig, self) =>
			{
				EntityStates.LemurianBruiserMonster.FireMegaFireball.projectileCount = 3;
				EntityStates.LemurianBruiserMonster.FireMegaFireball.totalYawSpread = 20f;
				orig(self);
			};
		}
	}
}
