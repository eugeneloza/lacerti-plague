using UnityEngine;

namespace DirtType
{
  /* Different dirt types that can be found at the surface */
  public enum TDirtType
  {
    Water,        //Quickly dries up, but large volumes of water can be used to remove other types of dirt; but maybe we'd want a different rinse mechanics
    Harmless,     //just a waste-volume of dirt on the surface. Doesn't do anything.
    //Smelly,       //Smells bad, nothing else
    Carbonis, Ferrumis,     //concentration of Lacerti Plague agents; slowly absorbed through the skin
    Argentumis,             //unique infection stamms
    Natriumis, Magnesiumis, //fish-only infection, will immediately catch fire in contact with oxygen
    Disease,      //any non-lacerti disease; slowly absorbed through the skin
    Sticky,       //keeps all other dirt types on the surface
    Suppressant,  //suppresses Lacerti Plague agents; slowly absorbed through the skin
    Antiseptic,   //destroys Disease on the skin
    Acid,         //harms the object
    Soap          //destroys Sticky and harms object; but as long as it isn't sticky itself it will "fall off" as soon as sticky is destroyed
  }
}