using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endscreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadNextZEROScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Loaded scene 0");
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
