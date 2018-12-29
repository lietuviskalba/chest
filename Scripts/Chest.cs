using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject lid;
    public Material[] chestColors = new Material[2]; // change this dependant on type amount
    public Animator anim;
    private Renderer rendLid;

    private string[] chestType;
    private string thisChestType;
    private int randType;
    private int maxChestTypes;
    private bool isOpen;

    void Start()
    {
        isOpen = false;
        maxChestTypes = 2;

        SetupChestTypes(maxChestTypes);

        //Select what color will the chest start off with
        randType = (int)Random.Range(1, maxChestTypes + 1);

        SetChestColor(randType);       
    }

	void FixedUpdate () {

        ClickChest();
	}

    void SetChestColor(int chestTypeGot)
    {
        rendLid = lid.GetComponent<Renderer>();
        
        rendLid.material = chestColors[chestTypeGot];
        thisChestType = chestType[chestTypeGot-1];
    }

    void SetupChestTypes(int maxChestTypes)
    {
        
        chestType = new string[maxChestTypes];

        chestType[0] = "Red";
        chestType[1] = "Blue";
    }
    void ClickChest()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(toMouse, out hit))
            {
                OpenCloseChest();
                anim.SetTrigger("isLidOpen");
            }
        }
    }
    void OpenCloseChest()
    {
        if (isOpen == false)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Items")
        {
            Destroy(col.gameObject);
            if (col.gameObject.GetComponent<Items>().GetItemType().Equals(thisChestType))
            {
                Score.points += 1;
                //track here if required item points reached
            }
            else
            {
                //Add game over text here
                Debug.Log("GAME OVER");
            }
        }
    }
}
