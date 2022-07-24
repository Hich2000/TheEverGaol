using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace TheSauce.Assets.Projectiles
{
    public class BlackHole : ModProjectile
    {

		public float radius = 350;

		public static int maxInstances = 1;
		public static BlackHole[] blackHoleInstances = new BlackHole[maxInstances];
		public static BlackHole currentInstance = null;
		public Random spawnRandomizer = new Random();

		public bool test = true;

		public override void SetDefaults()
		{
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.friendly = true;
			Projectile.penetrate = 1000;
			Projectile.timeLeft = 600;
			Projectile.ai[0] = 0;
		}

        public override void AI()
        {
			Projectile.ai[0] = (Projectile.ai[0]+1)%30;

			if (Projectile.ai[0] == 0)
            {
				float angle = (float)(2.0 * Math.PI * spawnRandomizer.NextDouble());

				Console.WriteLine("spawnAngle: "+angle);
				Console.WriteLine("\n");

				float angleCos = (float)Math.Cos(angle);
				float angleSin = (float)Math.Sin(angle);
				float movementMultiplier = 5;

				Vector2 spawnPosition = Projectile.Center;
				Vector2 starMovement = new Vector2(-angleCos * movementMultiplier, -angleSin * movementMultiplier);

				spawnPosition.X = (float)(spawnPosition.X + (angleCos * radius));
				spawnPosition.Y = (float)(spawnPosition.Y + (angleSin * radius));

				starMovement = Vector2.Zero;

				Projectile.NewProjectile(Projectile.InheritSource(Projectile), spawnPosition, starMovement, ModContent.ProjectileType<BlackHoleStar>(), 5, 0, Projectile.owner, Projectile.Center.X, Projectile.Center.Y);
			}
        }

		public override void Kill(int timeLeft = 0)
		{
			base.Kill(0);
			blackHoleInstances[0] = null;
		}

		public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
			if (blackHoleInstances[0] != null)
            {
				blackHoleInstances[0].Projectile.Kill();
				blackHoleInstances[0] = this;
			} else
            {
                blackHoleInstances[0] = this;
            }

			currentInstance = this;
        }


    }
}
