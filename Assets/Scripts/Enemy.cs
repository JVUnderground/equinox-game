using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IHasHealth, IDamageable {

    public float maxHealth = 30f;
    public float moveSpeed = 1f;
    public float attack = 1f;
    public GameObject expPrefab;
    private float health;
    private Transform target;
    EnemyScore score;


    void Start() {
        health = maxHealth;
        score = GameObject.FindGameObjectWithTag("HUD").GetComponentInChildren<EnemyScore>();
        print(score);
    }


    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        IDamageable target = (IDamageable) collision.collider.GetComponent(typeof(IDamageable));
        if (target != null && collision.collider.tag != "Enemy") target.Damage(attack);
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

    public void Damage(float amount) {
        if (health <= 0) return;

        health -= amount;
        if (health <= 0) {
            Instantiate(expPrefab, transform.position, Quaternion.identity);
            score.RegisterKill();
            foreach (IKillResponder responder in GetAllKillResponders()) {
                responder.OnKill(this);
            }
            Destroy(gameObject);
        }
    }

    List<IKillResponder> GetAllKillResponders() {
        List<IKillResponder> responders = new List<IKillResponder>();
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects) {
            IKillResponder responder = (IKillResponder)obj.GetComponent(typeof(IKillResponder));
            if (responder != null) responders.Add(responder);
        }

        return responders;
    }
}