using RoR2.Projectile;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class StickyBomb
	{
		public static void Changes()
		{
			var StickyBomb = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/StickyBomb/StickyBomb.prefab").WaitForCompletion();
			StickyBomb.GetComponent<ProjectileImpactExplosion>().blastRadius = 12f;
		}
	}
}
