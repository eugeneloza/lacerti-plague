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
      //Natriumis, Magnesiumis, //fish-only infection, will immediately catch fire in contact with oxygen
      Disease,      //any non-lacerti disease; slowly absorbed through the skin
      Sticky,       //keeps all other dirt types on the surface
      Suppressant,  //suppresses Lacerti Plague agents; slowly absorbed through the skin
      Antiseptic,   //destroys Disease on the skin
      Acid,         //harms the object
      Soap          //destroys Sticky and harms object; but as long as it isn't sticky itself it will "fall off" as soon as sticky is destroyed
    }
    /* Sticky dirt type can hold 10x its volume of other reagents */
    public const float stickyRatio = 10f;
    /* Half-lives of dirt types; might want to make them more global */
    public const float dirtHalfLife = 10f;
    public const float stickyHalfLife = 100f;
    /* Volumes of every type of dirt in this volume */
    public float[] dirt;
    /* Constant damage rates of different dirt types
       todo: remake them into constants, saves RAM but not as convenient to handle */
    private float[] damageRate = new float[Enum.GetNames(typeof(TDirtType)).Length];
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
    private float VolumeWithoutSticky()
    {
      float v = 0;
      foreach (TDirtType d in (TDirtType[]) Enum.GetValues(typeof(TDirtType))) //The typecast is not strictly necessary, but it does make the code 0.5 ns faster. @Peter Mortensen
      {
        if (d != TDirtType.Sticky)
        {
          v += dirt[(int)d];
        }
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
      
      /* dirt fall-off */
      //float v0 = Volume(); //I'm not sure if we want "sticky" dirt to "fall off" in a normal way - maybe, better only if neutralized
      float v0 = VolumeWithoutSticky();
      float v1 = dirt[(int)TDirtType.Sticky] * stickyRatio;
      if (v0 > v1)
      {
        float volumeRatio = (v0 - v1) / v1; //always > 0.0f
        float decayRate = volumeRatio * (float)Math.Pow(2, -deltaTime / dirtHalfLife);
        foreach (TDirtType d in (TDirtType[]) Enum.GetValues(typeof(TDirtType))) //The typecast is not strictly necessary, but it does make the code 0.5 ns faster. @Peter Mortensen
        {
          if (d != TDirtType.Sticky)
          {
            dirt[(int)d] -= dirt[(int)d] * decayRate;
          }
        }
      }
    }
    /* CONSTRUCTOR */
    public TDirtVolume()
    {
      /*foreach (TDirtType d in (TDirtType[]) Enum.GetValues(typeof(TDirtType)))
      {
        damageRate[(int)d] = 0f;
      }*/
      //all other types are already zero-initialized
      damageRate[(int)TDirtType.Antiseptic] = 0.001f;
      damageRate[(int)TDirtType.Acid] = 1f;
      damageRate[(int)TDirtType.Soap] = 0.001f;
    }
  }
}