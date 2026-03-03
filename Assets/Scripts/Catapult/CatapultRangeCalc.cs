using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatapultRangeCalc : MonoBehaviour
{
    [Header("Reference")]
    public Rigidbody Sphere;

    [Header("Debug")]
    InputAction _Calc;

    private void Awake()
    {
        _Calc = InputSystem.actions.FindAction("Jump");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Calc.WasPressedThisFrame())
        {
            float predictedRange = CalculateExpectedRange(
                Sphere.linearVelocity,
                Sphere.transform.position.y
            );

            Debug.Log($"Predicted Range: {predictedRange.ToString("F2")}");
        }
    }

    public float CalculateExpectedRange(Vector3 launchVel, float initialHeight)
    {
        float g = Mathf.Abs(Physics.gravity.y); // Gravity 
        // Horizontal velocity components
        float vx = launchVel.x; 
        float vz = launchVel.z;
        

        float horizontalSpeed = new Vector2(vx, vz).magnitude;
        float vy = launchVel.y; // Initial vertical velocity
        float discriminant = (vy * vy) + (2 * g * initialHeight); // Discriminant for the quadratic formula to find time of flight

        if (discriminant < 0)
        {
            // No real solution, projectile won't reach the ground
            return 0f;
        }
        
        float timeToFall = (vy + Mathf.Sqrt(discriminant)) / g; // Time to fall from the peak to the ground
        float range = horizontalSpeed * timeToFall; // Range = horizontal speed * time of flight

        return range;
    }
}
