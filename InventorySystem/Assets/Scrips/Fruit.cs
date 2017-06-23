using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Item {

    public bool peeled;
    public int health;
    public string peel = "unpeeled";
    public bool gone;

	void Start () {
        peel = "unpeeled";
        health = Random.Range(10, 30);
	}
    public override string UiInfo()
    {
        string itemInfo = "name: " +nameItem + "\n" + "peeled: " + peel +"\n"+ "recovers: " + health.ToString() + " health";
        return itemInfo;
    }
    public override void Interact()
    {
        if (peeled == false)
        {
            peeled = true;
            peel = "peeled";
        }
        else if(peeled == true)
        {
            inv.DeleteItem();
            Destroy(gameObject);
        }
    }
    
}
