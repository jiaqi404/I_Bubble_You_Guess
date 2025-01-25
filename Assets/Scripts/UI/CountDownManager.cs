using TMPro;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    public GameObject endingPanel;
    public SettingsManager settingsManager;
    public bool isPaused = false;

    TextMeshProUGUI countdownText;
    int countdown;
    float counter;
    int counterRevert;

    void Start()
    {
        countdown = settingsManager.countdown;
        countdownText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            if (counter > countdown)
            {
                GameEnd();
            }
            else
            {
                counter += Time.deltaTime;
                counterRevert = (int)(countdown - counter + 1);
                if (counterRevert < 6)
                {
                    countdownText.text = "<color=red>" + counterRevert.ToString() + "</color>";
                }
                else
                {
                    countdownText.text = counterRevert.ToString();
                }
            }
        }
    }

    void GameEnd()
    {
        endingPanel.SetActive(true);
    }
}
