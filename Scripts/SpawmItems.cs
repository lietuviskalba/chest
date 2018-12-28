using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmItems : MonoBehaviour {

    public GameObject item;

    private float spawnRate;
    private float nextSpawn;
    private float minRate;
    private float maxRate;

    void Start()
    {
        nextSpawn = 3f; // Wait a sec before spawning
    }

	void Update () {

        minRate = 1f;
        maxRate = 2f;

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(item, transform.position, Quaternion.identity);
            spawnRate = Random.Range(minRate, maxRate);
        }
    }
}
