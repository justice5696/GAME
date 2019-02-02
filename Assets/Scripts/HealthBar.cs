using System.Collections;
using System.Collections.Generic; using UnityEngine; using UnityEngine.UI;    public class HealthBar : MonoBehaviour
{      public Image ImgHealthBar;     public Text TxtHealth;     public int min;     public int max;       private int mCurrentValue;     private float mCurrentPercent;      public void SetHealth(int health)     {         if (health != mCurrentValue)         {             if (max - min == 0)             {                 mCurrentValue = 0;                 mCurrentPercent = 0;             }             else             {                 mCurrentValue = health;                  mCurrentPercent = (float)mCurrentValue / (float)(max - min);             }              TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));             ImgHealthBar.fillAmount = mCurrentPercent;

        }     }      public float CurrentPercent     {         get { return mCurrentPercent; }     }      public int CurerentValue     {         get { return mCurrentValue; }     }


    // Use this for initialization
    void Start()
    {         SetHealth(100);
    }

    // Update is called once per frame
    void Update()
    {         SetHealth((int)GameObject.FindWithTag("Player").transform.GetComponent<CharacterStatus>().getCharHealth());
    } }  
