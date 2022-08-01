using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	public class GestureOfTheDrowned : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("GestureOfTheDrowned", "Enable Changes"), true, new ConfigDescription("Enables changes to Gesture of the Drowned.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.Inventory.CalculateEquipmentCooldownScale += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(0.5f),
					x => x.MatchLdcR4(0.85f)))
				{
					ilcursor.Next.Operand = 0.7f;
				}
			};

			string desc = string.Format("<style=cIsUtility>Reduces Equipment cooldown</style> by <style=cIsUtility>30%</style> <style=cStack>(+15% per stack)</style>. Forces your Equipment to <style=cIsUtility>activate</style> whenever it is off <style=cIsUtility>cooldown</style>.");
			LanguageAPI.Add("ITEM_AUTOCASTEQUIPMENT_DESC", desc);
		}
	}
}
