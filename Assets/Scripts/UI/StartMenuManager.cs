using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Button startBtn;
    public Button exitBtn;
    public Button producerBtn;
    public GameObject startMenu;
    public GameObject producerPanel;
    public GameObject promptPanel;
    public GameObject countDownPanel;
    public GameObject endingPanel;

    BubbleSpawnPC bubbleSpawnPC;
    CameraPCController cameraPCController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startBtn.onClick.AddListener(GameStart);
        exitBtn.onClick.AddListener(GameExit);
        producerBtn.onClick.AddListener(Producers);

        startMenu.SetActive(true);
        producerPanel.SetActive(false);
        promptPanel.SetActive(false);
        countDownPanel.SetActive(false);
        endingPanel.SetActive(false);

        bubbleSpawnPC = FindFirstObjectByType<BubbleSpawnPC>();
        bubbleSpawnPC.enabled = false;

        cameraPCController = FindFirstObjectByType<CameraPCController>();
        cameraPCController.enabled = false;
    }

    void GameStart()
    {
        startMenu.SetActive(false);
        promptPanel.SetActive(true);

        bubbleSpawnPC.enabled = true;
        cameraPCController.enabled = true;
    }

    void GameExit()
    {
        Application.Quit();
        Debug.Log("Game Exit!");
    }

    void Producers()
    {
        startMenu.SetActive(false);
        producerPanel.SetActive(true);
    }
}
