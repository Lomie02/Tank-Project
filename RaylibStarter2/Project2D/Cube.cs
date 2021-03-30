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
    class Cube : GameObject
    {
        private float m_fRotationSpeed = 1.0f;

        public Cube(string Filename) : base(Filename)
        { 
            m_LocalTransForm.m7 = 200;        
            m_LocalTransForm.m8 = 400;
        }

        

        

    }
}
