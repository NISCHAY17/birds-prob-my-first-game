using UnityEngine;
using UnityEngine.InputSystem;

public class PlsWork : MonoBehaviour
{
    void Start()
    {
        Debug.Log("plswork");
    }

    void Update()
    {
        
        Debug.Log("Loop works?");

        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
            Debug.Log("q key pressed");
    }
}
