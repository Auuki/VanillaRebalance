using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using RoR2.Orbs;
using System;

namespace VanillaRebalance.Items
{
	internal class Polylute : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Polylute", "Enable Changes"), true, new ConfigDescription("Enables changes to Polylute.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(25f),
					x => x.MatchStloc(56)))
				{
					ilcursor.Next.Operand = 20f;
				}

				if (ilcursor.TryGotoNext(x => x.MatchStfld<VoidLightningOrb>("totalStrikes")))
				{
					ilcursor.Emit(OpCodes.Ldarg_1);
					ilcursor.EmitDelegate<Func<int, DamageInfo, int>>((orig, info) =>
					{
						var count = info.attacker?.GetComponent<CharacterBody>()?.inventory.GetItemCount(DLC1Content.Items.ChainLightningVoid) - 1;
						return 3 + (int)count * 2;
					});
				}
			};

			string desc = string.Format("<style=cIsDamage>20%</style> chance to fire <style=cIsDamage>lightning</style> for <style=cIsDamage>60%</style> TOTAL damage up to <style=cIsDamage>3</style> <style=cStack>(+2 per stack)</style> times. <style=cIsVoid>Corrupts all Ukuleles</style>.");
			LanguageAPI.Add("ITEM_CHAINLIGHTNINGVOID_DESC", desc);
		}
	}
}
