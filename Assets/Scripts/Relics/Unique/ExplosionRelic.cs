using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRelic : MonoBehaviour, IHasLevels, IKillResponder
{
    // Start is called before the first frame update
    // This explosion prefab should PROBABLY be a shader.
    GameObject explosionEffectPrefab;
    float explosionChance = 0.05f;
    float explosionRange = 0.5f;
    float explosionDamage = 5f;

    int level = 0;
    LevelDescription[] levels = new LevelDescription[] {
        new LevelDescription("Better odds", "Increase explosion odds by 5%"),
        new LevelDescription("Bigger range", "Increase explosion range by 50%"),
        new LevelDescription("Better odds", "Increase explosion odds by 5%"),
        new LevelDescription("Bigger range", "Increase explosion range by 50%")
    };

    public LevelDescription GetNextLevelDescription() {
        return levels[level + 1];
    }

    public bool IsMaxLevel() {
        return level == levels.Length - 1;
    }

    public int Level() {
        return level;
    }

    public void LevelUp() {
        level++;
        LevelDescription newLevel = levels[level];
        if (newLevel.title == "Better odds") {
            explosionChance += 0.05f;
        }
        if (newLevel.title == "Bigger range") {
            explosionRange *= 1.5f;
        }
    }

    public void OnKill(Enemy killed) {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber > explosionChance) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            if (enemy == killed) continue;
            float distance = (enemy.transform.position - killed.transform.position).sqrMagnitude;
            if (distance <= explosionRange) {
                IDamageable damageable = (IDamageable)enemy.GetComponent(typeof(IDamageable));
                damageable.Damage(explosionDamage);
            }
        }
    }
}
