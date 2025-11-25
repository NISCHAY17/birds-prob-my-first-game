using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float DestroyImpactMagnitude = 10f;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Bird!");
            Destroy(gameObject);
        }
        
        if (collision.relativeVelocity.magnitude > DestroyImpactMagnitude)
        {
            Debug.Log("Enemy hit with significant force!");
            Destroy(gameObject);
        }
    }
}



