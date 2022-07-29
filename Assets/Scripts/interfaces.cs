using System.Collections;
using UnityEngine;

public interface IHasHealth {
    public float Health();
    public void Health(float health);
    public float MaxHealth();
    public void MaxHealth(float maxHealth);
}

public interface IDamageable {
    public void Damage(float amount);
}

public interface ILevelUpListener {
    public void OnPlayerLevelUp(int level);
}

public interface IHasLevels {
    public bool IsMaxLevel();
    public LevelDescription GetNextLevelDescription();
    public int Level();
    public void LevelUp();
}

public interface IStorable {
    public Sprite Icon();
}

public class LevelDescription {
    public string title;
    public string description;

    public LevelDescription(string title, string description) {
        this.title = title;
        this.description = description;
    }
}