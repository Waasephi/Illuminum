using Illuminum.Projectiles.Ranged.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class SporeBomb : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Bomb");
		}

		public override void SetDefaults()
		{
			Item.damage = 35;           //this is the item damage
			Item.DamageType = DamageClass.Ranged;             //this make the item do throwing damage
			Item.noMelee = true;
			Item.width = 18;
			Item.height = 24;
			Item.useTime = 40;       //this is how fast you use the item
			Item.useAnimation = 40;   //this is how fast the animation when the item is used
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 1);
			Item.rare = ItemRarityID.Blue;
			Item.reuseDelay = 10;    //this is the item delay
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;       //this make the item auto reuse
			Item.shoot = ModContent.ProjectileType<SporeBombProjectile>();
			Item.shootSpeed = 9f;     //projectile speed
			Item.useTurn = true;
			Item.maxStack = 999;       //this is the max stack of this item
			Item.consumable = true;  //this make the item consumable when used
			Item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(Mod, "VialofEvil");
			recipe.AddIngredient(ItemID.RichMahogany, 15);
			recipe.AddIngredient(ItemID.JungleSpores, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}