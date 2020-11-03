using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Merlin_v2._0.Commands
{

    public class Move : Command
    {
        private IActor actor;
        int dx;
        int dy;
        private bool colision = false;
        private int step;
        private int safePositionX, safePositionY;

        public Move(IActor movable, int step, int dx, int dy)
        {
            if (movable is IActor)
            {
                actor = (IActor)movable;
            }
            this.dx = dx;
            this.step = step;
            this.dy = dy;
        }

        public void Execute()
        {
            safePositionX = actor.GetX();
            safePositionY = actor.GetY();
            actor.SetPosition(safePositionX + dx * step, safePositionY + dy);
            if (Colision())
            {
                actor.SetPosition(safePositionX, safePositionY);
            }
        }

        private bool Colision()
        {
            colision = actor.GetWorld().IntersectWithWall(actor);
            return colision;
        }
    }
}
