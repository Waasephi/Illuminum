using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Accessories.PreHM;

namespace Illuminum.Items.Accessories.HM
{
	[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
	public class PrismaticGauntlet : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Prismatic Gauntlet");
			/* Tooltip.SetDefault("It glitters in the light " +
				"\n+12% Whip speed and gives whips autoswing" +
				"\n+10% summon damage" +
				"\nIncreased knockback" +
				"\nWhips randomly apply debuffs"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) *= 1.12f;
			player.kbGlove = true;
			player.autoReuseGlove = true;
			player.GetDamage(DamageClass.Summon) += 0.1f;
			modPlayer.prismaticGauntlet = true; //Allows the player to disable extra dust spawns. May improve preformance, and allows more dust spam
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.Purple;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PowerGlove);
			recipe.AddIngredient(ModContent.ItemType<QuartzLacedGlove>(), 1);			
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddIngredient(ItemID.Ruby, 10);
			recipe.AddIngredient(ItemID.Amber, 10);
			recipe.AddIngredient(ItemID.Topaz, 10);
			recipe.AddIngredient(ItemID.Emerald, 10);
			recipe.AddIngredient(ItemID.Sapphire, 10);
			recipe.AddIngredient(ItemID.Amethyst, 10);
			recipe.AddIngredient(ItemID.Diamond, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}