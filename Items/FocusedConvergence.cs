using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using System;

namespace VanillaRebalance.Items
{
	internal class FocusedConvergence : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("FocusedConvergence", "Enable Changes"), true, new ConfigDescription("Enables changes to Focused Convergence.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.HoldoutZoneController.FocusConvergenceController.ApplyRate += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.After,
					x => x.MatchLdsfld("RoR2.HoldoutZoneController/FocusConvergenceController", "convergenceChargeRateBonus")
					))
				{
					ilcursor.Emit(OpCodes.Ldarg_0);
					ilcursor.EmitDelegate<Func<float, HoldoutZoneController, float>>((orig, info) =>
					{
						return 0.33f;
					});
				}
			};

			string desc = string.Format("Teleporters charge <style=cIsUtility>25%</style> <style=cStack>(+25% per stack)</style> <style=cIsUtility>faster</style>, but the size of the Teleporter zone is <style=cIsHealth>50%</style> <style=cStack>(-50% per stack)</style> smaller.");
			LanguageAPI.Add("ITEM_FOCUSEDCONVERGENCE_DESC", desc);
		}
	}
}
