using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public int health;
    public AudioClip hit;
    public AudioClip death;
    private AudioSource[] sounds;
    private bool isDead = false;
    private float begin;
    private int damage = 30;

    private void Start()
    {
        health = 100;
        sounds = GetComponents<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

            Vector3 dir = player.transform.position - gameObject.transform.position;
            gameObject.transform.position += dir.normalized * speed * Time.deltaTime;
            print(health);
            if (health == 0)
            {
                var audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
                audio.EnemyDeath(death);
                Destroy(gameObject);

            }
        }
        else
        {
            speed = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        begin = Time.time;
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
     
        if (Time.time - begin > 1)
        {
            var player = collision.gameObject;
            if (player.tag.Equals("Player"))
            {
                if (player is null)
                    return;
                var enemy = collision.gameObject.GetComponent<PlayerMovement>();
                enemy.Hit(damage);
                begin = Time.time;
            }
        }
    }
    public void Hit(int damage)
    {
        health -= damage;
        sounds[0].PlayOneShot(hit);
    }

}
