using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class SimpleTimer : MonoBehaviour
{
    public static SimpleTimer Instance;

    public float timeElapsed = 0f;
    public bool running = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (running)
            timeElapsed += Time.deltaTime;
    }

    public void Stop()
    {
        running = false;
    }
}

