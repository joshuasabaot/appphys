using UnityEngine;

public class TowerDetection : MonoBehaviour
{
    bool hasTarget = false;
    public float radius = 5f, damage = 10f, cooldown = 3f, cdtimer = 3f, AttackCooldown=0.5f, Attackcdtimer=0f;
    public Collider target;
    public EnemyMove targethealth;


    void Start()
    {
    }

    private void Update()
    {
        if (!hasTarget)
        {
            cdtimer += Time.deltaTime;
            if (cdtimer > cooldown)
            {
                cdtimer = 0;
                var newtarget = CheckForTarget();
                if (newtarget != null) 
                { 
                    hasTarget = true;
                    target = newtarget;
                    MeshRenderer targetmesh = target.GetComponent<MeshRenderer>();
                    targetmesh.material.color = Color.red;
                    targethealth = target.GetComponent<EnemyMove>();
                } else 
                { 
                    cdtimer = cooldown-1f; 
                }
            }
        }
        else
        {
            var dis = Vector3.Distance(target.transform.position, transform.position);
            if (dis > radius)
            {

                MeshRenderer targetmesh = target.GetComponent<MeshRenderer>();
                targetmesh.material.color = Color.grey;
                target = null;
                targethealth = null;
                hasTarget = false;
            }
            else
            {
                Attackcdtimer += Time.deltaTime;
                if (Attackcdtimer > AttackCooldown)
                {
                    Attackcdtimer = 0f;
                    targethealth.health -= 25;
                    if (targethealth.health <= 0)
                    {
                        Destroy(target.gameObject);
                        hasTarget = false;
                    }

                }
            }

        }

    
        

    }

    Collider CheckForTarget()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        Collider newtarget = null;
        float targetdis=99f;
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("enemy"))
            {
                var hitdis = Vector3.Distance(hit.transform.position, transform.position);
                if (newtarget) 
                {
                    if (hitdis < targetdis) {
                        newtarget = hit;
                        targetdis = hitdis;
                    }
                } else {
                    newtarget = hit;
                    targetdis = hitdis;
                }
            }
        }

        return newtarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
