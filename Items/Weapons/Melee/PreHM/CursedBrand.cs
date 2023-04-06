using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Illuminum.Projectiles;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class CursedBrand : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cursed Brand");
			Tooltip.SetDefault("Inflicts cursed inferno" +
                "\nCritical hits cause cursed flames to erupt from enemies");
		}

		public override void SetDefaults() 
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.crit = 8;
			Item.value = Item.sellPrice(silver: 78);
			Item.rare = ItemRarityID.Orange;
			Item.scale = 1.2f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 5f;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(2))
			{
				//Emit dusts when the sword is swung
				Dust dust = Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CursedTorch);
				dust.noGravity = true;
				dust.scale = 2f;
			}
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(BuffID.CursedInferno, 180);
			if (crit)
			{
				SoundEngine.PlaySound(SoundID.Item20, player.Center);
				for (int i = 0; i < Main.rand.Next(2, 4); i++)
					Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-3, -5)), ProjectileID.CursedDartFlame, 30, knockBack / 2, player.whoAmI);
			}
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "DarksteelPlating", 8);
			recipe.AddIngredient(ItemID.FieryGreatsword);
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