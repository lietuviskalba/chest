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
    private int selectedType;
    private int maxChestTypes;
    private bool isOpen;

    void Start()
    {
        isOpen = false;
        maxChestTypes = 2;

        SetupChestTypes(maxChestTypes);

        //Select what color will the chest start off with
        selectedType = (int)Random.Range(1, maxChestTypes + 1);

        SetChestColor(selectedType);       
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
            // Score a point here
            // Game over here
        }
    }
}
