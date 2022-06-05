using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
	public class EnvenomedGauntlet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Envenomed Gauntlet");
			Tooltip.SetDefault("Don't touch it. " +
				"\n+12% Melee Speed and gives melee weapons autoswing" +
				"\n+10% Melee Damage" +
				"\nIncreased Knockback" +
				"\nThorns and Flask of Venom effects.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.GetAttackSpeed(DamageClass.Melee) *= 1.12f;
			player.kbGlove = true;
			player.autoReuseGlove = true;
			player.GetDamage(DamageClass.Melee) += 0.1f;
			player.AddBuff(BuffID.Thorns, 2);
			modPlayer.venomGauntlet = true; //Allows the player to disable extra dust spawns. May improve preformance, and allows more dust spam
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
			recipe.AddIngredient(ItemID.TitanGlove);
			recipe.AddIngredient(ModContent.ItemType<BrambleGlove>(), 1);
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}