using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float maxHealth = 30f;
    public float moveSpeed = 1f;
    public Image healthBar;
    private float health;
    private Transform target;

    void Start() {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    public void damage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }

        healthBar.fillAmount = health / maxHealth;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}