using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class endtime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            SimpleTimer.Instance.Stop();
        }
    }
}
