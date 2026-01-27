using UnityEngine;

public class VegetationPlacer : MonoBehaviour
{
    public GameObject Prefab;
    public Camera Cam;

    private void Start()
    {
        if (!Cam)
        {
            Cam = Camera.main;
        }
    }

    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit rayHit,50))
        {
            
            if (rayHit.collider.CompareTag("Target") && Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Debug.Log("hitting terrain");
                Collider[] hits = Physics.OverlapSphere(rayHit.point, 0.7071f);
                bool canPlace = true;
                foreach (Collider hit in hits)
                {
                    if (hit.CompareTag("Plant"))
                    {
                        canPlace = false;
                        break;
                    }

                }
                if (canPlace)
                {
                    Instantiate(Prefab, rayHit.point, Quaternion.identity);
                }
            }
            //objecttoplace.position = hit.point;
            //objecttoplace.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }
}
