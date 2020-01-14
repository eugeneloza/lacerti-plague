using UnityEngine;
using Damagable;
using DamageType;

namespace Bone
{
  /* Bone structure of the bodypart
     Bones do not get infected, nor do they get dirty */
  public class TBone: TDamagable
  {
	/* CONSTRUCTOR */
	public TBone() : base()
	{
	  name = "bones";
	  MaxMaxDurability = 1000f;
	  absorbDamage[(int)TDamageType.Blunt] = 10f;
	  absorbDamage[(int)TDamageType.Scratch] = 10f;
	  absorbDamage[(int)TDamageType.Cut] = 10f;
	  absorbDamage[(int)TDamageType.Piercing] = 5f;
	  
	  damageResist[(int)TDamageType.Blunt] = 0.9f;
	  damageResist[(int)TDamageType.Scratch] = 1.0f;
	  damageResist[(int)TDamageType.Cut] = 0.9f;
	  damageResist[(int)TDamageType.Piercing] = 0.6f;
    }    
  }
}