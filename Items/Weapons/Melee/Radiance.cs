using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Illuminum.Projectiles;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Melee
{
	public class Radiance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiance");
			Tooltip.SetDefault("Shining like the sun.");
		}

		public override void SetDefaults()
		{
			Item.damage = 76;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<RadianceProj>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shootSpeed = 14f;
			Item.scale *= 1.2f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Daybreak, 120);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.PixieDust, 20);
			recipe.AddIngredient(Mod, "Daylight");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 2;

			for (int i = 0; i < NumProjectiles; i++)
			{

				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));


				//newVelocity *= 1f - Main.rand.NextFloat(0.3f);


				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}
	}
}