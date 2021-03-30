using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Turret : GameObject
    {
        Bullets Bullet = null;
        private float TurretAngle = 1.0f;

        public Turret(string Filename) : base(Filename)
        {
            //Bullet = new Bullets("../Images/Bullet.png");
            //Bullet.SetParent(this);
            collisionEnabled = false;
            m_LocalTransForm.m7 = 0;
            m_LocalTransForm.m8 = 25;
        }

        public override void Update(float fDeltaTime)
        {
            float angle = 0.0f;

            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                angle -= TurretAngle * fDeltaTime;
            }

            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                angle += TurretAngle * fDeltaTime;
            }

            Matrix3 rotation = new Matrix3();
            rotation.Identity();
            rotation.SetRotateZ(angle);
            m_LocalTransForm = m_LocalTransForm * rotation;

            base.Update(fDeltaTime);

        }
    }
}