using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Hp : MonoBehaviour
{
    Text p1HpDisplay;
    ObjectClicker Player1Hp;
    
    // Start is called before the first frame update
    void Start()
    {
        Player1Hp = FindObjectOfType<ObjectClicker>();
        p1HpDisplay = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Players 1 hp is: " + Player1Hp.getObjectClickerGrid().getPlayerHealth(1));
        p1HpDisplay.text = Player1Hp.getObjectClickerGrid().getPlayerHealth(1).ToString();
    }
}
