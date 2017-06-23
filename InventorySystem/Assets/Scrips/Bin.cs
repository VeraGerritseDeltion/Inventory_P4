using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : ItemSlot {	
	void Update () {
        inventory.DeleteItem();
	}
}
