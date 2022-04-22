using RoR2;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class GnarledWoodsprite
	{
		public static void Changes()
		{
			var GnarledWoodsprite = Addressables.LoadAssetAsync<EquipmentDef>("RoR2/Base/PassiveHealing/PassiveHealing.asset").WaitForCompletion();
			GnarledWoodsprite.cooldown = 20f;
		}
	}
}
