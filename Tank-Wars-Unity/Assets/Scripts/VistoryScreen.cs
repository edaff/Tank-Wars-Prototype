using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistoryScreen : MonoBehaviour
{
    [SerializeField] GameObject player1Wins;
    [SerializeField] GameObject player2Wins;

    HpTrack checkPlayerHp;

    int player1Hp;
    int player2Hp;


    // Start is called before the first frame update
    void Start()
    {
        
        //checkPlayerHp = FindObjectOfType<HpTrack>();

        //player1Hp = checkPlayerHp.GetPlayersHp(1);
        //player2Hp = checkPlayerHp.GetPlayersHp(2);
        

    }

     //Update is called once per frame
    void Update()
    {
        checkPlayerHp = FindObjectOfType<HpTrack>();
        player1Hp = checkPlayerHp.GetPlayersHp(1);
        player2Hp = checkPlayerHp.GetPlayersHp(2);
        //Debug.Log("players 1 hp is " + player1Hp);
        //Debug.Log("players 2 hp is " + player2Hp);

        if (player1Hp <= 0)
        {
            player2Wins.SetActive(true);
        }
        else if(player2Hp <= 0)
        {
            player1Wins.SetActive(true);
        }
        else
        {
            //Debug.Log("No one won :(");
        }
    }
}
