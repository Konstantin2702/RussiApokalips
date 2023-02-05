using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawn;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 5.0f)
        {
            GameObject ob = Instantiate(enemy, spawn.position, spawn.rotation);
            ob.GetComponent<EnemyMove>().health = 100;
            startTime = Time.time;
        }
    }
}
