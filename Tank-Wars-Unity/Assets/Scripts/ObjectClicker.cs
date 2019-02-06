using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour {

    public GameObject tankClicked = null;
    public GameObject tileClicked = null;
    public float yVal = 1f;

    public void ClickTest()
    {
        Debug.Log("Button was clicked");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Rigidbody rb;
                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {                        
                        print(hit.transform.gameObject);
                        if(hit.transform.gameObject.tag == "Tank"){
                        	tankClicked = hit.transform.gameObject;
                        }
                       	else if(hit.transform.gameObject.tag == "Tile" && tankClicked != null){
                       		tileClicked = hit.transform.gameObject;
              				//print("tankClicked: ");
              				//print(tankClicked);
              				//print("tileClicked: ");
              				//print(tileClicked);
              				tankClicked.transform.position = new Vector3(tileClicked.transform.position.x, yVal,tileClicked.transform.position.z);
              				tileClicked = null;
              				tankClicked = null;
                       	}
                    }
                }
            }
        }
    }
}