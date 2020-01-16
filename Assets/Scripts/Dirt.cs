using UnityEngine;

namespace DirtVolume
{
  public class TDirtVolume
  {
    /* Different dirt types that can be found at the surface */
    public enum TDirtType
    {
      Harmless,     //just a waste-volume of dirt on the surface. Doesn't do anything.
      //Smelly,       //Smells bad, nothing else
      Infection,    //concentration of Lacerti Plague agents; slowly absorbed through the skin
      Disease,      //any non-lacerti disease; slowly absorbed through the skin
      Sticky,       //keeps all other dirt types on the surface
      Suppressant,  //suppresses Lacerti Plague agents; slowly absorbed through the skin
      Antiseptic,   //destroys Disease on the skin
      //Acid,         //harms the object
      Soap          //destroys Sticky and harms object; but as long as it isn't sticky itself it will "fall off" as soon as sticky is destroyed
    }
    /* Sticky dirt type can hold 10x its volume of other reagents */
    public const float StickyRatio = 10f; 
    /* Volumes of every type of dirt in this volume */
    public TDirtType[] Value;
    /* Total volume of the dirt */
    public float Volume()
    {
      return 0;
    }  
    /* CONSTRUCTOR */
    public TDirtVolume() {}
  }
}