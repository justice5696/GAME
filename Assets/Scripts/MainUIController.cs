using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIController : MonoBehaviour {

    public InventoryObjectScript inventoryReference;
    private UIBaseElement displayedElement;

	// Use this for initialization
	void Start () {
        displayedElement = null;
        inventoryReference = gameObject.GetComponentInChildren<InventoryObjectScript>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckUIInteraction();
	}

    private void CheckUIInteraction(){
        if(displayedElement == null){

            if(Input.GetKeyDown(inventoryReference.keyCode)){
                inventoryReference.PressButton();
                displayedElement = inventoryReference;
            }
        } else {
            if(Input.GetKeyDown(displayedElement.keyCode)){
                displayedElement.PressButton();
                displayedElement = null;
            }
        }



    }

}
