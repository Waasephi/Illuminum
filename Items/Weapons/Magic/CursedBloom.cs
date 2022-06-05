using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Magic
{
	public class CursedBloom : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Bloom");
		}

		public override void SetDefaults()
		{
			Item.damage = 37;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 90);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.CursedFlameFriendly;
			Item.shootSpeed = 8f;
			Item.mana = 14;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "DarksteelPlating", 8);
			recipe.AddIngredient(ItemID.FlowerofFire); //Flower of Fire
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}