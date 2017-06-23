using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    public float damage;
    public float durability;

    private void Start()
    {
        damage = Random.Range(20, 50);
        durability = Random.Range(5, 10);
    }

    public override string UiInfo()
    {
        string itemInfo = "name: " + nameItem + "\n" + "damage: " + damage + "\n" + "recovers: " + durability + " health";
        return itemInfo;
    }
}
