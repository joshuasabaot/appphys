using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public event Action<Transform> OnPassCheckpoint;
    [SerializeField] Transform resetPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player reached the checkpoint!");
            OnPassCheckpoint?.Invoke(resetPoint);
        }

    }
}
