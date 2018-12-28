using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFirstItem : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
