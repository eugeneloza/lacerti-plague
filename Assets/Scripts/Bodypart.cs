using UnityEngine;
using DamageType;
using Skin;
using Muscle;

namespace Bodypart
{
	public class TBodypart
	{
	  /* Clothes and biological layers in/over this bodypart */
	  //TClothesLayers clothesLayers; //let Body handle clothes!
	  TSkin skin;
	  TMuscle muscle;
	  //TBone bone;
	  //TInternal internal;
	  public void Damage(float dam, TDamageType damType)
	  {
		float remainingDamage = dam;
		//remainingDamage = clothesLayers.Damage(remainingDamage, damType);
		remainingDamage = skin.Damage(remainingDamage, damType);
		remainingDamage = muscle.Damage(remainingDamage, damType);
		//remainingDamage = bone.Damage(remainingDamage, damType);
		//remainingDamage = internal.Damage(remainingDamage, damType);
		Debug.Assert(remainingDamage <= 0, "ERROR: Bodypart must completely absorb all incoming damage!"); //this can normally happen if internal organ or bone is destroyed
	  }
	  /* CONSTRUCTOR */
	  public TBodypart()
	  {
	    skin = new TSkin();  
	  }
	}
}