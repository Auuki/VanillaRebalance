using RoR2;
using System.Collections.Generic;
using System.Linq;

namespace VanillaRebalance.Items
{
	internal class UnstableTeslaCoil
	{
		public static void Changes()
		{
			On.RoR2.ItemCatalog.Init += (orig) =>
			{
				orig();

				if (!RoR2Content.Items.ShockNearby.ContainsTag(ItemTag.AIBlacklist))
				{
					List<ItemTag> tags = RoR2Content.Items.ShockNearby.tags.ToList();
					tags.Add(ItemTag.AIBlacklist);
					RoR2Content.Items.ShockNearby.tags = tags.ToArray();
				}
			};
		}
	}
}
