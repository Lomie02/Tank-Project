using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;

namespace Project2D
{
    class Game 
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

        //----------------------------
        //BackDrop Textures

        Image backDrop;
        Texture2D BackDroptexture;

        private string Cons = "Left Shift:  hand Brake | Movement: WASD| Turret: Q, E";
        //----------------------------
        //Tank Images

        
       
        level level1 = null;
        
        //----------------------------

        //----------------------------

        public Game()
        {

        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            //Initialize objects here
            backDrop = LoadImage("../Images/Mud1.png");
            BackDroptexture = LoadTextureFromImage(backDrop);

            //-------------------------------------------

            level1 = new level("");
            
            
        }
            

        public void Shutdown()
        {

        }

        public void Update()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            //Update game objects here      

            level1.Update(deltaTime);
            level1.UpdateTransForms();

           

            CollisionManager.CheckCollision();
		}

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(RLColor.BLACK);

            // Draw the BackGroundb
            DrawTexture( BackDroptexture, GetScreenWidth() / 2 - BackDroptexture.width / 2, GetScreenHeight() / 2 - BackDroptexture.height / 2, RLColor.WHITE);
            
			//Draw game objects here
            DrawText(fps.ToString(), 10, 10, 25, RLColor.WHITE);

            DrawText(Cons, 10, 700, 10, RLColor.WHITE);

            level1.Draw();

			EndDrawing();
        }

    }
}
