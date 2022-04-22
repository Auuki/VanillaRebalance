using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class BrassContraption
	{
		public static void Changes()
		{
			var BrassContraption = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Bell/BellBody.prefab").WaitForCompletion();
			BrassContraption.GetComponent<CharacterBody>().baseDamage = 2f;
			BrassContraption.GetComponent<CharacterBody>().levelDamage = 0.4f;
		}
	}
}
