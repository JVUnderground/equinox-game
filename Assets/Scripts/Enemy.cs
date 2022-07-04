using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float maxHealth = 30f;
    public Image healthBar;
    private float health;

    void Start() {
        health = maxHealth;
    }
    
    public void damage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }

        healthBar.fillAmount = health / maxHealth;
    }
}