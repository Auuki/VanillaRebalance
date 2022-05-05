using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class ElderLemurian
	{
		public static void Changes()
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
