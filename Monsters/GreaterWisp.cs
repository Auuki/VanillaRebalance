using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class GreaterWisp
	{
		public static void Changes()
		{
			var GreaterWisp = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/GreaterWisp/GreaterWispBody.prefab").WaitForCompletion();
			GreaterWisp.GetComponent<CharacterBody>().baseMaxHealth = 700f;
			GreaterWisp.GetComponent<CharacterBody>().levelMaxHealth = 210f;
		}
	}
}
