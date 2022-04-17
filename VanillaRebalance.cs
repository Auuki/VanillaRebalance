using BepInEx;
using BepInEx.Configuration;
using R2API;
using R2API.Utils;
using RoR2;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace VanillaRebalance
{
	//This attribute specifies that we have a dependency on R2API, as we're using it to add our item to the game.
	//You don't need this if you're not using R2API in your plugin, it's just to tell BepInEx to initialize R2API before this plugin so it's safe to use R2API.
	[BepInDependency(R2API.R2API.PluginGUID)]

	//This attribute is required, and lists metadata for your plugin.
	[BepInPlugin(PluginGUID, PluginName, PluginVersion)]

	//We will be using 2 modules from R2API: ItemAPI to add our item and LanguageAPI to add our language tokens.
	[R2APISubmoduleDependency(nameof(LanguageAPI), nameof(RecalculateStatsAPI))]

	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]

	public class VanillaRebalance : BaseUnityPlugin
	{
		//The Plugin GUID should be a unique ID for this plugin, which is human readable (as it is used in places like the config).
		//If we see this PluginGUID as it is on thunderstore, we will deprecate this mod. Change the PluginAuthor and the PluginName !
		public const string PluginGUID = PluginAuthor + "." + PluginName;
		public const string PluginAuthor = "Hayaku";
		public const string PluginName = "VanillaRebalance";
		public const string PluginVersion = "1.0.0";

		//Common/White
		public static ConfigEntry<bool> BisonSteakRebalance;
		public static ConfigEntry<bool> BundleOfFireworksRebalance;
		public static ConfigEntry<bool> BustlingFungusRebalance;
		public static ConfigEntry<bool> FocusCrystalRebalance;
		public static ConfigEntry<bool> StickyBombRebalance;
		public static ConfigEntry<bool> TougherTimesRebalance;

		//Uncommon/Green
		public static ConfigEntry<bool> AtGMissileMk1Rebalance;
		public static ConfigEntry<bool> HarvestersScytheRebalance;
		public static ConfigEntry<bool> KjarosBandRebalance;
		public static ConfigEntry<bool> PredatoryInstinctsRebalance;
		public static ConfigEntry<bool> RazorwireRebalance;
		public static ConfigEntry<bool> RunaldsBandRebalance;
		//public static ConfigEntry<bool> SquidPolypRebalance;
		public static ConfigEntry<bool> UkuleleRebalance;
		public static ConfigEntry<bool> WaxQuailRebalance;

		//Legendary/Red
		public static ConfigEntry<bool> BrilliantBehemothRebalance;

		//Boss/Yellow
		public static ConfigEntry<bool> MiredUrnRebalance;
		public static ConfigEntry<bool> ShatterspleenRebalance;
		public static ConfigEntry<bool> TitanicKnurlRebalance;

		//Lunar/Blue
		public static ConfigEntry<bool> FocusedConvergenceRebalance;
		public static ConfigEntry<bool> GestureOfTheDrownedRebalance;

		//Void/Purple
		public static ConfigEntry<bool> NeedletickRebalance;
		public static ConfigEntry<bool> PolyluteRebalance;

		//Equipment/Orange
		//public static ConfigEntry<bool> JadeElephantRebalance;
		public static ConfigEntry<bool> VolcanicEggRebalance;

		//Monsters
		public static ConfigEntry<bool> BrassContraptionRebalance;
		public static ConfigEntry<bool> ElderLemurianRebalance;
		public static ConfigEntry<bool> GreaterWispRebalance;

		void SetSurvivorStats(string survivorPrefab, Dictionary<string, float> dict)
		{
			CharacterBody component = Resources.Load<GameObject>(survivorPrefab).GetComponent<CharacterBody>();
			foreach (var item in dict)
			{
				component.SetFieldValue<float>(item.Key, item.Value);
			}
		}

		void SetSurvivorHealth(CharacterBody body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.baseMaxHealth, value);
			body.SetFieldValue<float>(SurvivorStat.levelMaxHealth, value * 0.3f);
		}
		void SetSurvivorRegen(CharacterBody body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.baseRegen, value);
			body.SetFieldValue<float>(SurvivorStat.levelRegen, value * 0.2f);
		}
		void SetSurvivorDamage(CharacterBody body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.baseDamage, value);
			body.SetFieldValue<float>(SurvivorStat.levelDamage, value * 0.2f);
		}
		void SetMiredUrn(SiphonNearbyController body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.radius, value);
		}
		void SetStickyBomb(RoR2.Projectile.ProjectileImpactExplosion body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.blastRadius, value);
		}
		void SetVolcanicEgg(FireballVehicle body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.blastDamageCoefficient, value);
		}
		void SetSurvivorMoveSpeed(CharacterBody body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.baseMoveSpeed, value);
			body.SetFieldValue<float>(SurvivorStat.levelMoveSpeed, value * 0.05f);
		}
		void SetMonsterMoveSpeed(CharacterBody body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.baseMoveSpeed, value);
		}
		void SetSurvivorArmor(CharacterBody body, float value)
		{
			body.SetFieldValue<float>(SurvivorStat.baseArmor, value);
			body.SetFieldValue<float>(SurvivorStat.levelArmor, value * 0.1f);
		}

		//The Awake() method is run at the very start when the game is initialized.
		public void Awake()
		{
			//Init our logging class so that we can properly log for debugging
			Log.Init(Logger);

			ReadConfig();
			CharacterBody cBody;

			if (BrassContraptionRebalance.Value)
			{
				cBody = GetCharacterBody(SurvivorPrefabs.BrassContraption);
				SetSurvivorDamage(cBody, 2f);
			}

			if (ElderLemurianRebalance.Value)
			{
				cBody = GetCharacterBody(SurvivorPrefabs.ElderLemurian);
				SetSurvivorHealth(cBody, 800f);
				SetMonsterMoveSpeed(cBody, 12f);
			}

			if (GreaterWispRebalance.Value)
			{
				cBody = GetCharacterBody(SurvivorPrefabs.GreaterWisp);
				SetSurvivorHealth(cBody, 700f);
			}

			//Common/White
			if (BisonSteakRebalance.Value)
				Items.BisonSteak.Changes();
			if (BundleOfFireworksRebalance.Value)
				Items.BundleOfFireworks.Changes();
			//Items.SquidPolyp.Changes();
			if (BustlingFungusRebalance.Value)
				Items.BustlingFungus.Changes();
			if (FocusCrystalRebalance.Value)
				Items.FocusCrystal.Changes();
			if (StickyBombRebalance.Value)
			{
				RoR2.Projectile.ProjectileImpactExplosion cBodyStickyBomb;
				cBodyStickyBomb = GetStickyBomb(SurvivorPrefabs.StickyBomb);
				SetStickyBomb(cBodyStickyBomb, 12f);
			}
			if (TougherTimesRebalance.Value)
				Items.TougherTimes.Changes();

			//Uncommon/Green
			if (AtGMissileMk1Rebalance.Value)
				Items.AtGMissileMk1.Changes();
			if (HarvestersScytheRebalance.Value)
				Items.HarvestersScythe.Changes();
			if (KjarosBandRebalance.Value)
				Items.KjarosBand.Changes();
			if (PredatoryInstinctsRebalance.Value)
				Items.PredatoryInstincts.Changes();
			if (RazorwireRebalance.Value)
				Items.Razorwire.Changes();
			if (RunaldsBandRebalance.Value)
				Items.RunaldsBand.Changes();
			if (UkuleleRebalance.Value)
				Items.Ukulele.Changes();
			if (WaxQuailRebalance.Value)
				Items.WaxQuail.Changes();
			//Items.SquidPolyp.Changes();

			//Legendary/Red
			if (BrilliantBehemothRebalance.Value)
			{
				Items.BrilliantBehemoth.Changes();
			}

			//Boss/Yellow
			if (MiredUrnRebalance.Value)
			{
				SiphonNearbyController cBodyMiredUrn;
				cBodyMiredUrn = GetMiredUrn(SurvivorPrefabs.MiredUrn);
				SetMiredUrn(cBodyMiredUrn, 12);
				Items.MiredUrn.Changes();
			}
			if (ShatterspleenRebalance.Value)
				Items.Shatterspleen.Changes();
			if (TitanicKnurlRebalance.Value)
				Items.TitanicKnurl.Changes();

			//Lunar/Blue
			if (FocusedConvergenceRebalance.Value)
				Items.FocusedConvergence.Changes();
			if (GestureOfTheDrownedRebalance.Value)
				Items.GestureOfTheDrowned.Changes();

			//Void/Purple
			if (NeedletickRebalance.Value)
				Items.Needletick.Changes();
			if (PolyluteRebalance.Value)
				Items.Polylute.Changes();

			//Equipment/Orange
			/*if (JadeElephantRebalance.Value)
                Items.JadeElephant.Changes();*/
			if (VolcanicEggRebalance.Value)
			{
				FireballVehicle cBodyVolcanicEgg;
				cBodyVolcanicEgg = GetFireballVehicle(SurvivorPrefabs.VolcanicEgg);
				SetVolcanicEgg(cBodyVolcanicEgg, 10f);
				Items.VolcanicEgg.Changes();
			}

			// This line of log will appear in the bepinex console when the Awake method is done.
			//Log.LogInfo(nameof(Awake) + "Done.");
		}

		//The Update() method is run on every frame of the game.
		/*private void Update()
        {
            //This if statement checks if the player has currently pressed F2.
            if (Input.GetKeyDown(KeyCode.F2))
            {
                //Get the player body to use a position:	
                var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;

                //And then drop our defined item in front of the player.
                Log.LogInfo($"Player pressed F2. Spawning our custom item at coordinates {transform.position}");
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex("ItemIndex.Squid"), transform.position, transform.forward * 20f);
            }

            //This if statement checks if the player has currently pressed F3.
            if (Input.GetKeyDown(KeyCode.F3))
            {
                var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;

                Log.LogInfo($"Player pressed F3. Spawning our custom item at coordinates {transform.position}");
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex("ItemIndex.CritGlasses"), transform.position, transform.forward * 20f);
            }
        }*/

		static class SurvivorPrefabs
		{
			public const string
			Acrid = "Prefabs/CharacterBodies/CrocoBody",
			Artificer = "Prefabs/CharacterBodies/MageBody",
			Bandit = "Prefabs/CharacterBodies/Bandit2Body",
			Captain = "Prefabs/CharacterBodies/CaptainBody",
			Commando = "Prefabs/CharacterBodies/CommandoBody",
			Engineer = "Prefabs/CharacterBodies/EngiBody",
			Huntress = "Prefabs/CharacterBodies/HuntressBody",
			Loader = "Prefabs/CharacterBodies/LoaderBody",
			Mercenary = "Prefabs/CharacterBodies/MercBody",
			MULT = "Prefabs/CharacterBodies/ToolbotBody",
			REX = "Prefabs/CharacterBodies/TreebotBody",

			BrassContraption = "Prefabs/CharacterBodies/BellBody",
			ElderLemurian = "Prefabs/CharacterBodies/LemurianBruiserBody",
			GreaterWisp = "Prefabs/CharacterBodies/GreaterWispBody",

			MiredUrn = "Prefabs/NetworkedObjects/BodyAttachments/SiphonNearbyBodyAttachment",
			StickyBomb = "Prefabs/Projectiles/StickyBomb",
			VolcanicEgg = "Prefabs/NetworkedObjects/FireballVehicle";
		}

		static class SurvivorStat
		{
			public const string
			baseMaxHealth = "baseMaxHealth",
			levelMaxHealth = "levelMaxHealth",
			baseRegen = "baseRegen",
			levelRegen = "levelRegen",
			baseDamage = "baseDamage",
			levelDamage = "levelDamage",
			baseMoveSpeed = "baseMoveSpeed",
			levelMoveSpeed = "levelMoveSpeed",
			baseArmor = "baseArmor",
			levelArmor = "levelArmor",
			baseAttackSpeed = "baseAttackSpeed",
			levelAttackSpeed = "levelAttackSpeed",
			baseCrit = "baseCrit",
			levelCrit = "levelCrit",
			baseJumpPower = "baseJumpPower",
			baseAcceleration = "baseAcceleration",

			blastDamageCoefficient = "blastDamageCoefficient",
			blastRadius = "blastRadius",
			radius = "radius";
		}

		private CharacterBody GetCharacterBody(string prefabPath)
		{
			return Resources.Load<GameObject>(prefabPath).GetComponent<CharacterBody>();
		}

		private FireballVehicle GetFireballVehicle(string prefabPath)
		{
			return Resources.Load<GameObject>(prefabPath).GetComponent<FireballVehicle>();
		}
		private RoR2.SiphonNearbyController GetMiredUrn(string prefabPath)
		{
			return Resources.Load<GameObject>(prefabPath).GetComponent<RoR2.SiphonNearbyController>();
		}

		private RoR2.Projectile.ProjectileImpactExplosion GetStickyBomb(string prefabPath)
		{
			return Resources.Load<GameObject>(prefabPath).GetComponent<RoR2.Projectile.ProjectileImpactExplosion>();
		}

		public void ReadConfig()
		{
			//Common/White
			BisonSteakRebalance = Config.Bind<bool>(new ConfigDefinition("BisonSteak", "Enable Changes"), true, new ConfigDescription("Enables changes to Bison Steak.", null, Array.Empty<object>()));
			BundleOfFireworksRebalance = Config.Bind<bool>(new ConfigDefinition("BundleOfFireworks", "Enable Changes"), true, new ConfigDescription("Enables changes to Bundle of Fireworks.", null, Array.Empty<object>()));
			BustlingFungusRebalance = Config.Bind<bool>(new ConfigDefinition("BustlingFungus", "Enable Changes"), true, new ConfigDescription("Enables changes to Bustling Fungus.", null, Array.Empty<object>()));
			FocusCrystalRebalance = Config.Bind<bool>(new ConfigDefinition("BustlingFungus", "Enable Changes"), true, new ConfigDescription("Enables changes to Bustling Fungus.", null, Array.Empty<object>()));
			StickyBombRebalance = Config.Bind<bool>(new ConfigDefinition("FocusCrystal", "Enable Changes"), true, new ConfigDescription("Enables changes to Focus Crystal.", null, Array.Empty<object>()));
			TougherTimesRebalance = Config.Bind<bool>(new ConfigDefinition("TougherTimes", "Enable Changes"), true, new ConfigDescription("Enables changes to Tougher Times.", null, Array.Empty<object>()));

			//Uncommon/Green
			AtGMissileMk1Rebalance = Config.Bind<bool>(new ConfigDefinition("AtGMissileMk1", "Enable Changes"), true, new ConfigDescription("Enables changes to AtG Missile Mk. 1.", null, Array.Empty<object>()));
			HarvestersScytheRebalance = Config.Bind<bool>(new ConfigDefinition("HarvestersScythe", "Enable Changes"), true, new ConfigDescription("Enables changes to Harvester's Scythe.", null, Array.Empty<object>()));
			KjarosBandRebalance = Config.Bind<bool>(new ConfigDefinition("KjarosBand", "Enable Changes"), true, new ConfigDescription("Enables changes to Kjaro's Band.", null, Array.Empty<object>()));
			PredatoryInstinctsRebalance = Config.Bind<bool>(new ConfigDefinition("PredatoryInstincts", "Enable Changes"), true, new ConfigDescription("Enables changes to Predatory Instincts.", null, Array.Empty<object>()));
			RazorwireRebalance = Config.Bind<bool>(new ConfigDefinition("Razorwire", "Enable Changes"), true, new ConfigDescription("Enables changes to Razorwire.", null, Array.Empty<object>()));
			RunaldsBandRebalance = Config.Bind<bool>(new ConfigDefinition("RunaldsBand", "Enable Changes"), true, new ConfigDescription("Enables changes to Runald's Band.", null, Array.Empty<object>()));
			UkuleleRebalance = Config.Bind<bool>(new ConfigDefinition("Ukulele", "Enable Changes"), true, new ConfigDescription("Enables changes to Ukulele.", null, Array.Empty<object>()));
			WaxQuailRebalance = Config.Bind<bool>(new ConfigDefinition("WaxQuail", "Enable Changes"), true, new ConfigDescription("Enables changes to Wax Quail.", null, Array.Empty<object>()));

			//Legendary/Red
			BrilliantBehemothRebalance = Config.Bind<bool>(new ConfigDefinition("BrilliantBehemoth", "Enable Changes"), true, new ConfigDescription("Enables changes to Brilliant Behemoth.", null, Array.Empty<object>()));

			//Boss/Yellow
			MiredUrnRebalance = Config.Bind<bool>(new ConfigDefinition("MiredUrn", "Enable Changes"), true, new ConfigDescription("Enables changes to Mired Urn.", null, Array.Empty<object>()));
			ShatterspleenRebalance = Config.Bind<bool>(new ConfigDefinition("Shatterspleen", "Enable Changes"), true, new ConfigDescription("Enables changes to Shatterspleen.", null, Array.Empty<object>()));
			TitanicKnurlRebalance = Config.Bind<bool>(new ConfigDefinition("TitanicKnurl", "Enable Changes"), true, new ConfigDescription("Enables changes to Titanic Knurl.", null, Array.Empty<object>()));

			//Lunar/Blue
			FocusedConvergenceRebalance = Config.Bind<bool>(new ConfigDefinition("FocusedConvergence", "Enable Changes"), true, new ConfigDescription("Enables changes to Focused Convergence.", null, Array.Empty<object>()));
			GestureOfTheDrownedRebalance = Config.Bind<bool>(new ConfigDefinition("GestureOfTheDrowned", "Enable Changes"), true, new ConfigDescription("Enables changes to Gesture of the Drowned.", null, Array.Empty<object>()));

			//Void/Purple
			NeedletickRebalance = Config.Bind<bool>(new ConfigDefinition("Needletick", "Enable Changes"), true, new ConfigDescription("Enables changes to Needletick.", null, Array.Empty<object>()));
			PolyluteRebalance = Config.Bind<bool>(new ConfigDefinition("Polylute", "Enable Changes"), true, new ConfigDescription("Enables changes to Polylute.", null, Array.Empty<object>()));

			//Equipment/Orange
			//JadeElephantRebalance = Config.Bind<bool>(new ConfigDefinition("JadeElephant", "Enable Changes"), true, new ConfigDescription("Enables changes to Jade Elephant.", null, Array.Empty<object>()));
			VolcanicEggRebalance = Config.Bind<bool>(new ConfigDefinition("VolcanicEgg", "Enable Changes"), true, new ConfigDescription("Enables changes to Volcanic Egg.", null, Array.Empty<object>()));

			//Monsters
			BrassContraptionRebalance = Config.Bind<bool>(new ConfigDefinition("BrassContraption", "Enable Changes"), true, new ConfigDescription("Enables changes to Brass Contraption.", null, Array.Empty<object>()));
			ElderLemurianRebalance = Config.Bind<bool>(new ConfigDefinition("ElderLemurian", "Enable Changes"), true, new ConfigDescription("Enables changes to Elder Lemurian.", null, Array.Empty<object>()));
			GreaterWispRebalance = Config.Bind<bool>(new ConfigDefinition("GreaterWisp", "Enable Changes"), true, new ConfigDescription("Enables changes to Greater Wisp.", null, Array.Empty<object>()));
		}
	}
}
