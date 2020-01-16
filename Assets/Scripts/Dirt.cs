using UnityEngine;
using System;

namespace DirtVolume
{
  public class TDirtVolume
  {
    /* Different dirt types that can be found at the surface */
    public enum TDirtType
    {
      Harmless,     //just a waste-volume of dirt on the surface. Doesn't do anything.
      //Smelly,       //Smells bad, nothing else
      Carbonis, Ferrumis,   //concentration of Lacerti Plague agents; slowly absorbed through the skin
      Disease,      //any non-lacerti disease; slowly absorbed through the skin
      Sticky,       //keeps all other dirt types on the surface
      Suppressant,  //suppresses Lacerti Plague agents; slowly absorbed through the skin
      Antiseptic,   //destroys Disease on the skin
      Acid,         //harms the object
      Soap          //destroys Sticky and harms object; but as long as it isn't sticky itself it will "fall off" as soon as sticky is destroyed
    }
    /* Sticky dirt type can hold 10x its volume of other reagents */
    public const float StickyRatio = 10f; 
    /* Volumes of every type of dirt in this volume */
    public float[] dirt;
    private float[] damageRate;
    /* Total volume of the dirt */
    public float Volume()
    {
      float v = 0;
      foreach (TDirtType d in (TDirtType[]) Enum.GetValues(typeof(TDirtType))) //The typecast is not strictly necessary, but it does make the code 0.5 ns faster. @Peter Mortensen
      {
        v += dirt[(int)d];
      }
      return v;
    }
    /* Total acidic damage done by this dirt volume */
    public float GetAcidDamage(float deltaTime)
    {
      float dam = 0;
      foreach (TDirtType d in (TDirtType[]) Enum.GetValues(typeof(TDirtType)))
      {
        dam += dirt[(int)d] * damageRate[(int)d];
      }
      return dam * deltaTime;
    }
    /* Update state of this dirt volume */
    public void Update(float deltaTime)
    {
      //todo
    }
    /* CONSTRUCTOR */
    public TDirtVolume()
    {
      damageRate[(int)TDirtType.Harmless] = 0f;
      //damageRate[(int)TDirtType.Smelly] = 0f;
      damageRate[(int)TDirtType.Carbonis] = 0f;
      damageRate[(int)TDirtType.Disease] = 0f;
      damageRate[(int)TDirtType.Sticky] = 0f;
      damageRate[(int)TDirtType.Suppressant] = 0f;
      damageRate[(int)TDirtType.Antiseptic] = 0.001f;
      damageRate[(int)TDirtType.Acid] = 1f;
      damageRate[(int)TDirtType.Soap] = 0.001f;
    }
  }
}