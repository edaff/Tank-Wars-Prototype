using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTanksBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 2f;

    [SerializeField] float bulletHalfLife = 2f;

    static public float bulletDirection = 1f;

    Vector3 MoveToPosZ = new Vector3(0f, 0f, bulletDirection);

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveToPosZ * bulletSpeed * Time.deltaTime);

        Destroy(gameObject, bulletHalfLife);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I am " + gameObject.name + " and hit " + other);
        //Debug.Log("I am " + other.tag);

        /*This function handles what happens
         * when the bullet hits another tank
         * add a way for the bullet to handle
         * (-) Hp from other  tank if attack is valid
         */
        if (other.tag == "Blue Tank")
        {
            Destroy(gameObject);  //bullet will delete it self after it hits
        }

    }
}
