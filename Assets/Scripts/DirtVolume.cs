using UnityEngine;
using System;
using DirtType;

namespace DirtVolume
{
  public class TDirtVolume
  {
    /* Sticky dirt type can hold 10x its volume of other reagents */
    public const float stickyRatio = 10f;
    /* Half-lives of dirt types; might want to make them more global */
    public const float dirtHalfLife = 100f; //in-game seconds/turns
    //public const float stickyHalfLife = 84000f; //in-game seconds/turns (=a day)
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
    private bool NotSticky(TDirtType d)
    {
      if ((d == TDirtType.Soap) || (d == TDirtType.Sticky))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private float VolumeWithoutSticky()
    {
      float v = 0;
      foreach (TDirtType d in (TDirtType[]) Enum.GetValues(typeof(TDirtType))) //The typecast is not strictly necessary, but it does make the code 0.5 ns faster. @Peter Mortensen
      {
        if (NotSticky(d))
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
        //todo: dirt decays when "used"
      }
      return dam * deltaTime;
    }
    /* Update state of this dirt volume */
    public void Update(float deltaTime)
    {

      /* ---- "soap" neutralizes "sticky" immediately ---- */
      if (dirt[(int)TDirtType.Sticky] > dirt[(int)TDirtType.Soap])
      {
        float neutralized = dirt[(int)TDirtType.Sticky];
        dirt[(int)TDirtType.Sticky] =- dirt[(int)TDirtType.Soap];
        dirt[(int)TDirtType.Soap] -= neutralized;
        dirt[(int)TDirtType.Harmless] += neutralized * 2;
      }
      else
      {
        dirt[(int)TDirtType.Soap] -= dirt[(int)TDirtType.Sticky];
        dirt[(int)TDirtType.Harmless] += dirt[(int)TDirtType.Sticky] * 2;
        dirt[(int)TDirtType.Sticky] = 0;
      }

      /* ---- dirt fall-off ---- */
      //float v0 = Volume(); //I'm not sure if we want "sticky" dirt to "fall off" in a normal way - maybe, better only if neutralized
      float v0 = VolumeWithoutSticky();
      float v1 = dirt[(int)TDirtType.Sticky] * stickyRatio;
      if (v0 > v1)
      {
        float volumeRatio = (v0 - v1) / v1; //always > 0.0f
        float decayRate = volumeRatio * (float)Math.Pow(2, -deltaTime / dirtHalfLife);
        foreach (TDirtType d in (TDirtType[]) Enum.GetValues(typeof(TDirtType))) //The typecast is not strictly necessary, but it does make the code 0.5 ns faster. @Peter Mortensen
        {
          //if (NotSticky(d)) //we want sticky dirt types to go off with water too!
          {
            dirt[(int)d] -= dirt[(int)d] * decayRate;
          }
        }
      }

      //todo: make the object wet
      dirt[(int)TDirtType.Water] = 0;
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