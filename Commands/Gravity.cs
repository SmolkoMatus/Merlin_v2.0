using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System.Collections.Generic;
using System.Linq;

namespace Merlin_v2._0.Commands
{
    public class Gravity : IPhysics
    {
        private IWorld world;
        List<IActor> actors;
        Fall<AbstractActor> fall = new Fall<AbstractActor>();

        public Gravity(IWorld world)
        {
            SetWorld(world);
        }
        public void Execute()
        {
            actors = world.GetActors().Where(x => x.IsAffectedByPhysics()).ToList();
            actors.ForEach(x => fall.Execute((AbstractActor)x));

        }
        public void SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}

