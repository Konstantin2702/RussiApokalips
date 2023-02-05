using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawn;
    private float startTime;
    public int counter;
    private int maxEnemies;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        maxEnemies = 3;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 5.0f)
        {
            if (counter < maxEnemies)
            {
                GameObject ob = Instantiate(enemy, spawn.position, spawn.rotation);
                ob.GetComponent<EnemyMove>().health = 100;
                startTime = Time.time;
                counter++;
            }
        }
    }
}
