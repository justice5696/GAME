using System;
using System.Collections.Generic;
using UnityEngine;

public class ContentsOfChest : MonoBehaviour {

  public List<Item> contents;
  private Inventory inv;
  private System.Random RND = new System.Random();
  public Inventory j;

  void Start() //maybe change back to start
  {
    Dictionary<string, Mask> masks = j.populateMasks();
    Dictionary<string, Weapon> weapons = j.populateWeapons();
    //generate random number from 1-3 that specifies how many items
    //then use random number generator to pick from the master list of weapons and masks
    int numItem = RND.Next(1,4);
    contents = new List<Item>();
    for(int i = 0; i < numItem; i++)
    {
      int maskOrWeapon = RND.Next(0,2);
      if(maskOrWeapon == 0)
      {
        int maskNum = RND.Next(1, masks.Count);
        int j = 1;
        foreach (KeyValuePair<string,Mask> entry in masks)
        {
          if(j == maskNum)
          {
            contents.Add((Item)entry.Value);    //adding the mask instance to the list of items
            break;
          }
          j++;
        }
      }
      else
      {
        int weaponNum = RND.Next(1, weapons.Count);
        int j = 1;
        foreach (KeyValuePair<string,Weapon> entry in weapons)
        {
          if(j == weaponNum)
          {
            contents.Add((Item)entry.Value);    //adding the mask instance to the list of items
            break;
          }
          j++;
        }
      }
    }


  }

  private void OnCollisionEnter(Collision collision)
	{
			if(collision.gameObject.tag == "Player")
			{
				if(Input.GetKey(KeyCode.R))
				{
          inv = collision.gameObject.GetComponent<Inventory>();
          for(int i = 0; i < contents.Count; i++)
          {
            if(contents[i] is Weapon)
              inv.addWeapon((Weapon)contents[i]);
            else
              inv.addMask((Mask)contents[i]);
          }
				}
			}
      else if(collision.gameObject.tag == "Enemy")
      {
        //Debug.Log("ContentsOfChest: OnCollisionEnter: Enemy should have gotten stuff in inventory.");
        inv = collision.gameObject.GetComponent<Inventory>();
        for(int i = 0; i < contents.Count; i++)
        {
          if(contents[i] is Weapon)
            inv.addWeapon((Weapon)contents[i]);
          else
            inv.addMask((Mask)contents[i]);
        }
      }
	}

  private void OnCollisionStay(Collision collision)
  {
      if(collision.gameObject.tag == "Player")
      {
        if(Input.GetKey(KeyCode.R))
        {
          inv = collision.gameObject.GetComponent<Inventory>();
          for(int i = 0; i < contents.Count; i++)
          {
            if(contents[i] is Weapon)
              inv.addWeapon((Weapon)contents[i]);
            else
              inv.addMask((Mask)contents[i]);
          }
        }
      }
  }

  private void OnCollisionExit(Collision collision)
  {
      if(collision.gameObject.tag == "Player")
      {
        if(Input.GetKey(KeyCode.R))
        {
          inv = collision.gameObject.GetComponent<Inventory>();
          for(int i = 0; i < contents.Count; i++)
          {
            if(contents[i] is Weapon)
              inv.addWeapon((Weapon)contents[i]);
            else
              inv.addMask((Mask)contents[i]);
          }
        }
      }
  }
}
