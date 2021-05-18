using Platformer.Mechanics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer = 2f;
    WeaponController weapon;

    void Start()
    {
        GameObject weaponObject = GameObject.FindGameObjectWithTag("ActiveWeapon");
        if(weaponObject != null)
        {
            weapon = weaponObject.GetComponent<WeaponController>();
            rb.velocity = transform.right * weapon.bulletSpeed;
        }
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
            enemy.TakeDamage(weapon.damage);
    }
}
