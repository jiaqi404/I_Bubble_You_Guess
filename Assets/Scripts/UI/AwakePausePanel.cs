using UnityEngine;

public class AwakePausePanel : MonoBehaviour
{
    public GameObject pausePanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
        }
    }
}
