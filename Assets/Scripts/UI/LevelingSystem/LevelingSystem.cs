using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelingSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxOptions = 1;
    public GameObject optionPrefab;
    GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        InstantiateOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<IHasLevels> GetAvailableLevelUps() {
        List<IHasLevels> itemsAvailableToLevelUp = new List<IHasLevels>();
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects) {
            IHasLevels item = (IHasLevels)obj.GetComponent(typeof(IHasLevels));
            if (item != null && !item.IsMaxLevel()) itemsAvailableToLevelUp.Add(item);
        }

        return itemsAvailableToLevelUp;
    }

    void InstantiateOptions() {
        List<IHasLevels> availableLevels = GetAvailableLevelUps();
        int _maxOptions = Mathf.Min(maxOptions, availableLevels.Count);

        for (int i=0; i<_maxOptions; i++) {
            GameObject option = Instantiate(optionPrefab, gameObject.transform);
            int randomIndex = Random.Range(0, availableLevels.Count);

            IHasLevels randomLevelUpOption = availableLevels[randomIndex];
            availableLevels.RemoveAt(randomIndex);

            TextMeshProUGUI[] labels = option.GetComponentsInChildren<TextMeshProUGUI>();
            LevelDescription level = randomLevelUpOption.GetNextLevelDescription();
            PopulateOptionLabels(option, level);

            LevelOption levelOption = option.GetComponent<LevelOption>();
            levelOption.onSelect = () => {
                randomLevelUpOption.LevelUp();
                gameManager.OnOptionSelected();
            };
        }

        if (_maxOptions == 0) {
            InstantiateDefaultOption();
        }
    }

    void PopulateOptionLabels(GameObject option, LevelDescription level) {
        TextMeshProUGUI[] labels = option.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI label in labels) {
            if (label.name == "Title") label.text = level.title;
            if (label.name == "Description") label.text = level.description;
        }
    }

    void InstantiateDefaultOption() {
        GameObject option = Instantiate(optionPrefab, gameObject.transform);
        TextMeshProUGUI[] labels = option.GetComponentsInChildren<TextMeshProUGUI>();
        LevelDescription healPlayer = new LevelDescription("Heal", "Heal for 30HP");
        PopulateOptionLabels(option, healPlayer);

        LevelOption levelOption = option.GetComponent<LevelOption>();
        levelOption.onSelect = () => {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            float currentHealth = player.Health();
            player.Health(currentHealth + 30);
            gameManager.OnOptionSelected();
        };

    }
}
