using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour {

    public GameObject tankClicked = null;
    public GameObject tileClicked = null;
    public GameObject redTank;
    public GameObject blueTank;
    public float yVal = 1f;
    public int[,] terrainMapOne;
    public Grid grid;
    public int playerTurn;

    private void Start(){
      terrainMapOne = new int[,]
        {
            {0,2,0,2,1,1,0,2,0,2},
            {2,4,2,4,1,1,2,4,2,4},
            {3,2,3,2,1,1,3,2,3,2},
            {2,4,2,0,1,1,2,4,2,3},
            {3,2,4,2,1,1,0,2,0,2},
            {2,0,2,0,1,1,2,0,2,4},
            {4,2,3,2,1,1,3,2,3,2},
            {2,0,2,4,1,1,2,4,2,4},
            {3,2,3,2,1,1,0,2,0,2},
            {2,1,2,4,1,1,2,3,2,4}
        };

        redTank = GameObject.Find("redTank");
        blueTank = GameObject.Find("blueTank");

        grid = new Grid(terrainMapOne, 4, 0, 5, 9);

        playerTurn = 1;
    }

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
                       	else if(hit.transform.gameObject.tag == "Tile" && tankClicked != null)
                        {
                       		tileClicked = hit.transform.gameObject;
                            if(grid.canMove(playerTurn, (int)tileClicked.transform.position.x, (int)tileClicked.transform.position.z))
                            {
              				    tankClicked.transform.position = new Vector3(tileClicked.transform.position.x, yVal,tileClicked.transform.position.z);
              				    tileClicked = null;
              				    tankClicked = null;

                                if(++playerTurn > 2)
                                {
                                    playerTurn = 1;
                                }
                            }
                       	}
                    }
                }
            }
        }
    }
}