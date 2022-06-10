## About

VanillaRebalance aims at balancing vanilla without changing the effects of items/monsters/survivors. Every change can be disabled through the config. It is my first mod, I'm still learning how to change more values so expect many more adjustments to come. I will start adjusting survivors in the future.

## Key aspects

**Staying true to vanilla**
* VanillaRebalance does not change the vanilla effects. This means you get the exact same vanilla experience but with a better balance. It is important to note that this also puts a limitation on the mod - VanillaRebalance cannot properly balance some items like Bison Steak because its vanilla effect is lackluster and impossible to properly balance just by changing the only number that can be changed.

**AoE unification**
* AoE ranges in RoR2 are all over the place. One of the goals of VanillaRebalance is to unify them to make it easier for the player to get a feel of certain ranges as well as improve the balance. Based on vanilla, the factor of 4m was chosen (4m, 8m, 12m, 16m, etc.).

## Changes

### Items

**Bison Steak**
* Increases maximum health by ~~25~~ 30 (+~~25~~ 30 per stack).
	* *Currently Bison Steak gives less than 1 level worth of maximum health even on Huntress who has the lowest hp per level (27). Increasing the amount of maximum health gained will make it more useful early on and keep it reasonably useful at later stages. Anything higher than 30 would undermine Infusion.*

**Bundle of Fireworks**
* Activating an interactable launches ~~8~~ 5 (+~~4~~ 5 per stack) fireworks that deal ~~300%~~ 360% base damage.
* Increased explosion radius from 5m to 8m.
	* *It's a nerf at less than 2 stacks but at early levels many fireworks go to waste anyway cause of lack of enemies. Change helps with scaling at higher stacks which was very underwhelming as well as helps hitting enemies/more enemies thanks to increased AoE.*

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

**Harvester's Scythe**
* Gain 5% critical chance. Critical strikes heal for ~~8~~ 4 (+4 per stack) health.
	* *Heal nerf puts it more in line with Leeching Seed as the first Harvester's Scythe only requires 16% critical strike chance to outperform the seed (26% after the nerf).*

**Hunter's Harpoon**
* Killing an enemy increases movement speed by ~~125%~~ 100%, fading over ~~1~~ 1.5 (+~~0.5~~ 0.75 per stack) seconds.
	* *Effect is extremely short and is powerful enough to make movement annoying because of the short but strong bursts.*

**Kjaro's Band**
* Hits that deal more than 400% damage also blast enemies with a runic flame tornado, dealing ~~300%~~ 250% (+~~300%~~ 250% per stack) TOTAL damage over time. Recharges every 10 seconds.
	* *Kjaro's Band in most cases outdamages Runald's Band thanks to higher possible total damage and big AoE hence it was toned down.*

**Predatory Instincts**
* Gain 5% critical chance. Critical strikes increase attack speed by ~~12%~~ 10%. Maximum cap of ~~36%~~ 30% (+~~24%~~ 20% per stack) attack speed.
	* *Predatory Instincts is very powerful in the right hands, especially Bandit or Huntress using Flurry. Nerf puts it in a much more fair spot considering the standard 15% increase from Soldier's Syringe. It has an unlisted 5% critical chance which works just like Harvester's Scythe and Predatory Instincts so it was added to the tooltip.*

**Razorwire**
* Getting hit causes you to explode in a burst of razors, dealing 160% damage. Hits up to 5 (+2 per stack) targets in a ~~25m~~ 20m (+~~10m~~ 2m per stack) radius.
	* *The radius is enormous so it was decreased to match the Ukulele.*

