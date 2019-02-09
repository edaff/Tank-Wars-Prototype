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
    bool p1Move = true;
    bool p1Attack = true;
    bool p1Gamble = true;

    [Header("Player 2 GUI variable")]
    [SerializeField] GameObject p2MovementMenu;
    [SerializeField] GameObject p2AttackMenu;
    [SerializeField] GameObject p2GambleMenu;
    bool p2Move = true;
    bool p2Attack = true;
    bool p2Gamble = true;
    

    void Start()
    {
       
    }

    void Update()
    {
        /*for testing functions with key's. key are mapped 
         * to numpad 1 -3 for p1 gui menu and numpad 4-6 
         * for p2 gui menu
         */


        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Player1Movement();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Player1Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Player1Gamble();
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Player2Movement();
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Player2Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
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

}
