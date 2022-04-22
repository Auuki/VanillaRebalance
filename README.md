## About

VanillaRebalance aims at balancing vanilla without changing the effects of items/monsters/survivors. Every change can be disabled through the config. It is my first mod, I'm still learning how to change more values so expect many more adjustments to come. I will start adjusting survivors in the future.

## Changes

### Items

**Bison Steak**
* Increases maximum health by ~~25~~ 30 (+~~25~~ 30 per stack).
	* *Currently Bison Steak gives less than 1 level worth of maximum health even on Huntress who has the lowest hp per level (27). Increasing the amount of maximum health gained will make it more useful early on and keep it reasonably useful at later stages. Anything higher than 30 would undermine Infusion.*

**Bundle of Fireworks**
* Activating an interactable launches ~~8~~ 5 (+5 per stack) fireworks that deal ~~300%~~ 360% base damage.
	* *It's a nerf at less than 2 stacks but at early levels many fireworks go to waste anyway cause of lack of enemies. Change helps with scaling at higher stacks which was very underwhelming.*

**Bustling Fungus**
* After standing still for 1 second, create a zone that heals for ~~4.5%~~ 4% (+~~2.25%~~ 2% per stack) of your health every second to all allies within ~~3.5m~~ 4m (+~~1.5m~~ 2m per stack).
	* *Fungus healing is quite powerful. It's always good to have at least one fungus in case of an emergency. That's why it got nerfed. AoE on the other hand got buffed to help with the shared healing aspect of the Fungus. This should allow for easier healing of allies, especially drones, as well as better positioning of Engineer's Turrets.*

**Focus Crystal**
* Increase damage to enemies within ~~13m~~ 12m by 20% (+20% per stack).
	* *AoE unification nerf which makes the range more reasonable for what is considered a "melee range".*

**Sticky Bomb**
* Increased explosion radius from 10m to 12m.
	* *Part of AoE unification as well as a slight buff to a plain damaging item that has proc coefficient of 0.*

**Tougher Times**
* ~~13%~~ 10% (+~~13%~~ 10% per stack) chance to block incoming damage. Unaffected by luck.
	* *Tougher Times is powerful for its rarity hence the nerf. The formula used is `1 - 1 / (1 + 0.15 * amount)` which rounds down to 13% with a single item if someone wonders why there's 13% instead of 15%.*

**AtG Missile Mk. 1**
* 10% chance to fire a missile that deals ~~300%~~ 200% (+~~300%~~ 200% per stack) TOTAL damage.
	* *AtG is a bit similar to bands and just like them gets a nerf. While the tooltip damage is the same as bands after the nerf, AtG has a damage falloff and cannot be directed so oftentimes hits can go to waste on weak enemies.*

**Harvester's Scythe**
* Gain 5% critical chance. Critical strikes heal for ~~8~~ 4 (+4 per stack) health.
	* *Heal nerf puts it more in line with Leeching Seed as the first Harvester's Scythe only requires 16% critical strike chance to outperform the seed (26% after the nerf).*

**Kjaro's Band**
* Hits that deal more than 400% damage also blast enemies with a runic flame tornado, dealing ~~300%~~ 200% (+~~300%~~ 200% per stack) TOTAL damage over time. Recharges every 10 seconds.
	* *Bands are overpowered, especially on Loader. Kjaro's Band got nerfed harder because by constantly hitting for a period of time, it usually outdamages Runald's Band, especially while already dealing higher total damage.*

**Predatory Instincts**
* Gain 5% critical chance. Critical strikes increase attack speed by ~~12%~~ 10%. Maximum cap of ~~36%~~ 30% (+~~24%~~ 20% per stack) attack speed.
	* *Predatory Instincts is very powerful in the right hands, especially Bandit or Huntress using Flurry. Nerf puts it in a much more fair spot considering the standard 15% increase from Soldier's Syringe. It has an unlisted 5% critical chance which works just like Harvester's Scythe and Predatory Instincts so it was added to the tooltip.*

