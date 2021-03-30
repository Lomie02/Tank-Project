using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;

namespace Project2D
{
    class GameObject
    {
        //-----------------------------------

        protected GameObject m_parent;                                                //Parent Object variable
        protected List<GameObject> m_children = new List<GameObject>();              //List of children for parent 
        protected Matrix3 m_LocalTransForm;                                         //Local transform of an object 
        protected Matrix3 m_GlobalTransForm;                                       //Global transform of the level
        protected Image m_sprite;                                                 //Image variable for GameObjects
        protected Texture2D m_texture;                                           //texture varible for GameObjects
        protected float m_fRadious = 0;                                         //Radious for GameObject rotations
        protected Vector2 m_min;               
        protected Vector2 m_max;

        //-----------------------------------
        public GameObject(string filename)
        {
            m_LocalTransForm.Identity();
            m_GlobalTransForm.Identity();

            m_sprite = LoadImage(filename);
            m_texture = LoadTextureFromImage(m_sprite);

            m_min.x = -(m_texture.width * 0.5f);
            m_min.y = -(m_texture.height * 0.5f);

            m_min.x = (m_texture.width * 0.5f);
            m_min.y = (m_texture.height * 0.5f);
        }

        //-----------------------------------

        public void SetParent(GameObject parent)
        {
            //Remove from old parent
            if (m_parent != null)
            {
                m_parent.m_children.Remove(this);
            }

            //Set new parent
            m_parent = parent;

            //Add to new parent
            if (m_parent != null)
            {
                m_parent.m_children.Add(this);
            }
        }

        //-----------------------------------

        public GameObject GetParent()
        {
            return m_parent;
        }




        //-----------------------------------

        public virtual void Update(float fDeltaTime)
        {
            foreach (GameObject child in m_children)
            {
                child.Update(fDeltaTime);
            }
        }

        //-----------------------------------

        public void UpdateTransForms()
        {

            if (m_parent != null)
                m_GlobalTransForm = m_parent.m_GlobalTransForm * m_LocalTransForm;
            else
                m_GlobalTransForm = m_LocalTransForm;

            foreach (GameObject child in m_children)
            {
                child.UpdateTransForms();
            }

        }

        //-----------------------------------

        public void Draw()
        {
            Renderer.DrawTexture(m_texture, m_GlobalTransForm, RLColor.WHITE.ToColor());
            foreach (GameObject child in m_children)
            {
                child.Draw();
            }
        }

        //-----------------------------------

        public void OnCollision(GameObject other)
        {

        }

        //-----------------------------------

        public Vector2 GetPosition()
        {
            Vector2 position;

            position.x = m_GlobalTransForm.m7;
            position.y = m_GlobalTransForm.m8;

            return position;
        }

        public void SetRadius(float radius)
        {
            m_fRadious = radius;
        }

        //-----------------------------------

        public float GetRadius()
        {
            return m_fRadious;
        }

        //-----------------------------------

        public Vector2 GetMin()
        {
            return m_min;
        }

        //-----------------------------------

        public Vector2 GetMax()
        {
            return m_max;
        }
        //-----------------------------------
    }
}
