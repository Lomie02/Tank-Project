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
    class Tank : GameObject
    {

        private Vector3 m_v2Velocity;
        private int m_nHP;
        private int m_nAmmo;
        private float m_fSpeed = 10.0f;
        private float m_fRotationSpeed = 1.0f;
        Turret Turret1 = null;
        //public float m_Speed = 3.0f;
        
        public Tank(string fileName) : base(fileName)
        {
            Turret1 = new Turret("../Images/Turret.png");
            Turret1.SetParent(this);

            m_LocalTransForm.m7 = 400;        //X Position
            m_LocalTransForm.m8 = 600;        //Y Position

            m_v2Velocity.x = 0;
            m_v2Velocity.y = 0;
            
        }

        public override void Update(float fDeltaTime)
        {
            float angle = 0.0f;

            if (IsKeyDown
                (KeyboardKey.KEY_W))
            {
                m_v2Velocity.y -= m_fSpeed * fDeltaTime;
            }

            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                m_v2Velocity.y += m_fSpeed * fDeltaTime;
            }

            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                angle -= m_fRotationSpeed * fDeltaTime;
            }

            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                angle += m_fRotationSpeed * fDeltaTime;
            }

            // handBrake

            if (IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT))
            {
                m_v2Velocity.y = -10 * fDeltaTime;
            }

            //Position

            Matrix3 translation = new Matrix3();
            translation.Identity();
            translation.m7 = m_v2Velocity.x * fDeltaTime;
            translation.m8 = m_v2Velocity.y * fDeltaTime;
            m_LocalTransForm = m_LocalTransForm * translation;

            ////Rotation

            Matrix3 rotation = new Matrix3();
            rotation.Identity();
            rotation.SetRotateZ(angle);
            m_LocalTransForm = m_LocalTransForm * rotation;

            base.Update(fDeltaTime);
            
        }

    }
}