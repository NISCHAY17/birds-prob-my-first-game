using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required to talk to Buttons

public class load : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Loaded START scene");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Loaded scene 1");
    }
    
}