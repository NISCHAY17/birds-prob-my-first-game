using UnityEngine;
using TMPro;

public class SimpleTimeDisplay : MonoBehaviour
{
    public TMP_Text uiText;

    void Start()
    {
        float t = SimpleTimer.Instance.timeElapsed;
        uiText.text = t.ToString("F2") + "s";  
    }
}

