using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
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
				ilcursor.GotoNext(
					x => ILPatternMatchingExt.MatchLdfld(x, "RoR2.FireworkLauncher", "damageCoefficient")
					);
				ilcursor.Index++;
				ilcursor.Emit(OpCodes.Ldc_R4, 0.6f);
				ilcursor.Emit(OpCodes.Add);
			};

			IL.RoR2.GlobalEventManager.OnInteractionBegin += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchStloc(9)
					);
				ilcursor.Index++;
				ilcursor.Remove();
				ilcursor.Emit(OpCodes.Ldc_I4, 0);
				ilcursor.Index++; //removed instruction doesn't count so we only skip 1
				ilcursor.Remove();
				ilcursor.Emit(OpCodes.Ldc_I4, 5);
			};

			var BundleOfFireworks = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Firework/FireworkProjectile.prefab").WaitForCompletion();
			BundleOfFireworks.GetComponent<ProjectileImpactExplosion>().blastRadius = 8f;

			string desc = string.Format("Activating an interactable <style=cIsDamage>launches 5</style> <style=cStack>(+5 per stack)</style> <style=cIsDamage>fireworks</style> that deal <style=cIsDamage>360%</style> base damage.");
			LanguageAPI.Add("ITEM_FIREWORK_DESC", desc);
		}
	}
}
