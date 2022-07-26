using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour {
    // Start is called before the first frame update

    float moveSpeed = 3f;
    float bounceDuration = 0.2f;
    float bounceTime = float.PositiveInfinity;
    bool bounced = false;
    bool isClaimed = false;
    GameObject target;
    CircleCollider2D _collider;
    Rigidbody2D rb;

    void Start() {
        _collider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (isClaimed && target != null) {
            if (Time.time > bounceTime) {
                if (bounced) {
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                } else {
                    rb.velocity = Vector3.zero;
                    bounced = true;
                }
                
            } else {
                Vector3 force = gameObject.transform.position - target.transform.position;
                rb.velocity = 3 * force;
            }   
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!isClaimed && other.tag == "Player") {
            isClaimed = true;
            target = other.gameObject;
            _collider.radius = 0.05f;
            bounceTime = Time.time + bounceDuration;
        } else if (isClaimed && other.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            player.AddExperience(10);
            Destroy(gameObject);
        }
    }
}
