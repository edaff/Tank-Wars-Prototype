using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

     [SerializeField] public static float x = 4f;

    Vector3 rowX = new Vector3(x, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.Translate(rowX * Time.deltaTime);
        }
    }
}
