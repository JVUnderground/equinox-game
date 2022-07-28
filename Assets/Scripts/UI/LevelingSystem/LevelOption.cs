using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelOption : MonoBehaviour, IPointerDownHandler {
    public delegate void onSelectDelegate();
    public onSelectDelegate onSelect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        onSelect();
    }
}
