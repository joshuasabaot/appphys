using UnityEngine;

public class CatapultRelease : MonoBehaviour
{
    [SerializeField] Rigidbody Sphere;
    [SerializeField] float ReleaseAngle = 225f;
    [SerializeField] float currentAngle = 0f;

    private SpringJoint springJoint;
    private HingeJoint hingeJoint;

    private void Start()
    {
        springJoint = Sphere.GetComponent<SpringJoint>();
        hingeJoint = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        currentAngle = hingeJoint.angle;

        if (springJoint != null && currentAngle >= ReleaseAngle)
        {
            Destroy(springJoint);
        }
    }
}
