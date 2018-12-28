using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    private Rigidbody rb;

    private string[] itemType;
    private float fallSpeed = 10f; // make it a random range

	void Start ()
    {
        ItemFall();

        itemType[0] = "Black";
        itemType[1] = "Red";
        itemType[2] = "Blue";

    }

    private void ItemFall()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, -1, 0) * fallSpeed;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Equals("Top"))
        {
            rb.velocity = RandomVector(2f, 6f);
            Destroy(this.gameObject, 2f);
        }
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min + 1, max);
        var y = Random.Range(min, max + 3);
        var z = Random.Range(min + 1, max);
        return new Vector3(x, y, z);
    }
}
