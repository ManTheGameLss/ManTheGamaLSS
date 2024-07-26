using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class ScrollImage : MonoBehaviour
{
    private RawImage rawImage;
    public float scrollSpeed;
    private float x = 1;
    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(x, 0) * Time.deltaTime * scrollSpeed / 10, rawImage.uvRect.size);
    }
}
