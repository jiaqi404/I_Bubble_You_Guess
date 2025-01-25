using UnityEngine;

public class PromptPanelManager : MonoBehaviour
{
    public float duration;
    float counter;

    void Update()
    {
        counter += Time.deltaTime;
        if (counter > duration)
        {
            gameObject.SetActive(false);
        }
    }
}
