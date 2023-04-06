using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Illuminum.Projectiles.Melee.HM;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Melee.HM
{
	public class BlindingSun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blinding Sun");
			Tooltip.SetDefault("Shoots 2 beams of sunlight" +
                "\nMelee hits inflict Daybroken and spawn a fireball on crits" +
                "\nThe beams of sunlight pierce infinitely for a short duration" +
                "\n'Blinding like an eclipse'");
		}

		public override void SetDefaults()
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Melee;
			Item.width = 80;
			Item.height = 80;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.crit = 8;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<RadianceProj>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shootSpeed = 14f;
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

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.AddBuff(BuffID.Daybreak, 240);
			if (crit)
			{
				SoundEngine.PlaySound(SoundID.Item20, player.Center);
				IlluminumPlayer.ScreenShakeAmount = 5;
				for (int i = 0; i < Main.rand.Next(1, 1); i++)
					Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(0, 0), Main.rand.NextFloat(0, 0)), ProjectileID.InfernoFriendlyBlast, 60, knockBack / 2, player.whoAmI);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(Mod, "Sol");
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