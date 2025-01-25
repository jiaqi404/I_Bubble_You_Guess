using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelManager : MonoBehaviour
{
    public Button continueBtn;
    public Button returnBtn;

    BubbleSpawnPC bubbleSpawnPC;
    CameraPCController cameraPCController;
    CountdownManager countdownManager;

    void OnEnable()
    {
        continueBtn.onClick.AddListener(ContinuePlaying);
        returnBtn.onClick.AddListener(ReturnToMenu);

        bubbleSpawnPC = FindFirstObjectByType<BubbleSpawnPC>();
        bubbleSpawnPC.enabled = false;

        cameraPCController = FindFirstObjectByType<CameraPCController>();
        cameraPCController.enabled = false;

        countdownManager = FindFirstObjectByType<CountdownManager>();
        countdownManager.isPaused = true;
    }

    void ContinuePlaying()
    {
        gameObject.SetActive(false);
        bubbleSpawnPC.enabled = true;
        cameraPCController.enabled = true;

        countdownManager.isPaused = false;
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
