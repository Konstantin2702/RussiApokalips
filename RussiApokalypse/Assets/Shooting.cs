using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private List<GameObject> _entities;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 200f;

    public int delay = 25;
    // Update is called once per frame

    void Start()
    {
        _entities = new();
    }
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
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Force);
        Destroy(bullet, 0.5f);
    }
}
