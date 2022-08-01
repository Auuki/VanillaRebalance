using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using System;

namespace VanillaRebalance.Items
{
	internal class HuntersHarpoon : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("HuntersHarpoon", "Enable Changes"), true, new ConfigDescription("Enables changes to Hunter's Harpoon.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.CharacterBody.RecalculateStats += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(0.25f),
					x => x.MatchLdarg(0)))
				{
					ilcursor.Next.Operand = 0.2f;
				}
			};
			IL.RoR2.GlobalEventManager.OnCharacterDeath += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.After,
					x => x.MatchLdcR4(0.5f),
					x => x.MatchMul(),
					x => x.MatchAdd()
					))
				{
					ilcursor.Emit(OpCodes.Ldarg_1);
					ilcursor.EmitDelegate<Func<float, DamageReport, float>>((orig, info) =>
					{
						var count = info.attacker?.GetComponent<CharacterBody>()?.inventory.GetItemCount(DLC1Content.Items.MoveSpeedOnKill) - 1;
						return 1.5f + (float)count * 0.75f;
					});
				}
			};

			string desc = string.Format("Killing an enemy increases <style=cIsUtility>movement speed</style> by <style=cIsUtility>100%</style>, fading over <style=cIsUtility>1.5</style> <style=cStack>(+0.75 per stack)</style> seconds.");
			LanguageAPI.Add("ITEM_MOVESPEEDONKILL_DESC", desc);
		}
	}
}
