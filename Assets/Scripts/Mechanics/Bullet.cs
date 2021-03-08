using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "Level" || hitInfo.name == "Enemy")
            Destroy(gameObject);
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();
        if (enemy != null)
            enemy.TakeDamage(damage);
    }
}
