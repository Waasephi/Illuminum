using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Illuminum.Projectiles.Melee.HM;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Melee.HM
{
	public class Sol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sol");
			Tooltip.SetDefault("Shoots a beam of sunlight and inflicts Daybroken on melee hits" +
                "\nThe beams of sunlight pierce infinitely for a short duration" +
                "\n'Shining like the sun'");
		}

		public override void SetDefaults()
		{
			Item.damage = 65;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ModContent.ProjectileType<RadianceProj>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shootSpeed = 14f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
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