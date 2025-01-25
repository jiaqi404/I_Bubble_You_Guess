using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public string[] prompts;
    public int countdown;
    int randomIndex;
    public string prompt;

    void Start()
    {
        prompt = GetOnePrompt();
    }

    string GetOnePrompt()
    {
        randomIndex = Random.Range(0, prompts.Length);
        return prompts[randomIndex];
    }
}
