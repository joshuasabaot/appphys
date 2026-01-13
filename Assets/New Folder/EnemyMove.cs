using System.Data;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 roam1, roam2, target;
    public int health = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roam1 = transform.position + (Vector3.left * 2);
        roam2 = transform.position + (Vector3.right * 2);
        target = roam1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 2f*Time.deltaTime);
        if (Vector3.Distance(transform.position, target) <= 0.1)
        {
            if (target == roam1)
            {
                target = roam2;
            }
            else
            {
                target = roam1;
            }
        }
    }
}
