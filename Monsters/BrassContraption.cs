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
			BrassContraption.GetComponent<CharacterBody>().baseDamage = 12f;
			BrassContraption.GetComponent<CharacterBody>().levelDamage = 2.4f;

			On.EntityStates.Bell.BellWeapon.ChargeTrioBomb.OnEnter += (orig, self) =>
			{
				EntityStates.Bell.BellWeapon.ChargeTrioBomb.damageCoefficient = 4f;
				orig(self);
			};
		}
	}
}
