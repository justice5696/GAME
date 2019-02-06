using System;

[Serializable]

public class CharacterData
{

  //-1 is locked. 0 is open/uncompleted. 1 is open/completed
  public int dungeon1;
  public int dungeon2;
  public int dungeon3;
  public int dungeon4;
  public int dungeon5;
  public int dungeon6;
  public int dungeon7;
  public int dungeonF;

  //actual float values of the characters transform
  public float playerX;
  public float playerY;
  public float playerZ;

  //actual value of player's currency
  public int playerCurrency;


  //lists name (null for nothing) and x, y, z, of object
  //check out physics CheckSphere
  public string ObjInViewX;
  public string ObjInViewY;


  //holds the name of the weapon in that slot upon loading the game,
  //for each slot in the inventory, perform a getWeaponSlotN, if the
  //returned string is null, leave the slot empty, else, call
  //getWeapon(name) to retrieve the weapon from a prepopulated list
  //need to consider if one has multiple of one weapon could create  slot
  //for each possible weapon, and give the number that the player currently has
  public string weaponSlot1;
  public string weaponSlot2;
  public string weaponSlot3;
  public string weaponSlotN;


  //same as weapons. Need to account for quantity.
  public string consumableSlot1;
  public string consumableSlotN;

  //create a save variable for every skill in the game; use 1
  //for player has and 0 for player doesn’t have
  public int skill1;
  public int skillN;

}
