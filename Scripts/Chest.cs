using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public Animator anim;

    private bool isOpen;

    void Start()
    {
        isOpen = false;
    }

	void FixedUpdate () {
		
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(toMouse, out hit))
            {
                OpenCloseChest();
                anim.SetTrigger("isLidOpen");
                Debug.Log("the chest is open?: " + isOpen);
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
}
