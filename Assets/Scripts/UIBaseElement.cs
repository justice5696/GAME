using UnityEngine;
using System.Collections;

public class UIBaseElement : MonoBehaviour
{
    public KeyCode keyCode;
    public bool isEnabled;

    public virtual void PressButton(){
        isEnabled = !isEnabled;
        Debug.Log("Press Button");
        if(isEnabled){
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }

    }
}
