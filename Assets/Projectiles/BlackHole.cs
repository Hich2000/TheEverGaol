using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;

namespace TheSauce.Assets.Projectiles
{
    public class BlackHole : ModProjectile
    {

		public static BlackHole currentInstance = null;

		public BlackHoleEffect currentEffect = null;

		public Random spawnRandomizer = new Random();

		public int starDamage = 200;
		public int particleDamage = 10;

		public float starRadius = 350;
		public float particleRadius = 100;

		public override void SetDefaults()
		{
			Projectile.width = 150;
			Projectile.height = 125;
			Projectile.friendly = true;
			Projectile.penetrate = int.MaxValue;
			Projectile.timeLeft = 800;
			Projectile.ai[0] = 0;
			Projectile.hide = true;
			Projectile.tileCollide = false;
			Projectile.damage = 0;
			Projectile.DamageType = DamageClass.Magic;
		}

        public override void AI()
        {

			float angle = (float)(2.0 * Math.PI * spawnRandomizer.NextDouble());
			float angleCos = (float)Math.Cos(angle);
			float angleSin = (float)Math.Sin(angle);
			float movementMultiplier = 5;

			Vector2 starSpawnPosition = Projectile.Center;
			starSpawnPosition.X = (float)(starSpawnPosition.X + (angleCos * starRadius));
			starSpawnPosition.Y = (float)(starSpawnPosition.Y + (angleSin * starRadius));

            Vector2 particleSpawnPosition = Projectile.Center;
            particleSpawnPosition.X = (float)(particleSpawnPosition.X + (angleCos * particleRadius));
            particleSpawnPosition.Y = (float)(particleSpawnPosition.Y + (angleSin * particleRadius));

            Vector2 particleMovement = new Vector2(-angleCos * movementMultiplier, -angleSin * movementMultiplier);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), particleSpawnPosition, particleMovement, ModContent.ProjectileType<BlackHoleParticle>(), particleDamage, 0, Main.myPlayer);

            Projectile.ai[0] = (Projectile.ai[0] + 1) % 30;
			if (Projectile.ai[0] == 0)
            {				
				Vector2 starMovement = Vector2.Zero;
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), starSpawnPosition, starMovement, ModContent.ProjectileType<BlackHoleStar>(), starDamage, 0, Main.myPlayer, Projectile.Center.X, Projectile.Center.Y);
			}

		}

		public override void Kill(int timeLeft = 0)
		{
			base.Kill(0);
			currentInstance = null;
		}

		public override void OnSpawn(IEntitySource source)
		{
			base.OnSpawn(source);
			if (currentInstance != null)
			{
				currentInstance.Projectile.Kill();
				currentInstance = this;
			}
			else
			{
				currentInstance = this;
			}

			currentInstance = this;
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<BlackHoleEffect>(), 0, 0, Main.myPlayer);
		}

		public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCs.Add(index);
            behindProjectiles.Add(index);
        }

    }
}
