using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingPanelManager : MonoBehaviour
{
    public SettingsManager settingsManager;
    public TextMeshProUGUI propmtRevealText;
    public Button restartBtn;

    void Awake()
    {
        restartBtn.onClick.AddListener(restartGame);
        string prompt = settingsManager.prompt;
        Debug.Log(prompt);
        propmtRevealText.text = "It's a " + prompt + "!";
    }

    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
