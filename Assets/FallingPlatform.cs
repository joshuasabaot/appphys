using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    float dropTime = .75f;
    bool isDropping = false;
    float resetTime = 2f;
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDropping = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        if (rb.isKinematic) return;
    }

    private void Update()
    {
        if (isDropping) HandleDrop();
        

    }

    private void HandleDrop()
    {
        dropTime -= Time.deltaTime;
        if (dropTime <= 0)
        {
            rb.isKinematic = false;
            isDropping = false;
        }
    }
}
