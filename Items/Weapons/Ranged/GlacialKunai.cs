using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class GlacialKunai : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacial Kunai");
		}

		public override void SetDefaults()
		{
			Item.damage = 22;           //this is the item damage
			Item.DamageType = DamageClass.Ranged;             //this make the item do throwing damage
			Item.noMelee = true;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 17;       //this is how fast you use the item
			Item.useAnimation = 17;   //this is how fast the animation when the item is used
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(silver: 1);
			Item.rare = ItemRarityID.Blue;
			Item.reuseDelay = 6;    //this is the item delay
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;       //this make the item auto reuse
			Item.shoot = ModContent.ProjectileType<GlacialKunaiProjectile>();
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
			recipe.AddIngredient(ItemID.IceBlock, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}