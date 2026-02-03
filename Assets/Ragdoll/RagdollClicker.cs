using UnityEngine;

public class RagdollClicker : MonoBehaviour
{
    public Camera Cam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Hit();
        }
    }
    // Update is called once per frame
    void Hit()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 50))
        {
            var b = hit.collider.GetComponentInParent<RagdollOnClick>();
            Debug.Log("hit");

            if (b)
            {
                b.Ragdoll();
            }
        }
    }
}
