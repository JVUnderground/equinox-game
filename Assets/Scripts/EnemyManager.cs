using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;
    private float nextActionTime = 0.0f;
    public float period = 1.0f;
    public GameObject player;
    

    Vector3 randomVector() {

        int direction = Random.Range(1, 5);
        float xMax=0, xMin=0, yMax=0, yMin=0;

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
            xMax = player.transform.position.x - 6.5f;
            xMin = player.transform.position.x - 4.5f;
            yMax = player.transform.position.y + 2.5f;
            yMin = player.transform.position.y - 2.5f;
        }

        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
      
        return new Vector3(x,y,0);
    }

    void Start() {

    }

    void Update () {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            Instantiate(enemyPrefab, randomVector(), Quaternion.identity);
        }
    }
}