using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
    }


    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}
