using Merlin2d.Game.Actors;

namespace Merlin_v2._0.Commands
{
    public class Fall<T> : IAction<T> where T : IActor
    {
        public void Execute(T t)
        {

            if (t.IsAffectedByPhysics())
            {
                Move move = new Move(t, 1, 0, 1);
                move.Execute();
            }

        }
    }
}
