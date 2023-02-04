using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 15f;
    private int damage = 20;

    private int life = 0;

    private int lifeMax = 300;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed; //Изменение скорости
        
    }

    void Update()
    {
        life++;

        if (life >= lifeMax)
        {
            Explode(); //Если снаряд пролетел определенное расстояние и ни с чем не столкнулся, его нужно удалить, чтобы он не расходовал ресурсы
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //Метод, который срабатывает при попадании
    {
        if (!collision.gameObject.tag.Equals("Player"))
        {
            Explode();
        }
    }

    void Explode()
    {
        
        Destroy(gameObject); //Уничтожение объекта
    }


}