**Razorwire**
* Getting hit causes you to explode in a burst of razors, dealing 160% damage. Hits up to ~~5~~ 3 (+2 per stack) targets in a ~~25m~~ 20m (+~~10m~~ 2m per stack) radius.
	* *The radius is enormous so it was decreased together with the amount of targets, both to match the Ukulele.*

**Runald's Band**
* Hits that deal more than 400% damage also blast enemies with a runic ice blast, slowing them by 80% for 3s (+3s per stack) and dealing ~~250%~~ 200% (+~~250%~~ 200% per stack) TOTAL damage. Recharges every 10 seconds.
	* *Bands are overpowered, especially on Loader. Runald's Band got nerfed less as it's the less powerful out of the two.*

**Ukulele**
* ~~25%~~ 20% chance to fire chain lightning for 80% TOTAL damage on up to 3 (+2 per stack) targets within 20m (+2m per stack).
	* *Ukulele is very strong, I'd consider decreasing the damage but 25% chance to trigger is very high so lets start there. This way it also matches Sentient Meat Hook's listed base chance (cause in reality it's 16,7%).*

**Wax Quail**
* Jumping while sprinting boosts you forward by ~~10m~~ 14m (+~~10m~~ 7m per stack).
	* *Just a few Wax Quails (even less with other movement speed increasing items) are enough for jumping while sprinting to get out of hand. Oftentimes people don't want to pick them at stacks even as low as around 5. Initial Wax Quail usually doesn't help too much hence the buff to initial value. Stacking nerf kicks in at 3 and above, making it more manageable while keeping it useful. Values were chosen based on the base movement speed of survivors, which is 7m/s.*

**Brilliant Behemoth**
* All your attacks explode in a 4m (+~~2.5m~~ 2m per stack) radius for a bonus 60% TOTAL damage to nearby enemies.
	* *A small nerf based on AoE unification.*

**Mired Urn**
* While in combat, the nearest 1 (+1 per stack) enemies to you within ~~13m~~ 12m will be 'tethered' to you, dealing 100% damage per second, applying tar, and healing you for 100% of the damage dealt.
	* *Made to match Focus Crystal's range after the change.*

**Shatterspleen**
* Gain 5% critical chance. Critical Strikes bleed enemies for 240% base damage. Bleeding enemies explode on death for 400% (+400% per stack) damage~~, plus an additional 15% (+15% per stack) of their maximum health.~~
* Decreased explosion radius from 16m to 12m.
	* *Additional damage based on the enemy's maximum health is beyond overpowered, especially considering how big the explosion radius is (same as a single Warbanner). Oftentimes killing a boss at later stages creates a domino effect where everything around dies, killing all other bosses and enemies in the process. It has an unlisted 5% critical chance which works just like Harvester's Scythe and Predatory Instincts so it was added to the tooltip.*

**Titanic Knurl**
* Increase maximum health by ~~40~~ 50 (+~~40~~ 50 per stack) and base health regeneration by +~~1.6~~ 2 hp/s (+~~1.6~~ 2 hp/s per stack).
	* *Titanic Knurl in its current state is comparable to Cautious Slug. Regeneration got buffed to twice the regeneration of most survivors (and 2/3rds of cautious slug). Maximum health increase got buffed to half of Infusion/Ben's Raincoat. If someone thinks it's still mediocre compared to Cautious Slug, remember that many healing effects now scale with maximum health and Cautious Slug requires the player to not get hit for 7 seconds.*

**Focused Convergence**
* Teleporters charge ~~23%~~ 25% (+~~23%~~ 25% per stack) faster, but the size of the Teleporter zone is 50% (-50% per stack) smaller.
	* *A tiny buff to make it slightly less punishing, especially when stacked. Base value is 23% unlike the listed 30%.*

**Gesture of the Drowned**
* Reduce Equipment cooldown by ~~50%~~ 30% (+15% per stack). Forces your Equipment to activate whenever it is off cooldown.
	* *Gesture of the Drowned is very powerful while its downside is usually sought after. Initial cooldown reduction is extreme but the downside is weak so it requires a nerf.*

**Polylute**
* ~~25%~~ 20% chance to fire lightning for 60% TOTAL damage up to 3 (+3 per stack) times. Corrupts all Ukuleles.
	* *Nerf to keep it closer to Ukulele.*

**Singularity Band**
* Hits that deal more than 400% damage also fire a black hole that draws enemies within ~~15m~~ 16m into its center. Lasts 5 seconds before collapsing, dealing 100% (+100% per stack) TOTAL damage. Recharges every 20 seconds. Corrupts all Runald's and Kjaro's Bands.
	* *Currently it's a bit of a questionable choice but that is mainly because of regular bands being overpowered. Considering their nerf, Singularity Band should become a much more appealing choice. Range increase is there just because of the AoE unification.*

**Gnarled Woodprite**
* Increased cooldown from 15s to 20s.
	* *15 seconds is an extremely low cooldown on a decent equipment. Nerfing the cooldown indirectly makes Blast Shower slightly more appealing for equipment on use effects.*

**Gorag's Opus**
* All allies enter a frenzy for ~~7~~ 8 seconds. Increases movement speed by 50% and attack speed by 100%.
* Increased cooldown from 45s to 60s.
	* *Makes it match other equipment and synergize better with War Horn. Cooldown nerf is supposed to balance it out and make it slightly harder to achieve permanent effect. It's worth noting that it will become slightly harder to make the effect permanent thanks to Gesture of the Drowned nerf.*

**Jade Elephant**
* Gain ~~500~~ 200 armor for ~~5~~ 8 seconds.
* Increased cooldown from 45s to 60s.
	* *Jade Elephant has two issues - duration being low and effect being extremely potent. Increasing duration makes it more interesting to most players than just something they use in extreme situations. To compensate, the cooldown was increased but it still ends up as a buff (Fuel Cell amount required to make the effect permanent is lowered from 14 to 13). Now that's another issue - the effect is crazily good when permanent/almost permanent. That's why armor gained was nerfed and while numerically it seems like a big nerf, it only decreases damage reduction from 83.33% to 66.67%. This keeps it useful, fits the more broad use scenario and nerfs the permanent edge case.*

**Volcanic Egg**
* Turn into a draconic fireball for 5 seconds. Deal 500% damage on impact. Detonates at the end for ~~800%~~ 1000% damage.
	* *Generally a nice item but the final explosion's damage is a bit underwhelming, especially considering that you end up right next to the enemy.*

### Monsters

**Brass Contraption**
* Nerfed damage from 10 (+2 per level) to 9 (+1.8 per level)
	* *This is a temporary overnerf until I'll figure out how to change the damage % of the balls.*

**Elder Lemurian**
* Nerfed health from 900 (+270 per level) to 800 (+240 per level)
* Nerfed movement speed from 13 m/s to 12 m/s
	* *A total beast with high damage, health and movement speed hence the nerf.*

**Greater Wisp**
* Nerfed health from 750 (+250 per level) to 700 (+210 per level)
	* *Greater Wisps have surprisingly high health. Slight nerf will put them more in line with other enemies while still keeping them quite tanky.*

## Changelog

**1.0.3**
* Rewrote a lot of code, should be much easier to understand and probably better optimized
* Removed Needletick rebalance
* Rebalanced Jade Elephant, Gnarled Woodsprite, Gorag's Opus and Singularity Band
* Fixed some descriptions

**1.0.2**
* Fixed the description of Polylute
* Changed the rebalance of Bundle of Fireworks
* Rebalanced Wax Quail

**1.0.1**
* Removed Bundle of Fireworks change temporarily

**1.0.0**
* Release