using TMPro;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    public int countDown;
    public TextMeshProUGUI countDownText;
    float counter;
    int counterRevert;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        counterRevert = (int)(countDown - counter + 1);
        countDownText.text = counterRevert.ToString();
    }
}
