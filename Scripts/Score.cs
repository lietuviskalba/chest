using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public static int points;

    void Update()
    {
        Debug.Log("The score is: " + points);
    }
}
