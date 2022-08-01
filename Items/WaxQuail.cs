using BepInEx.Configuration;
using EntityStates;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using System;

namespace VanillaRebalance.Items
{
	internal class WaxQuail : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("WaxQuail", "Enable Changes"), true, new ConfigDescription("Enables changes to Wax Quail.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.EntityStates.GenericCharacterMain.ProcessJump += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.After,
					x => x.MatchConvR4(),
					x => x.MatchMul()))
				{
					ilcursor.Emit(OpCodes.Ldarg_0);
					ilcursor.EmitDelegate<Func<float, GenericCharacterMain, float>>((orig, info) =>
					{
						var count = info?.GetComponent<CharacterBody>()?.inventory.GetItemCount(RoR2Content.Items.JumpBoost) - 1;
						return 14f + (float)count * 7f;
					});
				}
			};

			string desc = string.Format("<style=cIsUtility>Jumping</style> while <style=cIsUtility>sprinting</style> boosts you forward by <style=cIsUtility>14m</style> <style=cStack>(+7m per stack)</style>.");
			LanguageAPI.Add("ITEM_JUMPBOOST_DESC", desc);
		}
	}
}
