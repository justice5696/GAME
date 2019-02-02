using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectScript : UIBaseElement {
    
    public int MAX_INVENTORY_SIZE;
    public Object[] itemList; // change to 

	// Use this for initialization
	void Start () {
        itemList = new Object[MAX_INVENTORY_SIZE];
        isEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(!isEnabled){
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
	}

    void OnGUI()
    {
        if(isEnabled){
            
        }
    }

    private void DrawUI(){
        //GUI.DrawTexture()
    }
}
