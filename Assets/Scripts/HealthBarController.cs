using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    Image healthBar;
    GameObject target;

    // Start is called before the first frame update
    void Start() {
        healthBar = GetComponent<Image>();
        target = transform.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update() {
        IHasHealth state = (IHasHealth)target.GetComponent(typeof(IHasHealth));
        if (state != null) {
            healthBar.fillAmount = state.Health() / state.MaxHealth();
        }
    }
}
