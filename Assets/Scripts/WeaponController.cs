using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Mouse : int {
    LeftClick = 0,
    RightClick = 1,
    MiddleClick = 2
}
public class WeaponController : MonoBehaviour
{

    public ProjectileLaser ammunition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        Vector3 origin = transform.position;
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0f));

        bool isFiring = Input.GetMouseButtonDown((int) Mouse.LeftClick);
        if (isFiring) {
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
}
