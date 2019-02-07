using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour {

    public GameObject tankClicked = null;
    public GameObject tankClicked2 = null;
    public GameObject tileClicked = null;
    public GameObject redTank;
    public GameObject blueTank;
    public float yVal = 1f;
    public int[,] terrainMapOne;
    public Grid grid;
    public int playerTurn;
    public int round;
    public bool gamblePressed = false;
    public Transform Target;
    public bool cameraToggle = false;

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

        Target = GameObject.Find("Cube(0,0) (44)").transform;

        redTank = GameObject.Find("redTank");
        blueTank = GameObject.Find("blueTank");

        grid = new Grid(terrainMapOne, 4, 0, 5, 9);

        playerTurn = 1;
        round = 1;
    }

    public void GambleButton()
    {
        if(round == 3)
        {
            gamblePressed = true;
            string powerUp = grid.gamble(playerTurn);
            Debug.Log(powerUp);
        }
    }

    public void NoGambleButton()
    {
        if(round == 3)
        {
            gamblePressed = true;
            Debug.Log("Player " + playerTurn + " chose not to gamble");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && cameraToggle == false)
        {
            cameraToggle = true;
        }
        else if(Input.GetKeyDown(KeyCode.Z) && cameraToggle == true)
        {
            cameraToggle = false;
        }
        if (cameraToggle)
        {
            transform.RotateAround(Target.position, Target.transform.up, -Input.GetAxis("Mouse X") * 50);
        }

        if (Input.GetMouseButtonDown(0) || round == 3)
        {
            if(round == 1)
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
                            if(hit.transform.gameObject.tag == "Red Tank" || hit.transform.gameObject.tag == "Blue Tank")
                            {
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
                                    round++;
                                }
                            }
                        }
                    }
                }
            }
            else if(round == 2)
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
                            if(hit.transform.gameObject.tag == "Red Tank")
                            {
                                tankClicked = hit.transform.gameObject;
                            }
                            else if(hit.transform.gameObject.tag == "Blue Tank")
                            {
                                tankClicked2 = hit.transform.gameObject;
                            }
                            if(tankClicked != null && tankClicked2 != null)
                            {
                                if(grid.canAttack(playerTurn, (int)tankClicked2.transform.position.x, (int) tankClicked2.transform.position.z))
                                {
                                    print("Good attack");
                                }
                                else
                                {
                                    print("Bad attack");
                                }
                                tankClicked = null;
                                tankClicked2 = null;
                                round++;
                            }
                        }
                    }
                }
            }
            else if(round == 3)
            {
                if(gamblePressed)
                {
                    gamblePressed = false;
                    round = 1;
                    if(++playerTurn > 2)
                    {
                        playerTurn = 1;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(round == 1)
            {
                if(playerTurn == 1){
                    print("Red tank move phase");
                }
                else if(playerTurn == 2){
                    print("Blue tank move phase");
                }
            }
            if(round == 2)
            {
                if(playerTurn == 1){
                 print("Red tank attack phase");
                }
                else if(playerTurn == 2){
                  print("Blue tank attack phase");
                }
            }
            if(round == 3)
            {
                if(playerTurn == 1){
                    print("Red tank gamble phase");
                }
                else if(playerTurn == 2){
                    print("Blue tank gamble phase");
                }
            }
        }
    }
}