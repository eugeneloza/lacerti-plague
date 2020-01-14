using UnityEngine;
using Bodypart;
using InternalOrgan;

namespace Body
{
  /* Abstract body shared by all possible creatures */
  public abstract class TAbstractBody
  {
	/* An abstract array of bodyparts of this creature */
    public TBodypart[] bodyparts;
	public TAbstractBody() {}
  }
  
  /* While ironbloods are still biological creatures, they should be treated separately */
  
  /* Biological creatures, made of flesh and bone */
  public abstract class TBiologicalBody : TAbstractBody
  {
	/* Every biological creature has these three internal organs */
	public TBrain brain;
	public TLungs lungs;
	public TStomach stomach;
	/* CONSTRUCTOR */
	public TBiologicalBody() : base()
	{
	  brain = new TBrain();
	  lungs = new TLungs();
	  stomach = new TStomach();
	}
  }	  
  
  /* Humanoid body, also note that only humanoids can wear clothes */
  public class THumanoidBody: TBiologicalBody
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
	 public THumanoidBody() : base()
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