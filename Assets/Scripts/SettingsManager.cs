using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    GameObject postProcessing;
    void Awake()
    {
        postProcessing = GameObject.Find("Post Processing");
    }

    public void SetFastGraphics()
    {
        postProcessing.SetActive(false);
    }

    public void SetBeautifulGraphics()
    {
        postProcessing.SetActive(true);
    }

}
