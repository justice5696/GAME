using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterWeaponList : MonoBehaviour
{

  public Dictionary<string, Weapon> MasterWeaponList;

    // Start is called before the first frame update
    void Start()
    {
      MasterWeaponList = new Dictionary<string, Weapon>()
          {
            {"Default",  new Weapon("Default")},
            {"Sword", new Weapon("Sword", 1.2f, 1.2f, 1.2f)},
            {"Axe", new Weapon("Axe", 1.4f, 1.1f, 1.1f)},
            {"Spear", new Weapon("Spear", 1.3f, 1.0f, 1.3f)},
            {"Staff", new Weapon("Staff", 1.1f, 1.25f, 1.25f)},
            {"Fireball", new Weapon("Fireball", 1.4f, 1.1f, 1.1f)},
            {"StupidDumb", new Weapon("StupidDumb", 4.0f, 4.0f, 4.0f)}
          };
    }

    public Weapon getWeapon(string name)
    {
      return MasterWeaponList[name];
    }
}
