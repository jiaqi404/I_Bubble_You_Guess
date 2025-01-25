using TMPro;
using UnityEngine;

public class PromptPanelManager : MonoBehaviour
{
    public float panelExistDuration;
    public TextMeshProUGUI counterText;
    public GameObject countDownPanel;
    public TextMeshProUGUI countDownInfoText;
    int countDown;
    float counter;
    int counterRevert;

    private void Start()
    {
        
    }

    void Update()
    {
        counter += Time.deltaTime;
        counterRevert = (int)(panelExistDuration - counter + 1);
        counterText.text = counterRevert.ToString();
        if (counter > panelExistDuration)
        {
            gameObject.SetActive(false);
            countDownPanel.SetActive(true);
        }
    }
}
