using UnityEngine;
using Damagable;

namespace Skin
{
  public class TSkin: TDirty
  {
	/* CONSTRUCTOR */
	public TSkin()
	{
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