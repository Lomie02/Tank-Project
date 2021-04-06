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
    class Cube2 : GameObject
    {
        public Cube2(string FileName) : base (FileName)
        {
            m_LocalTransForm.m7 = 300;
            m_LocalTransForm.m8 = 300;
        }
    }
}
