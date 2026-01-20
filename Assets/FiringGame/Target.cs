using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    MeshRenderer Mesh;
    Collider Collider;

    private void Start()
    {
        Mesh = GetComponent<MeshRenderer>();
        Collider = GetComponent<Collider>();
    }
    public void Hit()
    {
        StartCoroutine(HitCouroutine());
    }
    IEnumerator HitCouroutine()
    {
        Mesh.enabled = false;
        Collider.enabled = false;
        yield return new WaitForSeconds(1);

        Mesh.enabled = true;
        Collider.enabled = true;
    }
}
