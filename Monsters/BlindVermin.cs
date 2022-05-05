using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class BlindVermin
	{
		public static void Changes()
		{
			var BlindVermin = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Vermin/VerminBody.prefab").WaitForCompletion();
			BlindVermin.GetComponent<CharacterBody>().baseMoveSpeed = 12f;
		}
	}
}