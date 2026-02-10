using UnityEngine;

public class PhysicsOverlapExample : MonoBehaviour
{

    public float radius = 5f, damage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("enemy"))
            {
                MeshRenderer mesh = hit.GetComponent<MeshRenderer>();
                mesh.material.color = Color.red;

                float dis = Vector3.Distance(hit.transform.position, transform.position);
                Debug.Log("object" + hit.name + "is " + dis+ "away");
            }
            
        }

        Destroy(gameObject, 0.5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }
}
