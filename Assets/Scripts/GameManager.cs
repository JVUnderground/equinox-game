using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ILevelUpListener
{
    public bool paused = false;
    public GameObject playerPrefab;
    public GameObject enemySpawnerPrefab;
    public GameObject levelingDashboardPrefab;
    GameObject levelingDashboard;
    BoardManager boardManager;

    void Awake()
    {
        boardManager = GetComponent<BoardManager>();
        boardManager.SetupScene(3);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseGame() {
        this.paused = true;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    void ResumeGame() {
        this.paused = false;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void OnPlayerLevelUp(int level) {
        levelingDashboard = Instantiate(levelingDashboardPrefab, Vector3.zero, Quaternion.identity);
        PauseGame();
    }

    public void OnOptionSelected() {
        Destroy(levelingDashboard);
        ResumeGame();
    }
}
