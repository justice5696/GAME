using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStatusEnemy : MonoBehaviour {

	private bool dead;
	private float Health;
	public float initialHealth;
	private float Damage;
	private float Speed;
	public Inventory D;
	public UnityEngine.AI.NavMeshAgent control;
    


	void Start () {
		Health = initialHealth;
	}

	// Update is called once per frame
	void Update ()
	{
		int interval = 10; //this shoudl keep update running 30/10 = 3 times per second
		if (Time.frameCount % interval == 0)
		{
			if(transform.position.y < -10)
			{
				Health = 0;
			}

			if(Health <= 0)
			{
				StartCoroutine(triggerCharacterDeath());
			}
			float best = 0.0f;
			Weapon bestW = new Weapon("Default");
			foreach(Weapon w in D.getWeapons())
			{
				float calc = w.damageBoost + w.speedBoost + w.healthBoost;
				if(calc > best)
				{
					bestW = w;
				}
			}
			D.equipWeapon(bestW);
			best = 0.0f;
			Mask bestM = new Mask("Default");
			foreach(Mask m in D.getMasks())
			{
				float calc = m.damageBoost + m.speedBoost + m.specialBoost + m.healthBoost;
				if(calc > best)
				{
					bestM = m;
				}
			}
			D.equipMask(bestM);
		}

	}

	IEnumerator triggerCharacterDeath() {

		dead = true;
		gameObject.SetActive(false);
		gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
		yield return new WaitForSeconds(0.1f);
		gameObject.SetActive(true);
		dead = false;
		//NEED TO DISABLE ENEMY, TRANSFORM TO SOMEWHERE ELSE (origin for now), THEN ENABLE
		//This should have worked, but for some reason the gameObejct remains inactive

	}

	public void setCharHealth(float change)
	{
		Health += change;
	}
	public float getCharHealth()
	{
		return Health;
	}

	private void OnCollisionEnter(Collision collision)
	{

			if(collision.gameObject.tag == "Tree")
			{
				Destroy(collision.gameObject);
			}
			else if(collision.gameObject.tag == "Enemy")
			{
				    getStats(false);
					CharacterStatusEnemy G = collision.gameObject.GetComponent<CharacterStatusEnemy>();
					//G.setCharHealth(-Damage);
			}

	}

	public void getStats(bool changeHealth)
	{
		//instead of get current modifiers do getHealthMod, getSpecialMod, etc..
		//instead of get stats do calculate health, claculate speed, calculate damage.
		Weapon w = D.getCurrentWeapon();
		Damage = (float)w.damage;
		Speed = 2;
		float[] temp = D.getCurrentModifiers();
		if(changeHealth) Health = initialHealth * temp[0];
		Speed *= temp[1];
		Damage *= temp[2];
		control.speed = Speed;
	}

}
