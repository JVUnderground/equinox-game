using System.Collections;
using UnityEngine;

public interface IRelic {
    public string RelicName();
}
public interface IWeaponOnHitModifier {
    public void OnHit(Enemy enemy);
}

public interface IKillResponder {
    public void OnKill(Enemy enemy);
}
