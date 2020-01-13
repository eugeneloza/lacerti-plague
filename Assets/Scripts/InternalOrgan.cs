using UnityEngine;
using Damagable;
using DamageType;

namespace InternalOrgan
{
  /* Internal organs */
  public class TInternalOrgan: TInfectable
  {
	/* CONSTRUCTOR */
	public TInternalOrgan()
	{
	  MaxMaxDurability = 500f;
	  absorbDamage[(int)TDamageType.Blunt] = 0f;
	  absorbDamage[(int)TDamageType.Scratch] = 0f;
	  absorbDamage[(int)TDamageType.Cut] = 0f;
	  absorbDamage[(int)TDamageType.Piercing] = 0f;
	  
	  damageResist[(int)TDamageType.Blunt] = 1.0f;
	  damageResist[(int)TDamageType.Scratch] = 1.0f;
	  damageResist[(int)TDamageType.Cut] = 1.0f;
	  damageResist[(int)TDamageType.Piercing] = 1.0f;
    }    
  }
}