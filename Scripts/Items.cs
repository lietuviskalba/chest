using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    private Rigidbody rb;

    private float fallSpeed = 20f; // make it a random range

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {

        rb.velocity = new Vector3(0,-1,0) * fallSpeed;
	}
}
