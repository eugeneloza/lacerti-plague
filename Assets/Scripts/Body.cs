using UnityEngine;
using Bodypart;

namespace Body
{
  /* Abstract body shared by all possible creatures */
  public abstract class TAbstractBody
  {
    public TBodypart[] bodyparts;
	
  }
  
  /* Humanoid body, also note that only humanoids can wear clothes */
  public class THumanoidBody: TAbstractBody
  {
	/* Humanoid bodyparts, total 8 pieces */
    public enum TBodyparts
	{
	  Head,
	  LArm, RArm,
	  //LHand, RHand, //maybe leave only arms
	  Chest, //LChest, RChest, //maybe leave only chest
	  Belly,
	  Bottom,
	  LLeg, RLeg,
	  //LFoot, RFoot //maybe leave only legs
	};	  
	 /* CONSTRUCTOR */
	 public THumanoidBody()
	 {
	    bodyparts[(int)TBodyparts.Head] = new TBodypart();
	    bodyparts[(int)TBodyparts.LArm] = new TBodypart();
	    bodyparts[(int)TBodyparts.RArm] = new TBodypart();
	    bodyparts[(int)TBodyparts.Chest] = new TBodypart();
	    bodyparts[(int)TBodyparts.Belly] = new TBodypart();
	    bodyparts[(int)TBodyparts.Bottom] = new TBodypart();
	    bodyparts[(int)TBodyparts.LLeg] = new TBodypart();
	    bodyparts[(int)TBodyparts.RLeg] = new TBodypart();
     }
  }
  
}