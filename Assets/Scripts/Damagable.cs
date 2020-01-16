using UnityEngine;
using DamageType;

namespace Damagable
{
  public abstract class TDamagable
  {
    /* Name of this object */
    public string name;
    /* Regeneration rate of this organ in units per second */
    public float regenRate;
    public float regenMaxRate;
    /* Durability of this object in its perfect state
       it is never intended to be changed after created */
    private float maxMaxDurability;
    public float MaxMaxDurability
    { 
      get { return maxMaxDurability ;}
      set { maxMaxDurability = value; MaxDurability = maxMaxDurability; }
    }
    /* Current "maximum durability" of this object
       it diminishes by repairing, and the object can never be 
       repaired over this value.
       some objects (such as peculari and biological tissues)
       can regenerate this value up to maxMaxDurability with time */
    private float maxDurability;
    public float MaxDurability
    {
      get { return maxDurability; }
      set { maxDurability = value; Durability = maxDurability; }
    }
    /* Current durability of this item */
    //private float durability;
    public float Durability
      { get; set; }
    /* how much damage is completely absorbed */
    public float[] absorbDamage; 
    /* what portion of unabsorbed damage is received by this object */
    public float[] damageResist;
    /* is this object broken? */
    public bool isBroken()
    {
      return Durability <= 0;
    }
    /* break this object */
    public void Break()
    {
      //not sure what to do here, maybe send callback to the body?
      Debug.Log("Object " + name + " broken");
    }
    /* deals damage to this object and returns damage that is passed to the "lower level" */
    public float Damage(float dam, TDamageType damType)
    {
      if (!isBroken())
      {
        //absorbDamage is completely gone from the incoming damage
        float remainingDamage = dam - absorbDamage[(int)damType];
        if (remainingDamage > 0)
        {
          float blockedDamage = remainingDamage * damageResist[(int)damType];
          Durability -= blockedDamage;
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
    /* Update this object state */
    public virtual void Update(float deltaTime)
    {
      //todo: wrong setters! Max > MaxMax
      Durability += regenRate * deltaTime;
      MaxDurability += regenMaxRate * deltaTime;
    }
    /* CONSTRUCTOR */
    public TDamagable() {}
  }
}