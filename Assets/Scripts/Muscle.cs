using UnityEngine;
using Damagable.Infectable;
using DamageType;

namespace Muscle
{
  /* Muscular tissues */
  public class TMuscle: TInfectable
  {
    /* CONSTRUCTOR */
    public TMuscle() : base()
    {
      name = "muscles";
      MaxMaxDurability = 100f;
      absorbDamage[(int)TDamageType.Blunt] = 3f;
      absorbDamage[(int)TDamageType.Scratch] = 1f;
      absorbDamage[(int)TDamageType.Cut] = 0f;
      absorbDamage[(int)TDamageType.Piercing] = 5f;

      damageResist[(int)TDamageType.Blunt] = 0.5f;
      damageResist[(int)TDamageType.Scratch] = 1.0f;
      damageResist[(int)TDamageType.Cut] = 0.7f;
      damageResist[(int)TDamageType.Piercing] = 0.5f;
    }
  }
}