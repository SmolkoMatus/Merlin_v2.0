using Merlin.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Merlin.Actors
{
    public class Enemy : AbstractActor
    {
        //Command walking;
        //Command followPlayer;

        private Animation animationEnemy;
        private int followNumber = 70;
        private int positionPlayerX;
        private int positionPlayerY;
        private IActor player;
        private int counter = 0;
        private int rnd, xEnemy, yEnemy;
        Random random = new Random();

        public Enemy(IActor player)
        {
            animationEnemy = new Animation("resources/enemy.png", 64, 58);
            SetAnimation(animationEnemy);
            animationEnemy.Start();
            SetPosition(250, 120);           
            //followPlayer = new Move(this, 1, , 0);
            this.player = player;
            //move = new Move(this,1,xEnemy,0);
        }

        public override void Update()
        {
            positionPlayerX = player.GetX();
            positionPlayerY = player.GetY();
            xEnemy = GetX();
            yEnemy = GetY();

            if ((SeeNumber(positionPlayerX, xEnemy, positionPlayerY, yEnemy) <= followNumber) && (counter % 30 == 0))
            {
                new Move(this, 1, Follow(positionPlayerX, xEnemy, positionPlayerY, yEnemy), 0).Execute();
                Console.WriteLine("Enemy see player!");
            }
            else
            {
                if (counter % 60 == 0)
                {
                    rnd = random.Next(-10, 10);
                    new Move(this, 1, rnd, 0).Execute();
                }
            }
            if(positionPlayerX == this.GetX())
            {
                Console.WriteLine("Merlin is caught!");
            }
            counter++;
        }

        private int SeeNumber(int xP, int xE, int yP, int yE)
        {
            int finalNumber,dimenseFirst,dimenseSecond;

            dimenseFirst = xP - xE;
            dimenseSecond = yP - yE;

            if(dimenseFirst <= 0)
            {
                finalNumber = dimenseFirst * (-1);
            }
            else
            {
                finalNumber = dimenseFirst;
            }
            return finalNumber;
        }
                  
        private int Follow(int xP, int xE, int yP, int yE)
        {
            int finalNumber, left, right , up, down;

           if(xP - xE >= 0)
            {
                finalNumber = 3;
            }
            else
            {
                finalNumber = -3;
            }
            return finalNumber;
        }
    }
}



