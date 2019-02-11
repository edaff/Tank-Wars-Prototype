using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Fire();
        }
    }


    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}
