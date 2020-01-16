using UnityEngine;
using DamageType;
using Skin;
using Muscle;
using Bone;

namespace Bodypart
{
  public class TBodypart
  {
    /* Skin covering this bodypart */
    public TSkin skin;
    /* Muscular tissues of this bodypart */
    public TMuscle muscle;
    /* Bone structure of this bodypart */
    public TBone bone;
    /* Pass damage to this bodypart
       Returns amount of damage not absorbed by skin, muscles and bones
       Body should pass it down to internal organs if applicable */
    public float Damage(float dam, TDamageType damType)
    {
      float remainingDamage = dam;
      remainingDamage = skin.Damage(remainingDamage, damType);
      remainingDamage = muscle.Damage(remainingDamage, damType);
      remainingDamage = bone.Damage(remainingDamage, damType);
      return remainingDamage;
    }
    /* CONSTRUCTOR */
    public TBodypart()
    {
      skin = new TSkin();
      muscle = new TMuscle();
      bone = new TBone();
    }
  }
}