using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Hp : MonoBehaviour
{
    Text p2HpDisplay;
    ObjectClicker Player2Hp;
    
    // Start is called before the first frame update
    void Start()
    {
        Player2Hp = FindObjectOfType<ObjectClicker>();
        p2HpDisplay = GetComponent<Text>();;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Players 2 hp is: " + Player2Hp.getObjectClickerGrid().getPlayerHealth(2));
        p2HpDisplay.text = Player2Hp.getObjectClickerGrid().getPlayerHealth(2).ToString();
    }
}
