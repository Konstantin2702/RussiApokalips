using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject hitEffect;

    public float bulletForce = 200f;

    public int delay = 25;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
            Thread.Sleep(delay);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Force);
   
    }

}
