using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip clip;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
            Thread.Sleep(100);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        PlayAudio();
    }
    private void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}
