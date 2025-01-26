using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Button startBtn;
    public Button exitBtn;
    public Button creditBtn;
    public GameObject startMenu;
    public GameObject creditPanel;
    public GameObject promptPanel;
    public GameObject countDownPanel;
    public GameObject endingPanel;
    public GameObject pausePanel;
    public GameObject startMenuBG;

    BubbleSpawnPC bubbleSpawnPC;
    CameraPCController cameraPCController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startBtn.onClick.AddListener(GameStart);
        exitBtn.onClick.AddListener(GameExit);
        creditBtn.onClick.AddListener(ShowCredits);

        startMenu.SetActive(true);
        startMenuBG.SetActive(true);
        creditPanel.SetActive(false);
        promptPanel.SetActive(false);
        countDownPanel.SetActive(false);
        endingPanel.SetActive(false);
        pausePanel.SetActive(false);

        bubbleSpawnPC = FindFirstObjectByType<BubbleSpawnPC>();
        bubbleSpawnPC.enabled = false;

        cameraPCController = FindFirstObjectByType<CameraPCController>();
        cameraPCController.enabled = false;
    }

    void GameStart()
    {
        startMenu.SetActive(false);
        startMenuBG.SetActive(false);
        promptPanel.SetActive(true);

        bubbleSpawnPC.enabled = true;
        cameraPCController.enabled = true;
    }

    void GameExit()
    {
        Application.Quit();
        Debug.Log("Game Exit!");
    }

    void ShowCredits()
    {
        startMenu.SetActive(false);
        creditPanel.SetActive(true);
    }
}
