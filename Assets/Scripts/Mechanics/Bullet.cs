using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public float timer = 2f;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Collisions" || hitInfo.name == "Enemy")
            Destroy(gameObject);
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();
        if (enemy != null)
            enemy.TakeDamage(damage);
    }
}
