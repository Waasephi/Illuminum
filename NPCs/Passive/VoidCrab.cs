//using Illuminum.Items.Banners;
using Illuminum.Items.Consumables;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Biomes.Voidlands;
using Terraria.GameContent.ItemDropRules;

namespace Illuminum.NPCs.Passive
{
	public class VoidCrab : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Crab");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.width = 42;
			NPC.height = 34;
			NPC.damage = 0;
			NPC.lifeMax = 200;
			NPC.life = 200;
			NPC.defense = 20;
			NPC.HitSound = SoundID.NPCHit13;
			NPC.DeathSound = SoundID.NPCDeath11;
			NPC.aiStyle = 3;
			AIType = NPCID.Crab;
			AnimationType = NPCID.Crab;
			NPC.knockBackResist = 0f;
			//banner = NPC.type;
			NPC.friendly = false;
			//bannerItem = ModContent.ItemType<VoidCrabBanner>();
			SpawnModBiomes = new int[1] { ModContent.GetInstance<VoidlandsUndergroundBiome>().Type };
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.InModBiome(ModContent.GetInstance<VoidlandsUndergroundBiome>()) ? 1f : 0f;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VoidCrabLegs>(), 50, 1, 1));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("Interestingly enough, the beings in the Voidlands seem to be in control of themselves..." +
                "\nWe are still unsure if they are alive, but these crabs seem to be passive.")
			});
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int amount = NPC.life <= 0 ? 10 : 2;

			for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.TintableDust, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
			if (NPC.life <= 0)
			{
				for (int i = 0; i < 3; i++)
				{
					Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("Illuminum/VoidCrabGore" + (i + 1)).Type, 1);
				}
			}
		}
	}
}