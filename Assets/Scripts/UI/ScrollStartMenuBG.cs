using UnityEngine;
using UnityEngine.UI;

public class ScrollStartMenuBG : MonoBehaviour
{
    RawImage rawImage;
    public Vector2 speed;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + speed * Time.deltaTime, rawImage.uvRect.size);
    }
}
