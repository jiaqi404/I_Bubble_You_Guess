using TMPro;
using UnityEngine;

public class EndingPanelManager : MonoBehaviour
{
    public SettingsManager settingsManager;
    public TextMeshProUGUI propmtRevealText;

    void Awake()
    {
        string prompt = settingsManager.prompt;
        propmtRevealText.text = "It's a " + prompt + "!";
    }
}
