using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class CursedFury : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Cursed Fury");
			// Tooltip.SetDefault("Wooden Arrows turn into Cursed Flame Arrows.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 42;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 90);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 9f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.CursedArrow; // or ProjectileID.FireArrow;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "DarksteelPlating", 8);
			recipe.AddIngredient(ItemID.MoltenFury);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D textureGlow = ModContent.Request<Texture2D>(Item.ModItem.Texture + "_Glow").Value;
			Rectangle frame;
			if (Main.itemAnimations[Item.type] != null)
				frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
			else
				frame = texture.Frame();

			Vector2 origin = frame.Size() / 2f;

			spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, lightColor, rotation, origin, scale, SpriteEffects.None, 0f);
			spriteBatch.Draw(textureGlow, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);

			return false;
		}
	}
}