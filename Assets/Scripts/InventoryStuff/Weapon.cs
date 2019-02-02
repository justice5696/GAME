using UnityEngine;

public class Weapon : Item
{
    public int damage {get; set;}

    public Weapon()
    {
      name = "null";
      damage = 10;
      damageBoost = 1.0f; speedBoost = 1.0f; healthBoost = 1.0f;
    }

    public Weapon(string name)
    {
      this.name = name;
      damage = 10;
      damageBoost = 1.0f;
      speedBoost = 1.0f;
      healthBoost = 1.0f;
    }

    public Weapon(string name, float damageBoost, float speedBoost, float healthBoost)
    {
      this.name = name;

      this.damageBoost = damageBoost;
      this.speedBoost = speedBoost;
      this.healthBoost = healthBoost;
      damage = 10;

    }

}
