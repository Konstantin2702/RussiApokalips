using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip clip;
    private double _delay = 0.2;
    private double _currentTime;

    // Update is called once per frame
    void Start()
    {
        _currentTime = Time.deltaTime;
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - _currentTime > _delay)
            {
                Shoot();
                _currentTime = Time.time;
            }

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
