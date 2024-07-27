using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CogRotate : MonoBehaviour
{
    public float multiplayer;
    public Slider sliderObj;

    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderObj = sliderObj.GetComponent<Slider>();

        float min = sliderObj.minValue;
        float max = sliderObj.maxValue;

        float amountToRotate = sliderObj.value / max * multiplayer;


        Quaternion rot = transform.rotation;
        rectTransform.localRotation = Quaternion.Euler(rot.x, rot.y, amountToRotate);
    }
}
