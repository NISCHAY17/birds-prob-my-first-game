using UnityEngine;

public class Enemy : MonoBehaviour
{
    void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player!");
            // Add logic for what happens when the enemy collides with the player
        }
    }
}

