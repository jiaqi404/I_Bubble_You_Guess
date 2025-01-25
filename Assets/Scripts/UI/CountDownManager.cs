using TMPro;
using UnityEngine;

public class countdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject endingPanel;
    public SettingsManager settingsManager;

    int countdown;
    float counter;
    int counterRevert;

    void Start()
    {
        countdown = settingsManager.countdown;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > countdown)
        {
            GameEnd();
        }
        else
        {
            counter += Time.deltaTime;
            counterRevert = (int)(countdown - counter + 1);
            countdownText.text = counterRevert.ToString();
        }
    }

    void GameEnd()
    {
        endingPanel.SetActive(true);
    }
}
