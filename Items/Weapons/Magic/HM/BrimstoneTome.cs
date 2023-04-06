using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Misc.HM;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Magic.HM
{
	public class BrimstoneTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimstone Wave");
		}

		public override void SetDefaults()
		{
			Item.damage = 58;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.crit = 8;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrimstoneWave>();
			Item.shootSpeed = 12f;
			Item.mana = 10;
			Item.noMelee = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, ai1: 3);
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, ai1: 4);
			return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BrimstoneCrystal", 12);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddTile(TileID.MythrilAnvil);
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