using Illuminum.Items.Materials.HM;
using Illuminum.Items.Accessories.PreHM;
using Illuminum.Items.Accessories.HM;
using Illuminum.Items.Accessories.PostML;
//using Illuminum.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using System.Collections.Generic;
using ReLogic.Content;

namespace Illuminum.NPCs.Friendly
{
	[AutoloadHead]
	public class Explorer : ModNPC
	{
        public const string ShopName = "Shop";
			public override void SetStaticDefaults()
			{
				// DisplayName automatically assigned from localization files, but the commented line below is the normal approach.
				 // DisplayName.SetDefault("Explorer");
				Main.npcFrameCount[Type] = 25; // The amount of frames the NPC has

				NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
				NPCID.Sets.AttackFrameCount[Type] = 4;
				NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
				NPCID.Sets.AttackType[Type] = 0;
				NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
				NPCID.Sets.AttackAverageChance[Type] = 30;
				NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

				// Influences how the NPC looks in the Bestiary
				NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
				{
					Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
					Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
								  // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
								  // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
				};

				NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

				// Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
				// NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
				NPC.Happiness
					.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like) // Example Person prefers the forest.
					.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
					.SetBiomeAffection<JungleBiome>(AffectionLevel.Love) // Example Person likes the Example Surface Biome
					.SetNPCAffection(NPCID.Wizard, AffectionLevel.Like) // Loves living near the dryad.
					.SetNPCAffection(NPCID.Guide, AffectionLevel.Dislike) // Likes living near the guide.
					.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate) // Dislikes living near the merchant.
					.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Love) // Hates living near the demolitionist.
				; // < Mind the semicolon!
			}

		public override void SetDefaults()
		{
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("A man who was a famous adventurer in the past. He has since retired due to old age."),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				//new FlavorTextBestiaryInfoElement("Mods.Illuminum.Bestiary.Explorer")
			});
		}

		// The PreDraw hook is useful for drawing things before our sprite is drawn or running code before the sprite is drawn
		// Returning false will allow you to manually draw your NPC
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			// This code slowly rotates the NPC in the bestiary
			// (simply checking NPC.IsABestiaryIconDummy and incrementing NPC.Rotation won't work here as it gets overridden by drawModifiers.Rotation each tick)
			if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers))
			{
				//drawModifiers.Rotation += 0.001f;

				// Replace the existing NPCBestiaryDrawModifiers with our new one with an adjusted rotation
				NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
				NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			}

			return true;
		}

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
			if (NPC.downedBoss1)
			{
				return true;
			}
			return false;
		}

		public override bool CheckConditions(int left, int right, int top, int bottom)    //Allows you to define special conditions required for this town NPC's house
		{
			return true;  //so when a house is available the npc will  spawn
		}

		public override ITownNPCProfile TownNPCProfile()
		{
			return new ExplorerProfile();
		}

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Christopher",
				"Marco",
				"Leif",
				"Clark",
				"Lewis",
				"Alexander",
                "Erik"
			};
		}

		public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window.
		{
			button = "Shop";   //this defines the buy button name
		}

        public override void OnChatButtonClicked(bool firstButton, ref string shop) //Allows you to make something happen whenever a button is clicked on this town NPC's chat window. The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
        {
			if (firstButton)
			{
                shop = ShopName;   //so when you click on buy button opens the shop
            }
		}

		public override void AddShops()
		{
			var npcShop = new NPCShop(Type, ShopName)

				.Add<AdventurersLocket>()
				.Add<CrystalTear>(Condition.DownedKingSlime)
				.Add<BloodyLens>(Condition.DownedEyeOfCthulhu)
				.Add<UnholyHeart>(Condition.DownedEowOrBoc)
				.Add(ItemID.HoneyComb, Condition.DownedQueenBee)
				.Add<SkullNecklace>(Condition.DownedSkeletron)
				.Add<AllSeeingEye>(Condition.DownedDeerclops)
				.Add<EmptyEmblem>(Condition.Hardmode)
				.Add<CrystalGuilt>(Condition.DownedQueenSlime)
				.Add<FlowerofSteel>(Condition.DownedMechBossAll)
				.Add<HeartofGaia>(Condition.DownedPlantera)
				.Add<SolarQuill>(Condition.DownedGolem)
				.Add<ClippedFin>(Condition.DownedDukeFishron)
				.Add<CrashingMedallion>(Condition.DownedEmpressOfLight)
				.Add<ElectroDrive>(Condition.DownedMartians)
				.Add<CrackedBeak>(Condition.DownedCultist)
				.Add<SolarCore>(Condition.DownedSolarPillar)
				.Add<StardustCore>(Condition.DownedStardustPillar)
				.Add<VortexCore>(Condition.DownedVortexPillar)
				.Add<NebulaCore>(Condition.DownedNebulaPillar)
				.Add<ChaliceoftheMoon>(Condition.DownedMoonLord)
				.Add(ItemID.FragmentSolar, Condition.DownedMoonLord)
				.Add(ItemID.FragmentStardust, Condition.DownedMoonLord)
				.Add(ItemID.FragmentVortex, Condition.DownedMoonLord)
				.Add(ItemID.FragmentNebula, Condition.DownedMoonLord);

            npcShop.Register();
		}

		public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
		{
			int guideNPC = NPC.FindFirstNPC(NPCID.Guide); //this make so when this npc is close to the Guide
			if (guideNPC >= 0 && Main.rand.NextBool(4)) //has 1 in 3 chance to show this message
			{
				return "That " + Main.npc[guideNPC].GivenName + " over there... He knows a bit too much about this world. Something is up with him. Keep an eye out okay?";
			}
			switch (Main.rand.Next(7))    //this are the messages when you talk to the npc
			{
				case 0:
					return "You wanna buy something? These days I usually just stay around here so I dont have much use for any of it... Yes you still have to pay!";

				case 1:
					return "You want to know how I got this stuff? That's for me to know, and for you to never find out!";

				case 2:
					return "Come around every so often. You never know when I'll find something new.";

				case 3:
					return "I've travelled all around this land and obtained many an item... Want to take a look?";

				case 4:
					return "Hey, thanks for the home and stuff... What? No I'm not going to give you a discount...";

				case 5:
					return "Y'know I used to live in a far away land. Filled with glowing rock and destroyed cities. I wonder how its doing...";

				case 6:
					return "You want to know where to go? Figure it out yourself!";

				default:
					return "I don't know why i have all this random stuff... but its fun to collect them none the less!";
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.PoisonedKnife;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

		public class ExplorerProfile : ITownNPCProfile
		{
			public int RollVariation() => 0;
			public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

			public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
			{
				if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
					return ModContent.Request<Texture2D>("Illuminum/NPCs/Friendly/Explorer");

				/*if (npc.altTexture == 1)
					return ModContent.Request<Texture2D>("ExampleMod/Content/NPCs/ExamplePerson_Party");*/

				return ModContent.Request<Texture2D>("Illuminum/NPCs/Friendly/Explorer");
			}

			public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("Illuminum/NPCs/Friendly/Explorer_Head");
		}
	}
}