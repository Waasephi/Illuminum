using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using Illuminum.Tiles.Decor;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Enemies
{
	public class AngeliteTotem : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Totem");
			Main.npcFrameCount[NPC.type] = 1;
		}
		int _delay = 0;
		int _reload = 0;
		public override void SetDefaults()
		{
			_reload = 0;
			_delay = 0;
			NPC.width = 26;
			NPC.height = 44;
			NPC.damage = 35;
			NPC.lifeMax = 250;
			NPC.life = 250;
			NPC.defense = 40;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.knockBackResist = 0f;
			NPC.value = 1000f;
			NPC.lavaImmune	=	true;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<AngeliteTotemBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundHallow,
				new FlavorTextBestiaryInfoElement("A totem of pure Angelite, It is unknown how they were made.")
			});
		}

		/*public override void AI()
		{
			if (Main.player[NPC.target].Center.X > NPC.Center.X)
				NPC.spriteDirection = 0;
			else
				NPC.spriteDirection = 0;
			Vector2 adj;
			adj.X = -NPC.width / 4;
			adj.Y = -NPC.height / 2;
			_delay--;
			if (_delay <= 0)
			{
				_reload++;
				if (_reload < 45)
				{
					if (Main.rand.NextBool(4))
					{
						if (Main.netMode != NetmodeID.MultiplayerClient)
							Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, NPC.velocity.X - 4 + Main.rand.Next(9), -Main.rand.Next(6, 9), ProjectileID.DD2DarkMageBolt, (int)(NPC.damage / 2), 3, Main.myPlayer);
					}
				}
				else
				{
					_reload = 0;
					_delay = 240;
				}
			}

		}*/

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneRockLayerHeight && spawnInfo.Player.ZoneHallow ? 0.5f : 0f;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AngeliteChunk>(), 1, 1, 5));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AngeliteTotemItem>(), 20, 1, 1));
		}

	}
}