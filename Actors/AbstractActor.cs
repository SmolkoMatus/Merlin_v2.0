using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merlin_v2._0.Actors
{
    public abstract class AbstractActor
    {
        public AbstractActor();
        public AbstractActor(string name);
        public virtual void GetName();
        public int GetX();
        public int GetY();
        public virtual int GetWidth();
        public virtual int GetHeight();
        public void SetPosition(int x, int y);
        public void AddedToWorld(IWorld world);
        public virtual IAnimation GetAnimation();
        public virtual void SetAnimation(IAnimation animation);
        public virtual bool IntersectsWithActor(IActor other);
        public virtual void SetPhysics(bool isPhysicsEnabled);
        public virtual bool IsAffectedByPhysics(void);
        public virtual void RemoveFromWorld();
        public virtual bool RemovedFromWorld();
    }
}
