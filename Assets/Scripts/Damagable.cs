using UnityEngine;

namespace Damagable
{
	public class TDamagable
	{
	  /* Name of this object */
	  public string name;
	  /* Durability of this object in its perfect state */
	  public float maxMaxDurability = 100f; //100 damage points
	  /* Current "maximum durability" of this object
		 it diminishes by repairing, and the object can never be 
		 repaired over this value.
		 some objects (such as peculari and biological tissues)
		 can regenerate this value up to maxMaxDurability with time */
	  public float maxDurability = 100f;
	  /* Current durability of this item */
	  public float durability;
	  //how much damage is completely absorbed
	  public float absorbDamage = 10f; //10 damage points
	  //what portion of unabsorbed damage is received by this object
	  public float receiveDamageRate = 0.5f; //50%
	  //is this object broken?
	  public bool isBroken()
	  {
		return durability <= 0;
	  }
	  //break this object
	  public void Break()
	  {
		//not sure what to do here, maybe send callback to the body?
		Debug.Log("Item " + name + " broken");
	  }
	  //deals damage to this object and returns damage that is passed to the "lower level"
	  public float Damage(float dam)
	  {
		if (!isBroken())
		{
		  //absorbDamage is completely gone from the incoming damage
		  float remainingDamage = dam - absorbDamage;
		  if (remainingDamage > 0)
		  {
			float blockedDamage = remainingDamage * receiveDamageRate;
			durability -= blockedDamage;
			if (isBroken())
			{
			  Break();
			}
			remainingDamage -= blockedDamage;
			if (remainingDamage > 0)
			{
			  return remainingDamage;
			}
			else
			{
			  return -1;
			}
		  }
		  else
		  {
			return -1;
		  }
		}
		else
		{
			return dam;
		}
	  }
	}
}