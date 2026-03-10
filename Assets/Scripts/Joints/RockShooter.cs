using UnityEngine;

public class RockShooter : MonoBehaviour
{
    Camera Cam;
    public float Force;
    public ConstantForce prefab;
    
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(Force);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot(Force * 2);
        }
    }

    void Shoot(float force)
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        ConstantForce i = Instantiate(prefab, transform.position, Quaternion.identity);
        i.force = ray.direction * force;
    }
}
