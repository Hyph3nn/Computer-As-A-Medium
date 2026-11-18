using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f; // Time in seconds before the bullet is destroyed
    public float bulletDamage = 5f; // Damage dealt by the bullet
    public Knockback knockback;
    public float knockbackForce;

    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //bullet only exists for a short time, and moves in the direction it was shot, and is destroyed after a set time
    //not necessary to have an update function, as the bullet is destroyed after a set time
    void Start()
    {
    rb.linearVelocity = transform.up * speed; // Set the bullet's velocity in the direction it is facing
    Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.enemyHealth -= bulletDamage;
            }
            Destroy(gameObject); // Destroy the bullet after hitting an enemy
        }
    }
}
