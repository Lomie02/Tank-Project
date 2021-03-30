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
    static class CollisionManager
    {
        private static List<GameObject> m_ObjectList = new List<GameObject>();

        public static void AddObject(GameObject obj)
        {
            m_ObjectList.Add(obj);
        }

        public static void CheckCollision()
        {
            foreach (GameObject obj1 in m_ObjectList)
            {
                foreach (GameObject obj2 in m_ObjectList)
                {
                    //Dont have objects collide with themselves
                    if (obj1 == obj2)
                        continue;

                    //Test collision

                    Vector2 obj1Min = obj1.GetMin() + obj1.GetPosition();
                    Vector2 obj1Max = obj1.GetMin() + obj1.GetPosition();

                    Vector2 obj2Min = obj2.GetMin() + obj1.GetPosition();
                    Vector2 obj2Max = obj2.GetMax() + obj1.GetPosition();

                    if (obj2Max.x > obj1Min.x && obj2Max.y > obj1Min.y && obj2Min.x < obj1Max.x && obj2Min.y < obj1Max.y)
                    {
                        //if colliding, resolve collision
                        obj1.OnCollision(obj2);
                    }
                }
            }
        }
    }
}

