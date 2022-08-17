using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryItemPrefab;
    GameObject item;
    Transform inventorySpace;
    void Start() {
        inventorySpace = gameObject.transform.Find("InventorySpace");
    }

    public void StoreItem(GameObject storableItem) {
        IStorable storable = (IStorable) storableItem.GetComponent(typeof(IStorable));
        if (storable == null) return;

        item = Instantiate(inventoryItemPrefab, inventorySpace);
        Image icon = item.GetComponentInChildren<Image>();
        Sprite clonedSprite = Instantiate(storable.Icon());
        icon.sprite = clonedSprite;

        IRelic relic = (IRelic) storableItem.GetComponent(typeof(IRelic));
        if (relic != null) OnStoreRelic(relic);
    }

    void OnStoreRelic(IRelic relic) {
        if (relic.RelicName() == "ExplosionRelic") item.AddComponent<ExplosionRelic>();
    }
}
