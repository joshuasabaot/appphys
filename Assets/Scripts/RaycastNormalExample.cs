using UnityEngine;

public class RaycastNormalExample : MonoBehaviour
{
    public Transform objecttoplace;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            objecttoplace.position = hit.point;
            objecttoplace.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }
}
