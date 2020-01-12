using UnityEngine;
using Damagable;

namespace Bodypart
{
	public class TBodypart
	{
	  /* Clothes and biological layers in/over this bodypart */
	  //TClothesLayers clothesLayers;
	  TDamagable skin;
	  //TMuscle muscle;
	  //TBone bone;
	  //TInternal internal;
	  public void TakeDamage(float dam)
	  {
		float remainingDamage = dam;
		//remainingDamage = clothesLayers.Damage(remainingDamage);
		remainingDamage = skin.Damage(remainingDamage);
		//remainingDamage = muscle.Damage(remainingDamage);
		//remainingDamage = bone.Damage(remainingDamage);
		//remainingDamage = internal.Damage(remainingDamage);
		Debug.Assert(remainingDamage <= 0, "ERROR: Bodypart must completely absorb all incoming damage!");
	  }
	}
}