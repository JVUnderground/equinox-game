using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IHasHealth {

    public float maxHealth = 30f;
    public float moveSpeed = 1f;
    public float attack = 1f;
    private float health;
    private Transform target;

    void Start() {
        health = maxHealth;
    }


    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        IDamageable target = (IDamageable) collision.collider.GetComponent(typeof(IDamageable));
        if (target != null) target.Damage(attack);
    }

    public void damage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void setTarget(GameObject targetObject) {
        target = targetObject.transform;
    }

    float IHasHealth.Health() {
        return health;
    }

    void IHasHealth.Health(float health) {
        this.health = health;
    }

    float IHasHealth.MaxHealth() {
        return maxHealth;
    }

    void IHasHealth.MaxHealth(float maxHealth) {
        this.maxHealth = maxHealth;
    }
}