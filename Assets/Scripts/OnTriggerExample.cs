using UnityEngine;

public class OnTriggerExample : MonoBehaviour
{
    public float damage = 50.0f;
    public MeshRenderer enemyMesh;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SphereCollider sc = gameObject.AddComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = 5f;

        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemy")) 
        {
            enemyMesh = other.GetComponent<MeshRenderer>();
            enemyMesh.material.color = Color.red;
            Debug.Log("Enemy Hit");
        }
        
    }
    
}
