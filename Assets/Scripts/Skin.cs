using UnityEngine;
using Damagable;
using DamageType;

namespace Skin
{
  /* Skin is the topmost layer of the body, located right under clothes
     just like clothes it can get dirty or be damaged, however like every other
     biological tissue it regenerates over time */
  public class TSkin: TDirty
  {
	/* CONSTRUCTOR */
	public TSkin() : base()
	{
	  name = "skin";
	  MaxMaxDurability = 100f;
	  absorbDamage[(int)TDamageType.Blunt] = 1f;
	  absorbDamage[(int)TDamageType.Scratch] = 0f;
	  absorbDamage[(int)TDamageType.Cut] = 0f;
	  absorbDamage[(int)TDamageType.Piercing] = 0f;
	  
	  damageResist[(int)TDamageType.Blunt] = 0.1f;
	  damageResist[(int)TDamageType.Scratch] = 0.8f;
	  damageResist[(int)TDamageType.Cut] = 0.5f;
	  damageResist[(int)TDamageType.Piercing] = 0.2f;
    }    
  }
}