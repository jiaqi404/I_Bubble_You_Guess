using UnityEngine;
using UnityEngine.UI;

public class ProducerPanelManager : MonoBehaviour
{
    public Button closeBtn;
    public GameObject startMenu;
    void Start()
    {
        closeBtn.onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        gameObject.SetActive(false);
        startMenu.SetActive(true);
    }
}
