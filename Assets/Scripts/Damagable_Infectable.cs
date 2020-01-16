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
      /* Current values of the infection in this infectable object */
      public float[] infection;
      public float[] infectionGrowthRate;
      /* Each Lacerti infection requires a "construction material" to be built from
         most common is free carbon, which is obtained with every food type
         more hard-to-get is free ferrum, which is (for now) obtained only by drinking blood */
      public float[] freeConstructionMaterial;
      public override void Update(float deltaTime)
      {
        base.Update(deltaTime);
        foreach (TInfectionType i in (TInfectionType[]) Enum.GetValues(typeof(TInfectionType)))
        {
          if (i != TInfectionType.Disease)
          {
            //infection growth is calculated based on free metals in the body
            float infectionGrowth = infection[(int)i] * infectionGrowthRate[(int)i] * deltaTime;
            infection[(int)i] += infectionGrowth;
          }
          else
          {
            //normal disease just grows (we need some immunity to counter?
            infection[(int)i] += infection[(int)i] * infectionGrowthRate[(int)i] * deltaTime;
          }
        }
      }
      /* CONSTRUCTOR */
      public TInfectable() : base()
      {
        //others are zero-initialized, which is fine for e.g. Argentumis, which are never supposed to be "owned" by player
        infectionGrowthRate[(int)TInfectionType.Disease] = 0.01f;
        infectionGrowthRate[(int)TInfectionType.Carbonis] = 0.01f;
        infectionGrowthRate[(int)TInfectionType.Ferrumis] = 0.01f;
      }
    }
  }
}