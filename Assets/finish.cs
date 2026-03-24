using Unity.VisualScripting;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GameObject UI;
    bool isUIActive => UI.activeSelf;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player reached the finish line!");
            if (!isUIActive)
            {
                UI.SetActive(true);
            }
        }
    }
}
