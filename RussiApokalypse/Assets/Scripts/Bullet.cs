using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 15f;
    private int damage = 20;

    private int life = 0;

    private int lifeMax = 500;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed; //��������� ��������
    }

    void Update()
    {
        life++;

        if (life >= lifeMax)
        {
            Explode(); //���� ������ �������� ������������ ���������� � �� � ��� �� ����������, ��� ����� �������, ����� �� �� ���������� �������
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) //�����, ������� ����������� ��� ���������
    {
        Explode();
    }

    void Explode()
    {
        Destroy(gameObject); //����������� �������
    }
}