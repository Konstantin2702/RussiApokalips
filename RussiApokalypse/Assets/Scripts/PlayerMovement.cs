using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private float health = 100;
    public Rigidbody2D rb;
    private bool isDead = false;
    public AudioClip death;
    private AudioSource sound;

    private Vector2 movement;
    public Vector2 mousePos;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

        if (health < 0)
        {
            sound.PlayOneShot(death);
            isDead = true;
        }
        if (isDead)
        {
            if (!sound.isPlaying)
                Destroy(gameObject);
        }
    }

    public void Hit(int damage)
    {
        health -= damage;
    }
}
