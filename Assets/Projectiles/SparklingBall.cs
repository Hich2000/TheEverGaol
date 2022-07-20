using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace TheSauce.Assets.Projectiles
{
	public class SparklingBall : ModProjectile
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

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
				//Main.PlaySound(SoundID.Item10, Projectile.position);
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<BlackHole>(), 5, 0, Projectile.owner);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.ai[0] += 0.1f;
			Projectile.velocity *= 0.75f;
		}

    }
}