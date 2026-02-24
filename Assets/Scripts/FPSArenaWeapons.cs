using UnityEngine;
using UnityEngine.InputSystem;

public class FPSArenaWeapons : MonoBehaviour
{
    public float radius = 5f;
    Transform playerCamera;
    InputAction Attack;
    InputAction Grenade;



    void Awake()
    {
        playerCamera = Camera.main.transform;
        Attack = InputSystem.actions.FindAction("Attack");
        Grenade = InputSystem.actions.FindAction("Grenade");
        
    }

    private void OnEnable()
    {
        Attack.performed += Shoot;
        Grenade.performed += FireGrenade;
    }


    void Update()
    {

    }

    void Shoot(InputAction.CallbackContext ctx)
    {
        Debug.Log("BANG");
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 50))
        {
            var b = hit.collider.GetComponentInParent<RagdollOnClick>();
            if (b)
            {
                Debug.Log("hit");
                b.Ragdoll();
            }
        }
    }

    void FireGrenade(InputAction.CallbackContext ctx)
    {
        Debug.Log("Grenade");
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 50))
        {
            GrenadeExplosion(hit.point);

        }
    }

    void GrenadeExplosion(Vector3 pos)
    {
        Collider[] hits = Physics.OverlapSphere(pos, radius);


        foreach (Collider hit in hits)
        {
            var b = hit.GetComponentInParent<RagdollOnClick>();
            if (b)
            {
                Debug.Log("hit");
                b.Ragdoll();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward);
    }
}
