using UnityEngine;
using Bodypart;

namespace Body
{
  public abstract class TAbstractBody
  {
    /* public enum TBodyparts = {
		Head,
		LArm, RArm,
		LHand, RHand,
		LChest, RChest,
		Belly,
		Bottom,
		LLeg, RLeg,
		LFoot, RFoot}; */ //different creatures may have a different set of bodyparts?
    public TBodypart[] bodyparts;
	
  }
  
  public class THumanoidBody: TAbstractBody
  {
	
  }
  
}