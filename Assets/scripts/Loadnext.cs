using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadnext : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Loaded scene 1");
    }
    void OnClick()
    {
        Debug.Log("Clicked!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
