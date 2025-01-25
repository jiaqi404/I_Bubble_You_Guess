using UnityEngine;
using UnityEngine.UI;

public class ProducerPanelManager : MonoBehaviour
{
    public Button closeBtn;
    public GameObject startMenu;
    public GameObject creditPanelPlus;
    void Start()
    {
        closeBtn.onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        creditPanelPlus.SetActive(false);
        startMenu.SetActive(true);
    }
}
