using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour {
    // Start is called before the first frame update

    float moveSpeed = 1.5f;
    bool isClaimed = false;
    float destroyAt = float.PositiveInfinity;
    GameObject target;
    CircleCollider2D _collider;
    AudioSource source;

    void Start() {
        _collider = GetComponent<CircleCollider2D>();
        source = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update() {
        if (isClaimed && target != null && destroyAt == float.PositiveInfinity) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        if (destroyAt < float.PositiveInfinity) {
            transform.position = target.transform.position;
        }
        if (Time.time > destroyAt) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!isClaimed && other.tag == "Player") {
            isClaimed = true;
            target = other.gameObject;
            _collider.radius = 0.01f;
        } else if (isClaimed && other.tag == "Player") {
            GetGathered();
        }
    }

    void GetGathered() {
        Player player = target.GetComponent<Player>();
        player.AddExperience(10);
        source.pitch = Random.Range(0.5f, 1.5f);
        destroyAt = Time.time + source.clip.length;
        source.Play();
    }
}
