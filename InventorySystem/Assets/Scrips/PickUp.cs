using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    public RaycastHit raycastHit;
    public float raycastDistance;
    public Inventory inventory;
    public static int inInv;

	void Start () {
		
	}
	
	void Update () {
        if (Physics.Raycast(transform.position,transform.forward,out raycastHit,raycastDistance))
        {
            if (raycastHit.collider.GetComponent<Item>() != null && Input.GetButtonDown("Interact")&& inInv < inventory.itemslotScript.Count)
            {
                Item temp = (raycastHit.collider.GetComponent<Item>());
                inventory.AddItem(temp);
                temp.inv = inventory;
                
                Renderer render;
                render = raycastHit.collider.gameObject.GetComponent<Renderer>();
                render.enabled = false;
                GameObject col = raycastHit.collider.gameObject;
                col.GetComponent<Collider>().enabled = false;
                inInv++;
            }
        }
		
	}
}
