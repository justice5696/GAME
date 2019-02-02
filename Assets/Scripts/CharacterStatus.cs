using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour {

	private bool dead;
	public bool trigger;
	public float initialHealth;
    public float initialScore;
	private float Health;
	private float Damage;
	private float Speed;
	public Inventory D;
	//public SimpleCharacterControl control;
	private GameObject cammer;
	private SwitchCams hi;
    private float Score;

	void Start()
	{
		cammer = GameObject.Find("OverheadCam");
		hi = cammer.GetComponent<SwitchCams>();
		Health = initialHealth;
    Score = initialScore;
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
		}
	}
	public void setTrigger(bool f)
	{
		trigger = f;
	}

	public bool getTrigger()
	{
		return trigger;
	}

	IEnumerator triggerCharacterDeath() {

		dead = true;
		hi.ShowOverheadView();
		UIManager1 HH = GameObject.Find("Directional Light").GetComponent<UIManager1>();
		HH.showDeath();
		yield return new WaitForSeconds(5.0f);
		SceneManager.LoadScene("Title");
		//hi.ShowFirstPersonView();
		//SceneManager.LoadScene("Game");
		//dead = false;
		//NEED TO DISPLAY YOU DIED TEXT AND present with option to play another round

	}

	public void setCharHealth(float change)
	{
		Health += change;
	}
	public float getCharHealth()
	{
		return Health;
	}

  public float getCharScore()
  {
      return Score;
  }

	private void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.tag == "Tree")
			{
				Destroy(collision.gameObject);
			}
			else if(collision.gameObject.tag == "Enemy")
			{
				if(Input.GetMouseButtonUp(0))
				{
					getStats(false);
					CharacterStatusEnemy G = collision.gameObject.GetComponent<CharacterStatusEnemy>();
                    //CharacterStatus G = collision.gameObject.GetComponent<CharacterStatus>();
                    Score += Damage;
					//G.setCharHealth(-Damage);
				}
			}
			else if(collision.gameObject.tag == "Chest")
			{
				if(Input.GetKey(KeyCode.R))
				{
					Destroy(collision.gameObject);
				}
			}
	}



	public void getStats(bool resetHealth)
	{
		//instead of get current modifiers do getHealthMod, getSpecialMod, etc..
		//instead of get stats do calculate health, claculate speed, calculate damage.
		Weapon w = D.getCurrentWeapon();
		Damage = (float)w.damage;
        Speed = 5;
		float[] temp = D.getCurrentModifiers();
		if(resetHealth) Health = initialHealth * temp[0];
        Speed *= temp[1];
		Damage *= temp[2];
		//control.setSpeed(Speed);
	}

}
