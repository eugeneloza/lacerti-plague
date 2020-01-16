using UnityEngine;
using DamageType;
using DirtVolume;

namespace Damagable
{
  namespace Dirty
  {
    /* Object that can get dirty, such as skin or clothes */
    public abstract class TDirty : TDamagable
    {
      /* Dirt stuck to the surface of this object */
      public TDirtVolume Dirt;
      public override void Update(float deltaTime)
      {
        base.Update(deltaTime);
        Damage(Dirt.GetAcidDamage(deltaTime), TDamageType.Acid);
        Dirt.Update(deltaTime);
      }
      /* CONSTRUCTOR */
      public TDirty() : base()
      {
        Dirt = new TDirtVolume();      
      }
    }
  }
}