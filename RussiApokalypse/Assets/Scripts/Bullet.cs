using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 15f;
    private int damage = 10;

    private int life = 0;

    private int lifeMax = 300;


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

    void OnCollisionEnter2D(Collision2D collision) //�����, ������� ����������� ��� ���������
    {
        Explode();
        var player = collision.gameObject;
        if (player.tag.Equals("Enemy"))
        {          
            if (player is null)
                return;
            var enemy = collision.gameObject.GetComponent<EnemyMove>();
            enemy.Hit(damage);
        }
    }

    void Explode()
    {
        Destroy(gameObject); //����������� �������

    }


}