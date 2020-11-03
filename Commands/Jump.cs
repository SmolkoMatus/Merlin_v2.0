using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Merlin_v2._0.Commands
{

    public class Jump : Command
    {
        private bool colision;
        private IActor actor;
        private int dx, locationNumber, step;
        private int safePositionX, safePositionY;
        private int jumpHigh = 40;

        public Jump(IActor movable, int step, int dx, int locationNumber)
        {
            if (movable is IActor)
            {
                actor = (IActor)movable;
            }
            this.dx = dx;
            this.step = step;
            this.locationNumber = locationNumber;
        }
        public void Execute()
        {
            safePositionX = actor.GetX();
            safePositionY = actor.GetY();

            JumpOnly(safePositionX, safePositionY, dx, step, locationNumber);
            JumpLeft(safePositionX, safePositionY, dx, step, locationNumber);
            JumpRight(safePositionX, safePositionY, dx, step, locationNumber);
        }

        private bool Collision()
        {
            colision = actor.GetWorld().IntersectWithWall(actor);
            return colision;
        }

        private void JumpOnly(int safePositionX, int safePositionY, int dx, int step, int locationNumber)
        {
            if (locationNumber == 0)
            {
                actor.SetPosition(safePositionX, safePositionY - jumpHigh);
                if (Collision())
                {
                    actor.SetPosition(safePositionX, safePositionY);
                }
            }
        }
        private void JumpRight(int safePositionX, int safePositionY, int dx, int step, int locationNumber)
        {

            if (locationNumber == 1)
            {
                actor.SetPosition(safePositionX + dx + step * step, safePositionY - jumpHigh);
                if (Collision())
                {
                    actor.SetPosition(safePositionX, safePositionY);
                }
            }
        }
        private void JumpLeft(int safePositionX, int safePositionY, int dx, int step, int locationNumber)
        {

            if (locationNumber == -1)
            {
                actor.SetPosition(safePositionX - (dx + step * step), safePositionY - jumpHigh);

                if (Collision())
                {
                    actor.SetPosition(safePositionX, safePositionY);
                }
            }
        }
    }
}
