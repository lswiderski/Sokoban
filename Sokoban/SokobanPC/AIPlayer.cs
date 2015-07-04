using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SokobanPC
{
    public class AIPlayer
    {
        private Player player;
        public string SolverPath
        {
            get { return solverPath; }
            set
            {
                solverPath = value.ToLower();
                currentPosition = 0;
            }
        }
        private string solverPath ="";
        private int currentPosition;
        private bool isRunning;
        private TimeSpan waitTime;
        private TimeSpan actualTimeSpan = TimeSpan.Zero;
        public AIPlayer(ref Player player)
        {
            this.player = player;
            currentPosition = 0;
            isRunning = false;

        }

        public void Update(GameTime gameTime)
        {
            actualTimeSpan += gameTime.ElapsedGameTime;
            if (isRunning)
            {
                if (actualTimeSpan > waitTime)
                {
                    actualTimeSpan = TimeSpan.Zero;
               
                switch (solverPath[currentPosition])
                {
                    case 'l': player.moveLeft();
                        break;
                    case 'u': player.moveUp();
                        break;
                    case 'r': player.moveRight();
                        break;
                    case 'd': player.moveDown();
                        break;
                }
                currentPosition++;
                if (currentPosition >= solverPath.Length)
                {
                    isRunning = false;
                    currentPosition = 0;
                }
                     }
            }
            

        }

        public void Run()
        {
            isRunning = true;
        }
        public void Run(string solverPath)
        {
            SolverPath = solverPath;
            isRunning = true;
            waitTime = TimeSpan.Zero;

        }
        public void Run(string solverPath, TimeSpan waitTime)
        {
            SolverPath = solverPath;
            isRunning = true;
            this.waitTime = waitTime;
        }
    }
}
