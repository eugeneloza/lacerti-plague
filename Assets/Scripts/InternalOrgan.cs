using UnityEngine;
using Damagable;
using DamageType;

namespace InternalOrgan
{
  /* Internal organs */
  public abstract class TInternalOrgan: TInfectable
  {
    /* CONSTRUCTOR */
    public TInternalOrgan() : base()
    {
      MaxMaxDurability = 500f;
      absorbDamage[(int)TDamageType.Blunt] = 0f;
      absorbDamage[(int)TDamageType.Scratch] = 0f;
      absorbDamage[(int)TDamageType.Cut] = 0f;
      absorbDamage[(int)TDamageType.Piercing] = 0f;

      damageResist[(int)TDamageType.Blunt] = 1.0f;
      damageResist[(int)TDamageType.Scratch] = 1.0f;
      damageResist[(int)TDamageType.Cut] = 1.0f;
      damageResist[(int)TDamageType.Piercing] = 1.0f;
    }    
  }
  
  public class TBrain: TInternalOrgan
  {
    public TBrain() : base()
    {
      name = "brain";
    }
  }
  
  public class TLungs: TInternalOrgan
  {
    public TLungs() : base()
    {
      name = "lungs and heart";
    }
  }
  
  public class TStomach: TInternalOrgan
  {
    public TStomach() : base()
    {
      name = "stomach and guts";
    }
  }
}