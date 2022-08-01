using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using RoR2.Projectile;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	public class BundleOfFireworks : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("BundleOfFireworks", "Enable Changes"), true, new ConfigDescription("Enables changes to Bundle of Fireworks.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.FireworkLauncher.FireMissile += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.After,
					x => x.MatchLdfld("RoR2.FireworkLauncher", "damageCoefficient")
					))
				{
					ilcursor.Emit(OpCodes.Ldc_R4, 0.6f);
					ilcursor.Emit(OpCodes.Add);
				}
			};

			IL.RoR2.GlobalEventManager.OnInteractionBegin += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.After,
					x => x.MatchMul(),
					x => x.MatchAdd()
					))
				{
					ilcursor.Emit(OpCodes.Ldarg_1);
					ilcursor.EmitDelegate<Func<int, GlobalEventManager, int>>((orig, info) =>
					{
						var count = info?.GetComponent<CharacterBody>()?.inventory.GetItemCount(RoR2Content.Items.Firework);
						return (int)count * 5;
					});
				}
			};

			var BundleOfFireworks = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Firework/FireworkProjectile.prefab").WaitForCompletion();
			BundleOfFireworks.GetComponent<ProjectileImpactExplosion>().blastRadius = 8f;

			string desc = string.Format("Activating an interactable <style=cIsDamage>launches 5</style> <style=cStack>(+5 per stack)</style> <style=cIsDamage>fireworks</style> that deal <style=cIsDamage>360%</style> base damage.");
			LanguageAPI.Add("ITEM_FIREWORK_DESC", desc);
		}
	}
}
