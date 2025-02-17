﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpTrack : MonoBehaviour
{
    [SerializeField] int players1Hp = 1;
    [SerializeField] int players2Hp = 1;
    bool reset = false;

    int currentSceneIndex;

    ObjectClicker playerHp;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        playerHp = FindObjectOfType<ObjectClicker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSceneIndex == 1)
        {
            players1Hp = playerHp.getObjectClickerGrid().getPlayerHealth(1);
            players2Hp = playerHp.getObjectClickerGrid().getPlayerHealth(2);
        }

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0) {
            reset = true;
        }

        if(currentSceneIndex == 1 && reset) {
            reset = false;
            Destroy(playerHp);
            playerHp = FindObjectOfType<ObjectClicker>();
        }
    }

    public int GetPlayersHp(int x)
    {
        if(x == 1)
        {
            return players1Hp;
        }
        else
        {
            return players2Hp;
        }
            
    }
}
