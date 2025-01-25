using TMPro;
using UnityEngine;

public class PromptPanelManager : MonoBehaviour
{
    public float duration;
    public TextMeshProUGUI counterText;
    float counter;
    int counterRevert;

    void Update()
    {
        counter += Time.deltaTime;
        counterRevert = (int)(duration - counter) + 1;
        counterText.text = counterRevert.ToString();
        if (counter > duration)
        {
            gameObject.SetActive(false);
        }
    }
}
