using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
	public class BrambleGlove : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bramble Glove");
			Tooltip.SetDefault("Surprisingly comfortable..." +
				"\n+15% Melee Speed and gives melee weapons autoswing" +
				"\nMinor thorns effect" +
				"\nMelee attacks inflict poison");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.GetAttackSpeed(DamageClass.Melee) *= 1.15f;
			player.thorns = 10;
			player.autoReuseGlove = true;
			modPlayer.poisonGlove = true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod,"LivingWoodHilt");
			recipe.AddIngredient(ItemID.FeralClaws);
			recipe.AddIngredient(ItemID.JungleSpores, 5);
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}