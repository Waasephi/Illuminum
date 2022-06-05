using Terraria.ID;
using Terraria;
using Illuminum.Projectiles;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
    public class Brimlance : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimlance");
		}

		public override void SetDefaults()
		{
			Item.damage = 68;           //this is the item damage
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 32;       //this is how fast you use the item
			Item.useAnimation = 32;   //this is how fast the animation when the item is used
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.reuseDelay = 6;    //this is the item delay
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;       //this make the item auto reuse
			Item.shoot = ModContent.ProjectileType<BrimlanceProjectile>();
			Item.shootSpeed = 14f;     //projectile speed
			Item.useTurn = true;
			Item.maxStack = 1;       //this is the max stack of this item
			Item.consumable = false;  //this make the item consumable when used
			Item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BrimstoneCrystal", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}