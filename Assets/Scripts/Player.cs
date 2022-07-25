using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHasHealth, IDamageable
{

    public float moveSpeed;
    public float health;
    public float maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void kill() {
        // Destroy(gameObject);
    }

    public void Damage(float amount) {
        health -= amount;

        if (health <= 0) {
            kill();
        }
    }

    public float Health() {
        return health;
    }

    public void Health(float health) {
        this.health = health;
    }

    public float MaxHealth() {
        return maxHealth;
    }

    public void MaxHealth(float maxHealth) {
        this.maxHealth = maxHealth;
        if (this.health > maxHealth) {
            this.health = maxHealth; 
        }
    }
}
