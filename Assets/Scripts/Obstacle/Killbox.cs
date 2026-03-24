using System;
using UnityEditor.Build.Content;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public event Action<GameObject> OnPlayerTouch;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched the killbox!");
            OnPlayerTouch?.Invoke(other.gameObject);
        }
    }

}
