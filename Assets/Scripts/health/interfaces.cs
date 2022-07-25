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