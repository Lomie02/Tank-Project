using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{ 
    class level : GameObject
    {
        Tank Tank1 = null;
        Cube Cube1 = null;
        
        public level(string Filename) : base(Filename)
        {
            // layer 1
            collisionEnabled = false;

            Cube1 = new Cube("../Images/CubeBox.png");
            Cube1.SetParent(this);

            // Layer 2

            Tank1 = new Tank("../Images/Tank1.png");
            Tank1.SetParent(this);

        }
    }
}
