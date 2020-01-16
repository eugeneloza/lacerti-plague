using UnityEngine;

namespace InfectionType
{
  public enum TInfectionType
  {
    Disease, //generic non-Lacerti infections
    Carbonis, Ferrumis,    //primary Lacerti infection
    Argentumis,            //unique infection stamms
    Natriumis, Magnesiumis //amphibia Lacerti infection (will immediately inflame in oxygen environment)
  }
}