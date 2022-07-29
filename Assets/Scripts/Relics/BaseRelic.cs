using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRelic : MonoBehaviour, IStorable, IRelic {
    // Start is called before the first frame update
    public string relicName;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Inventory inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            inventory.StoreItem(gameObject);
            Destroy(gameObject);
        }
    }

    public Sprite Icon() {
        Sprite sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        return sprite;
    }

    public string RelicName() {
        return relicName;
    }
}
