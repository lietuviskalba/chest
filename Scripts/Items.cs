using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    private Rigidbody rb;
    private Renderer rend;
    public Material[] itemColors = new Material[3];

    private string[] itemType;
    private string thisItemType;
    private int randType;
    private int minTypes = 2;
    private int maxTypes = 3;
    private float fallSpeed = 10f; // make it a random range

	void Start ()
    {
        ItemFall();
        SetupAllItemTypes();

        randType = (int)Random.Range(minTypes, maxTypes + 1); //when spawned gain a random type

        SetItemType(randType);

        //Set color
        rend = GetComponent<Renderer>();
        rend.material = itemColors[randType - 1];

        //Set speed
        fallSpeed = Random.Range(5f, 10f);
    }

    private void SetupAllItemTypes()
    {
        itemType = new string[3];

        itemType[0] = "Black";
        itemType[1] = "Red";
        itemType[2] = "Blue";
    }

    public void SetItemType(int randType)
    {
        thisItemType = itemType[randType-1];
    }

    public string GetItemType()
    {
        return thisItemType;
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
