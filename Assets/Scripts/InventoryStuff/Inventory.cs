using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	//should probably use lists of some sort
	private List<Weapon> WeaponList;
	private List<Mask> MaskList;
	private Weapon currentWeapon;
	private Mask currentMask;
	public Dictionary<string, Weapon> MasterWeaponList;
	public Dictionary<string, Mask> MasterMaskList;
	private int weaponNextNew; private int maskNextNew;

	// Use this for initialization
	void Start() {
		populateWeapons();
		populateMasks();
		WeaponList = new List<Weapon>();
		MaskList = new List<Mask>();
		weaponNextNew =0; maskNextNew=0;
		for(int i=0; i< 6;i++){WeaponList.Add(new Weapon());}
		for(int i=0; i< 6;i++){MaskList.Add(new Mask());}
		currentWeapon = MasterWeaponList["Default"];
		currentMask = MasterMaskList["Default"];
		addWeapon(currentWeapon);
		addMask(currentMask);

	}

	public void addWeapon(Weapon w)
	{
		int index;
		Weapon blank = new Weapon();
		if(WeaponList.IndexOf(blank) > 0)
		{
			index = WeaponList.IndexOf(blank);
			WeaponList[index] = w;
			Debug.Log("Adding weapon to waepon list");
		}
		else if(WeaponList.Contains(w))
		{
			//do nothing
		}
		else
		{
			weaponNextNew = weaponNextNew % 6;
			//Debug.Log("WeaponNextNew: " + weaponNextNew.ToString());
			WeaponList[weaponNextNew] = w;
			weaponNextNew++;
		}
	}
	public void removeWeapon(Weapon w)
	{
	 	//	if(FindIndex(WeaponList, w) >= 0)
		//	WeaponList[FindIndex(WeaponList, w)] = null;
	}

	public void equipWeapon(Weapon w)
	{
		currentWeapon = w;
		if(gameObject.tag == "Enemy"){gameObject.GetComponent<CharacterStatusEnemy>().getStats(false);}
		else if(gameObject.tag == "Player"){gameObject.GetComponent<CharacterStatus>().getStats(false);}
	}
	public Weapon getCurrentWeapon()
	{
		return currentWeapon;
	}

	public void addMask(Mask m)
	{
		int index;
		Mask blank = new Mask();
		if(MaskList.IndexOf(blank) > 0)
		{
			index = MaskList.IndexOf(blank);
			MaskList[index] = m;
		}
		else if(MaskList.Contains(m))
		{
			//do nothing
		}
		else
		{
			MaskList[maskNextNew%6] = m;
			maskNextNew++;
		}
	}
	public void removeMask(Mask m)
	{
	//	if(FindIndex(MaskList, m) >= 0)
		//	MaskList[FindIndex(MaskList, m)] = null;
	}
	public void equipMask(Mask m)
	{
		currentMask = m;
		if(gameObject.tag == "Enemy"){gameObject.GetComponent<CharacterStatusEnemy>().getStats(false);}
		else if(gameObject.tag == "Player"){gameObject.GetComponent<CharacterStatus>().getStats(false);}
	}
	public Mask getCurrentMask()
	{
		return currentMask;
	}

	public List<Weapon> getWeapons()
	{
		return WeaponList;
	}

	public List<Mask> getMasks()
	{
		return MaskList;
	}

	public Dictionary<string, Weapon> populateWeapons()
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
		return MasterWeaponList;
	}
	public Dictionary<string, Mask> populateMasks()
	{
		MasterMaskList = new Dictionary<string, Mask>()
				{
					{"Default", new Mask("Default")},
					{"SMask", new Mask("SMask", "Sword", 1.2f, 1.2f, 1.2f, 1.2f)},
					{"AMask", new Mask("AMask", "Axe", 1.2f, 1.2f, 1.2f, 1.2f)},
					{"SpMask", new Mask("SpMask", "Spear", 1.1f, 1.3f, 1.0f, 1.3f)},
					{"StMask", new Mask("StMask", "Staff", 1.1f, 1.1f, 1.25f, 1.25f)},
					{"FireMask", new Mask("FireMask", "Fireball", 1.1f, 1.4f, 1.1f, 1.1f)},
					{"StupidDumbMask", new Mask("StupidDumbMask", "StupidDumb", 10.0f, 4.0f, 4.0f, 4.0f)}
				};
		return MasterMaskList;
	}


	//character status should call this function after equipping a new weapon or mask
	public float[] getCurrentModifiers()
	{
		Weapon w = getCurrentWeapon();
		Mask m = getCurrentMask();
		float health = 1.0f; float speed = 1.0f; float attack = 1.0f;
		health *= w.healthBoost;
		health *= m.healthBoost;
		speed *= w.speedBoost;
		speed *= m.speedBoost;
		attack *= w.damageBoost;
		attack *= m.damageBoost;
		if(w.name == m.specialPair)
		{
			speed *= m.specialBoost;
			health *= m.specialBoost;
			attack *= m.specialBoost;
		}
		return new float[3] {health, speed, attack};
	}

}
