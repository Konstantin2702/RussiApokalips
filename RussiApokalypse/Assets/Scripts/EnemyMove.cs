using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    public float speed;
    public int health;

    private float distanse;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(Vector2.zero);
    }
    // Update is called once per frame
    //void Update()
    //{
    //    distanse = Vector2.Distance(transform.position, player.transform.position);
    //    Vector2 direction = player.transform.position - transform.position;
    //    direction.Normalize();
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
    //    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    //    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    //}

    //private void OnTriggerEnter2D(Collider2D collison)
    //{
    //    if (collison.CompareTag("Player"))
    //    {
    //        speed = 0;
    //    }
    //}
}
