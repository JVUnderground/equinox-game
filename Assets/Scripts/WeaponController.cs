using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Mouse : int {
    LeftClick = 0,
    RightClick = 1,
    MiddleClick = 2
}
public class WeaponController : MonoBehaviour, IHasLevels
{

    public ProjectileLaser ammunition;
    public float fireRate = 3f;
    private float nextFireTime = 0f;
    int level = 0;
    int maxLevel = 3;
    float vX = 0;
    float vY = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x != 0 || y != 0) {
            vX = x;
            vY = y;
        }

        if (Time.time > nextFireTime) {
            Vector3 origin = transform.position;
            Vector3 target = transform.position + new Vector3(vX, vY, 0f);
            nextFireTime += 1/fireRate;
            Shoot(origin, target);
        }
    }

    void Shoot(Vector3 origin, Vector3 target, bool debug=false) {
        Vector3 direction = target - origin;
        ProjectileLaser projectile = Instantiate(ammunition, origin, Quaternion.identity);
        projectile.direction = direction;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            
        }
    }

    public bool IsMaxLevel() {
        return level >= maxLevel;
    }

    public LevelDescription GetNextLevelDescription() {
        return new LevelDescription("Faster Reload", "Increases weapon fire rate by 50%");
    }

    public int Level() {
        return level;
    }

    public void LevelUp() {
        level += 1;
        fireRate *= 1.5f;
    }
}
