using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;
    private float nextActionTime = 0.0f;
    public float period = 1.0f;

    void Start() {

    }

    void Update () {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}