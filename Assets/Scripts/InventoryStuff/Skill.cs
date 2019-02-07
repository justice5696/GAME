using UnityEngine;

public class Skill : Item
{
  public float specialBoost {get; set;}
  public string specialPair {get; set;}

  public Skill()
  {
    name = "null";
    specialPair = "None";
    specialBoost = 1.0f;
    damageBoost = 1.0f; speedBoost = 1.0f; healthBoost = 1.0f;
  }

  public Skill(string name)
  {
    this.name = name;
    specialPair = "None";
    specialBoost = 1.0f;
    damageBoost = 1.0f;
    speedBoost = 1.0f;
    healthBoost = 1.0f;
  }

  public Skill(string name, string specialPair, float specialBoost, float damageBoost, float speedBoost, float healthBoost)
  {
    this.name = name;
    this.specialPair = specialPair;
    this.specialBoost = specialBoost;
    this.damageBoost = damageBoost;
    this.speedBoost = speedBoost;
    this.healthBoost = healthBoost;
  }


}
