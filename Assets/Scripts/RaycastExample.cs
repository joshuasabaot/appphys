using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    float dis = 50;
    public LayerMask mask;
    public QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, dis, mask, triggerInteraction))
        {
            MeshRenderer mesh = hit.transform.GetComponent<MeshRenderer>();
            if (mesh)
            {
                mesh.material.color = Color.blue;
            }
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin+ ray.direction * dis, Color.yellow);
        }
    }
}