**Ukulele**
* ~~25%~~ 20% chance to fire chain lightning for 80% TOTAL damage on up to 3 (+2 per stack) targets within 20m (+2m per stack).
	* *Ukulele is very strong, I'd consider decreasing the damage but 25% chance to trigger is very high so lets start there. This way it also matches Sentient Meat Hook's listed base chance (cause in reality it's 16,7%).*

**War Horn**
* Activating your Equipment gives you +~~70%~~ 40% `(+20% per stack)` attack speed for 8s (+4s per stack).
	* *The way War Horn stacks is underwhelming, making it not worth stacking beyond a certain threshold even as low as a single horn. This change helps with that. The initial buff was nerfed to compensate for it but it becomes better starting from 3 stacks. Keep in mind that it's fairly easy to make War Horn effect permanent/almost permanent, which is also addressed by nerfing Gesture of the Drowned. What we end up with is an item that will still be scrapped by people who don't intend to use equipment too much/use long cooldown ones but stacks well for people who intend to use it, becoming more rewarding.*

**Wax Quail**
* Jumping while sprinting boosts you forward by ~~10m~~ 14m (+~~10m~~ 7m per stack).
	* *Just a few Wax Quails (even less with other movement speed increasing items) are enough for jumping while sprinting to get out of hand. Oftentimes people don't want to pick them at stacks even as low as around 5. Initial Wax Quail usually doesn't help too much hence the buff to initial value. Stacking nerf kicks in at 3 and above, making it more manageable while keeping it useful. Values were chosen based on the base movement speed of survivors, which is 7m/s.*

**Brilliant Behemoth**
* All your attacks explode in a 4m (+~~2.5m~~ 2m per stack) radius for a bonus 60% TOTAL damage to nearby enemies.
	* *A small nerf based on AoE unification.*

**Frost Relic**
* Killing an enemy surrounds you with an ice storm that deals 300% damage every 0.25s and slows enemies by 80% for 1.5s. The storm grows with every kill, increasing its radius by ~~2m~~ 1m. Stacks up to ~~18m~~ 16m (+~~12m~~ 8m per stack).
	* *Frost Relic used to be weak, but now it has become a bit too powerful. I don't think nerfing damage is a good idea as it was the main issue in the past so I've nerfed radius to match Warbanner, which is also a part of AoE unification. With a potential of such a big radius, once it reaches a certain size, it can easily fuel itself while also creating a lot of hits which create a lot of effects (although at low proc coefficient). Damage number change is just to better represent the actual behavior of the item. Initial radius increased from 6m to 8m but radius per kill decreased from 2m to 1m, otherwise it would end up as a buff.*

**Unstable Tesla Coil**
* Decreased radius from 35m to 32m.
	* *A small nerf based on AoE unification.*
* Added to AIBlacklist.
	* *When enemies get Unstable Tesla Coil in Void Fields, it's almost a guaranteed end of the run.*

**Mired Urn**
* While in combat, the nearest 1 (+1 per stack) enemies to you within ~~13m~~ 12m will be 'tethered' to you, dealing 100% damage per second, applying tar, and healing you for 100% of the damage dealt.
	* *Made to match Focus Crystal's range after the change.*

**Shatterspleen**
* Gain 5% critical chance. Critical Strikes bleed enemies for 240% base damage. Bleeding enemies explode on death for 400% (+400% per stack) damage ~~, plus an additional 15% (+15% per stack) of their maximum health.~~
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
* ~~25%~~ 20% chance to fire lightning for 60% TOTAL damage up to 3 (+2 per stack) times. Corrupts all Ukuleles.
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

**Blind Pest**
* Nerfed spit range from 70m to 50m
	* *Blind Pest is more annoying than Vulture thanks to faster movement speed, faster projectile speed and further range. I've decided that range is going to be the best nerf as it will bring them closer to the survivors making them easier to kill.*

**Blind Vermin**
* Nerfed movement speed from 13 m/s to 12m/s.
	* *Blind Vermin is crazy fast for an enemy that can appear on a 2nd stage so it was slightly toned down.*

**Brass Contraption**
* Buffed damage from 10 (+2 per level) to 12 (+2.4 per level).
* Nerfed damage coefficient from 5 to 4.
	* *Damage dealt by Brass Contraptions can be ridiculously high and oftentimes as elites they can one-shot the player (blazing/overloading). Above changes will result in a whopping 4% damage nerf which may sound ridiculous but is meant to tone them down slightly without making them too weak early on.*

**Elder Lemurian**
* Nerfed health from 900 (+270 per level) to 800 (+240 per level).
* Nerfed movement speed from 13 m/s to 12 m/s.
* Nerfed fireball amount from 5 to 3 and their spread from 45&deg; to 20&deg;.
	* *A total beast with high damage, health and movement speed hence the nerf.*

**Greater Wisp**
* Nerfed health from 750 (+225 per level) to 700 (+210 per level).
	* *Greater Wisps have surprisingly high health. Slight nerf will put them more in line with other enemies while still keeping them quite tanky.*

<!--### Survivors

**Acrid**
* Buffed Neurotoxin damage from 240% to 320%.

**Captain**
* Nerfed Vulcan Shotgun damage from 8x120% to 8x100%, proc coefficient from 0.75 to 0.5 and buffed charge duration from 1.2s to 1s.
* Buffed Power Tazer damage from 100% to 200%.
* Nerfed Orbital Probe cooldown from 11s to 12s.

**Huntress**
* Buffed Strafe damage from 150% to 200%.
* Buffed Flurry duration from 1.3s to 1.2s and nerfed proc coefficient from 0.7 to 0.6.
* Buffed Arrow Rain radius from 7.5m to 8m.
* Buffed Ballista damage from 3x900% to 3x1000%.

**MUL-T**
* Buffed Blast Canister damage from 220% to 250% and bomblets damage from 5x44% to 5x50%.
-->
## Changelog

**1.0.8**
* Rebalanced Unstable Tesla Coil, Preon Accumulator and Blind Pest
* Changed the rebalance of Polylute

**1.0.7**
* Rebalanced Hunter's Harpoon and War Horn
* Fixed Singularity Band visual indicator showing vanilla range
* Rewrote a lot of code again

**1.0.6**
* Rebalanced Blind Vermin
* Changed the rebalance of Razorwire, Bundle of Fireworks, Elder Lemurian and Brass Contraption
* Added Unstable Tesla Coil to AIBlacklist
* Fixed some wrong names in the config
* Fixed Focus Crystal visual indicator showing vanilla range

**1.0.5**
* Rebalanced Frost Relic
* Changed the rebalance of Kjaro's Band
* Removed AtG Missile Mk. 1 and Runald's Band rebalance

**1.0.4**
* Added the missing README

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