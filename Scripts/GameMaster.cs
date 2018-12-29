using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    private GameObject[] chests;
    private GameObject[] items;

	void Start () {
        
	}

    void Update()
    {
        chests = GameObject.FindGameObjectsWithTag("Chests");
        items = GameObject.FindGameObjectsWithTag("Items");

        ShowAllObjects(chests);
        ShowAllObjects(items);
    }

    void ShowAllObjects(GameObject[] obs)
    {
        foreach (GameObject ob in obs)
        {
            // Debug.Log("ob: --> " + ob);
        }
    }
}
