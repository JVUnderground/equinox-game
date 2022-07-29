using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScore : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI scoreLabel;
    int score = 0;

    void Start() {
        scoreLabel = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterKill() {
        score++;
        scoreLabel.text = score.ToString();
    }
}
