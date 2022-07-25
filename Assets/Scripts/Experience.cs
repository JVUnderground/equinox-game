using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour {
    // Start is called before the first frame update

    float moveSpeed = 1.5f;
    bool isClaimed = false;
    GameObject target;
    CircleCollider2D _collider;

    void Start() {
        _collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (isClaimed && target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!isClaimed && other.tag == "Player") {
            isClaimed = true;
            target = other.gameObject;
            _collider.radius = 0.05f;
        } else if (isClaimed && other.tag == "Player") {
            Player player = target.GetComponent<Player>();
            player.AddExperience(10);
            Destroy(gameObject);
        }
    }
}
