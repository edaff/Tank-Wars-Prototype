using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    [Header("Player 1 GUI variable")]
    [SerializeField] GameObject p1MovementMenu;
    [SerializeField] GameObject p1AttackMenu;
    [SerializeField] GameObject p1GambleMenu;
    [SerializeField] GameObject p1PowerupMenu;
    public bool p1Move = true;
    public bool p1Attack = true;
    public bool p1Gamble = true;
    public bool p1Powerup = true;

    [Header("Player 2 GUI variable")]
    [SerializeField] GameObject p2MovementMenu;
    [SerializeField] GameObject p2AttackMenu;
    [SerializeField] GameObject p2GambleMenu;
    [SerializeField] GameObject p2PowerupMenu;
    public bool p2Move = true;
    public bool p2Attack = true;
    public bool p2Gamble = true;
    public bool p2Powerup = true;
    

    void Start()
    {
        p1PowerupMenu = GameObject.FindGameObjectWithTag("P1Powerup");
        p1PowerupMenu.SetActive(false);
        p2PowerupMenu = GameObject.FindGameObjectWithTag("P2Powerup");
        p2PowerupMenu.SetActive(false);
    }

    void Update()
    {
        /*for testing functions with key's. key are mapped 
         * to numpad 1 -3 for p1 gui menu and numpad 4-6 
         * for p2 gui menu
         */


        if (Input.GetKeyDown(KeyCode.M))
        {
            Player1Movement();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Player1Attack();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Player1Gamble();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Player2Movement();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Player2Attack();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Player2Gamble();
        }

    }

    /*
     * 
     * PLAYER 1 FUNCTIONS BELOW
     * 
     */

    //this function will turn on and off the players 1 movement text
    public void Player1Movement()
    {
        if(p1Move == true)
        {
            p1MovementMenu.SetActive(p1Move);
            p1Move = false;
        }
        else
        {
            p1MovementMenu.SetActive(p1Move);
            p1Move = true;
        }
    }

    //this function will turn on and off the players 1 attack text
    public void Player1Attack()
    {
        if (p1Attack == true)
        {
            p1AttackMenu.SetActive(p1Attack);
            p1Attack = false;
        }
        else
        {
            p1AttackMenu.SetActive(p1Attack);
            p1Attack = true;
        }
    }

    //this function will turn on and off the players 1 gamble text
    public void Player1Gamble()
    {
        if (p1Gamble == true)
        {
            p1GambleMenu.SetActive(p1Gamble);
            p1Gamble = false;
        }
        else
        {
            p1GambleMenu.SetActive(p1Gamble);
            p1Gamble = true;
        }
    }

    public void Player1Powerup() {
        if (p1Powerup == true) {
            p1PowerupMenu.SetActive(p1Powerup);
            p1Powerup = false;
        }
        else {
            p1PowerupMenu.SetActive(p1Powerup);
            p1Powerup = true;
        }
    }

    /*
     * 
     * PLAYER 2 FUNCTIONS BELOW
     * 
     */


    //this function will turn on and off the players 2 movement text
    public void Player2Movement()
    {
        if (p2Move == true)
        {
            p2MovementMenu.SetActive(p2Move);
            p2Move = false;
        }
        else
        {
            p2MovementMenu.SetActive(p2Move);
            p2Move = true;
        }
    }

    //this function will turn on and off the players 2 attack text
    public void Player2Attack()
    {
        if (p2Attack == true)
        {
            p2AttackMenu.SetActive(p2Attack);
            p2Attack = false;
        }
        else
        {
            p2AttackMenu.SetActive(p2Attack);
            p2Attack = true;
        }
    }

    //this function will turn on and off the players 2 gamble text
    public void Player2Gamble()
    {
        if (p2Gamble == true)
        {
            p2GambleMenu.SetActive(p2Gamble);
            p2Gamble = false;
        }
        else
        {
            p2GambleMenu.SetActive(p2Gamble);
            p2Gamble = true;
        }
    }

    public void Player2Powerup() {
        if (p2Powerup == true) {
            p2PowerupMenu.SetActive(p2Powerup);
            p2Powerup = false;
        }
        else {
            p2PowerupMenu.SetActive(p2Powerup);
            p2Powerup = true;
        }
    }

}
