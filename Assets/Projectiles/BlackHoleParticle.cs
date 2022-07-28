using Terraria;
using Terraria.ModLoader;
using System;

namespace TheSauce.Assets.Projectiles
{
    public class BlackHoleParticle : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 5;
            Projectile.height = 5;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 20;
            Projectile.damage = 5;
            Projectile.DamageType = DamageClass.Magic;
        }

        public override void AI()
        {
            Projectile.Opacity -= 0.05f;
        }

    }
}