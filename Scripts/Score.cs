using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameObject tint;
    public Text txtScore;
    public Text txtWin;
    public Text txtLose;  

    public static int points;
    public static bool isGameLost = false;
    public static bool isGameWon = false;

    public int goalScore;
    

    void Start()
    {
        SetUIElementsActivity(false, 0);
    }

    private void SetUIElementsActivity(bool isActive, int exeption)
    {
        if (exeption != 1)
        tint.SetActive(isActive);
        if (exeption != 2)
        txtWin.gameObject.SetActive(isActive);
        if (exeption != 3)
        txtLose.gameObject.SetActive(isActive);
    }

    void Update()
    {
        if (!isGameWon)
        {
            txtScore.text = "Score: " + points + "/" + goalScore;
            // win game when reached the goal
            if(points >= goalScore)
            {
                SetUIElementsActivity(true, 3);
                SetTextPropertiesOnWon();
                txtWin.text = "Level won \n (Next level)";
                isGameWon = true;
            }else if (isGameLost == true)
            {
                SetUIElementsActivity(true, 2);
                txtLose.text = "Game lost \n (Reset level)";
            }
        }       
    }

    private void SetTextPropertiesOnWon()
    {
        txtScore.color = Color.white;
        txtScore.transform.position = new Vector3(Screen.width * 0.3f, Screen.height * 0.8f, 0);
        txtScore.fontStyle = FontStyle.Bold;
    }
}
