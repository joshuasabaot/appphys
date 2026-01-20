using JetBrains.Annotations;
using System.Threading;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class FiringGameShooter : MonoBehaviour
{
    public float GameTimer = 120f;
    float _timer;

    public Camera Cam;
    public int PointCounter = 0;
    public LayerMask InteractableLayers;

    bool gameEnd = false;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < GameTimer)
        {
            Shoot();
        } else if (!gameEnd) 
        {
            gameEnd = true;
            //text.text = "Score:" + PointCounter;
        }
        
    }

    void Shoot()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 50, InteractableLayers))
        {
            
            if (hit.collider.CompareTag("Target") && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("hit");
                PointCounter += Mathf.RoundToInt(Vector3.Distance(ray.origin, hit.point));
                Target hitTarget = hit.collider.GetComponent<Target>();
                hitTarget.Hit();
            }
        }
    }
}
