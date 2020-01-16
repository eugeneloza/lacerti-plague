using UnityEngine;
using System;
using InfectionType;

namespace Damagable
{
  namespace Infectable
  {
    /* Object that can get infected, such as muscles or internal organs */
    public abstract class TInfectable : TDamagable
    {
      //public float disease;
      /* Current values of the infection in this infectable object */
      public float[] infection;
      //make GetInfection;SetInfection and cache
      public float[] infectionGrowthRate;
      /* Each Lacerti infection requires a "construction material" to be built from
         most common is free carbon, which is obtained with every food type
         more hard-to-get is free ferrum, which is (for now) obtained only by drinking blood */
      public float[] availableConstructionMaterial;
      /* Available suppressant within the object */
      public float suppressant;
      public const float suppressantHalfLife = 84000f / 5f;
      public float TotalInfection()
      {
        float ti = 0;
        foreach (TInfectionType i in (TInfectionType[]) Enum.GetValues(typeof(TInfectionType)))
        {
          ti += infection[(int)i];
        }
        return ti;
      }
      public float ActiveMyocarfis(TInfectionType i)
      {
        float suppressedMyocarfis = infection[(int)i] * suppressant / TotalInfection();
        if (infection[(int)i] > suppressedMyocarfis)
        {
          return infection[(int)i] - suppressedMyocarfis;
        }
        else
        {
          return 0;
        }
      }
      public override void Update(float deltaTime)
      {
        base.Update(deltaTime);
        foreach (TInfectionType i in (TInfectionType[]) Enum.GetValues(typeof(TInfectionType)))
        {
          //infection growth is calculated based on free metals in the body
          float infectionGrowth = ActiveMyocarfis(i) * infectionGrowthRate[(int)i] * deltaTime;
          infection[(int)i] += infectionGrowth;
        }
        //suppressant leaves the object
        suppressant -= suppressant * (float)Math.Pow(2, -deltaTime / suppressantHalfLife);
      }
      /* CONSTRUCTOR */
      public TInfectable() : base()
      {
        //others are zero-initialized, which is fine for e.g. Argentumis, which are never supposed to be "owned" by player (?)
        infectionGrowthRate[(int)TInfectionType.Carbonis] = 0.01f;
        infectionGrowthRate[(int)TInfectionType.Ferrumis] = 0.01f;
      }
    }
  }
}