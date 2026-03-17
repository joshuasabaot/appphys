using System;
using UnityEngine;

public class DotProductExample : MonoBehaviour
{
    public Transform player;
    public float fieldOfViewAngle = 45f;
    public float GizmoLineLength = 10f;

    void Update()
    {
        PlayerInFrontCheck();
        CheckFieldOfView();
    }

    private void PlayerInFrontCheck()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(transform.forward, toPlayer);

        if (dotProduct >= 0)
        {
            Debug.Log("Player is in front of the object.");
        }
        else
        {
            Debug.Log("Player is behind the object.");
        }
        HitFromFront(toPlayer);
    }

    void CheckFieldOfView()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toPlayer);
        
        float threshold = Mathf.Cos(fieldOfViewAngle * Mathf.Deg2Rad);

        if (dot > threshold)
        {
            Debug.Log("Player is within the field of view.");
        }
        else
        {
            Debug.Log("Player is outside the field of view.");
        }
    }

    bool HitFromFront(Vector3 hitDirection)
    {
        hitDirection.Normalize();
        float dot = Vector3.Dot(transform.forward, hitDirection);
        return dot > 0;
    }

    private void OnDrawGizmos()
    {
        if (player == null) return;
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * GizmoLineLength);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, player.position);

        Gizmos.color = Color.yellow;
        Quaternion leftRot = Quaternion.Euler(0, -fieldOfViewAngle, 0);
        Quaternion rightRot = Quaternion.Euler(0, fieldOfViewAngle, 0);

        Gizmos.DrawLine(transform.position, transform.position + leftRot * transform.forward * GizmoLineLength);
        Gizmos.DrawLine(transform.position, transform.position + rightRot * transform.forward * GizmoLineLength);

    }
}
