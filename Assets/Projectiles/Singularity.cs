using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace TheSauce.Assets.Projectiles
{
	public class Singularity : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 50;
		}

		public override void AI()
		{
			Projectile.velocity.X = Projectile.velocity.X * 0.95f;
			Projectile.velocity.Y = Projectile.velocity.Y * 0.95f;
			//Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
		}

		public override void Kill(int timeLeft = 0)
		{
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<BlackHole>(), 5, 0, Projectile.owner);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.Kill();
		}

    }
}