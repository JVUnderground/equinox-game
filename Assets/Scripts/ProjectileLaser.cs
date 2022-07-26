using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaser : MonoBehaviour
{

    public float bulletSpeed = 30f;
    public Vector3 direction;
    private Renderer renderEngine;

    // Start is called before the first frame update
    void Start()
    {   
        renderEngine = GetComponent<Renderer>();
        Vector2 direction_2d = direction;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = bulletSpeed * direction_2d.normalized;
    }

    void FixedUpdate() {
        if (!renderEngine.isVisible) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.damage(bulletSpeed);

            Destroy(gameObject);
        }
    }
}
