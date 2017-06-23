using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {
    public List<GameObject> items = new List<GameObject>();
    public int amountOfItems;

	void Start () {
		for(int i = 0;i < amountOfItems; i++)
        {
            int r = Random.Range(0, items.Count);
            print(r);
            Vector3 loc = new Vector3(Random.Range(-60, 60), 1, Random.Range(-60, 60));
            Instantiate(items[r], loc, Quaternion.identity);
        }
	}
	
	void Update () {
		
	}
}
