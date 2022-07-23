using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public float period = 1.0f;

    GameObject player;
    float nextActionTime = 0.0f;

    Vector3 randomVector() {

        int direction = Random.Range(1, 4);
        float xMax=0, xMin=0, yMax=0, yMin=0;
        print(direction);

        if (direction == 1) {
            xMax = player.transform.position.x + 4.5f;
            xMin = player.transform.position.x - 4.5f;
            yMax = player.transform.position.y + 4.5f;
            yMin = player.transform.position.y + 2.5f;
        }
    
        if (direction == 2) {
            xMax = player.transform.position.x + 6.5f;
            xMin = player.transform.position.x + 4.5f;
            yMax = player.transform.position.y + 2.5f;
            yMin = player.transform.position.y - 2.5f;
        }

        if (direction == 3) {
            xMax = player.transform.position.x + 4.5f;
            xMin = player.transform.position.x - 4.5f;
            yMax = player.transform.position.y - 2.5f;
            yMin = player.transform.position.y - 4.5f;
        }

        if (direction == 4) {
            xMax = player.transform.position.x - 4.5f;
            xMin = player.transform.position.x - 6.5f;
            yMax = player.transform.position.y + 2.5f;
            yMin = player.transform.position.y - 2.5f;
        }

        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
      
        return new Vector3(x,y,0);
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        if (player && Time.time > nextActionTime) {
            nextActionTime += period;
            Instantiate(enemyPrefab, randomVector(), Quaternion.identity);
        }
        else if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}