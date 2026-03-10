using UnityEngine;

public class CatapultRelease : MonoBehaviour
{
    [SerializeField] Rigidbody Sphere;
    [SerializeField] float ReleaseAngle = 225f;
    [SerializeField] float currentAngle = 0f;

    private SpringJoint _springJoint;
    private HingeJoint _hingeJoint;

    private void Start()
    {
        _springJoint = Sphere.GetComponent<SpringJoint>();
        _hingeJoint = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        currentAngle = _hingeJoint.angle;

        if (_springJoint != null && currentAngle >= ReleaseAngle)
        {
            Destroy(_springJoint);
        }
    }
}
