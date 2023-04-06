using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Buffs;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class BloodstoneBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloodstone Bow");
			Tooltip.SetDefault("Shoots 2 arrows at above half max life" +
                "\nUsing this bow above half max life drain health" +
                "\n'An eye for an eye'");
		}

		public override void SetDefaults() 
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 42;
			Item.useTime = 27;
			Item.useAnimation = 27;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 57);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 7f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.statLife >= player.statLifeMax2 / 2)
				{
				const int NumProjectiles = 1;

				for (int i = 0; i < NumProjectiles; i++)
				{

					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));


					newVelocity *= 1f - Main.rand.NextFloat(0.1f);


					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}

				IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
				if (modPlayer.hematiteSet == false)
				{
					CombatText.NewText(player.getRect(), Color.Red, "9", true, false);
					player.statLife -= 9;
					if (player.statLife <= 0)
					{
						player.AddBuff(ModContent.BuffType<BloodFlame>(), 60);
					}
				}
				
			}
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BloodShard", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}