using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using TheSauce.Assets.Dusts;

namespace TheSauce.Assets.Projectiles
{
	public class Singularity : ModProjectile
	{

		public int blackHoleDamage = 0;

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 80;
			Projectile.damage = 0;
			Projectile.DamageType = DamageClass.Magic;
		}

		public override void AI()
		{
			Projectile.rotation += 0.4f;
			Projectile.velocity.X = Projectile.velocity.X * 0.95f;
			Projectile.velocity.Y = Projectile.velocity.Y * 0.95f;
            Dust.NewDust(Projectile.position, 10, 10, ModContent.DustType<DarkParticle>());
        }

		public override void Kill(int timeLeft = 0)
		{
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<BlackHole>(), blackHoleDamage, 0, Main.myPlayer);
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