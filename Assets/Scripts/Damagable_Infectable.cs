using UnityEngine;
using DamageType;

namespace Damagable
{
  namespace Infectable
  {
    /* Object that can get infected, such as muscles or internal organs */
    public abstract class TInfectable : TDamagable
    {
      //todo
      public override void Update(float deltaTime)
      {
        base.Update(deltaTime);
        //todo
      }
      /* CONSTRUCTOR */
      public TInfectable() : base() {}
    }
  }
}