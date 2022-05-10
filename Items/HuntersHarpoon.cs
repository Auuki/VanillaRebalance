using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
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
			IL.RoR2.GlobalEventManager.OnCharacterDeath += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcI4(5)
					);
				ilcursor.Remove();
				ilcursor.Emit(OpCodes.Ldc_I4, 4);
				ilcursor.Index++;
				ilcursor.Next.Operand = 1.5f;
				ilcursor.Index += 3;
				ilcursor.Next.Operand = 0.75f;
			};

			string desc = string.Format("Killing an enemy increases <style=cIsUtility>movement speed</style> by <style=cIsUtility>100%</style>, fading over <style=cIsUtility>1.5</style> <style=cStack>(+0.75 per stack)</style> seconds.");
			LanguageAPI.Add("ITEM_MOVESPEEDONKILL_DESC", desc);
		}
	}
}
