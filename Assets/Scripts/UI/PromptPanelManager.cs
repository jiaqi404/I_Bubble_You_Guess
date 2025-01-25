using TMPro;
using UnityEngine;

public class PromptPanelManager : MonoBehaviour
{
    public float panelExistDuration;
    public GameObject countDownPanel;
    public TextMeshProUGUI promtText;
    public TextMeshProUGUI countDownInfoText;
    public TextMeshProUGUI counterText;
    public SettingsManager settingsManager;

    float counter;
    int counterRevert;

    void Start()
    {
        string prompt = settingsManager.prompt;
        promtText.text = prompt;
        int countdown = settingsManager.countdown;
        countDownInfoText.text = "In " + countdown + " seconds!";
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
