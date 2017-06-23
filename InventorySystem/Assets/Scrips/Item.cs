using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public Sprite object2d;
    public GameObject object3d;
    public string nameItem;
    public int amount;
    public Inventory inv;
    //enz

    public virtual void start()
    {

    }

    public virtual void Interact()
    {

    }
    public virtual string UiInfo()
    {
        
        string ugh = "";
        return ugh;
    }
}
