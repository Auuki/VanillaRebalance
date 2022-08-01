using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using System;

namespace VanillaRebalance.Items
{
	internal class DeathMark : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("DeathMark", "Enable Changes"), true, new ConfigDescription("Enables changes to Death Mark.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.HealthComponent.TakeDamage += (il) =>
			{
				ILCursor ilcursor = new(il);
				ILLabel label = null;
				if (ilcursor.TryGotoNext(MoveType.After,
					x => x.MatchCallvirt(typeof(CharacterBody), "HasBuff"),
					x => x.MatchBrfalse(out label),
					x => x.MatchLdloc(6),
					x => x.MatchLdcR4(1.5f)))
				{
					ilcursor.Emit(OpCodes.Ldarg_1);
					ilcursor.EmitDelegate<Func<float, DamageInfo, float>>((orig, info) =>
					{
						var count = info.attacker?.GetComponent<CharacterBody>()?.inventory.GetItemCount(RoR2Content.Items.DeathMark) - 1;
						return orig + (float)count * 0.05f;
					});
				}
			};

			IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.After,
					//x => x.MatchLdsfld(typeof(RoR2Content.Buffs).GetField(nameof(RoR2Content.Buffs.DeathMark), (System.Reflection.BindingFlags)(-1))),
					x => x.MatchLdloc(15),
					x => x.MatchConvR4(),
					x => x.MatchMul()))
				{
					ilcursor.Emit(OpCodes.Ldarg_1);
					ilcursor.EmitDelegate<Func<float, DamageInfo, float>>((orig, info) =>
					{
						var count = info.attacker?.GetComponent<CharacterBody>()?.inventory.GetItemCount(RoR2Content.Items.DeathMark) - 1;
						return 8f + (float)count * 4f;
					});
				}
			};

			string desc = string.Format("Enemies with <style=cIsDamage>4</style> or more debuffs are <style=cIsDamage>marked for death</style>, increasing damage taken by <style=cIsDamage>50%</style> <style=cStack>(+5% per stack)</style> from all sources for <style=cIsUtility>8</style> <style=cStack>(+4 per stack)</style> seconds.");
			LanguageAPI.Add("ITEM_DEATHMARK_DESC", desc);
		}
	}
}
