using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    private bool _IsGameOver;
    [SerializeField] private GameObject GameOverUI;
    public RagdollOnClick prefab;
    public float spawnwidthlength = 10;
    List<RagdollOnClick> spawnedTargets = new List<RagdollOnClick>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            
            Vector3 spawnpos = new Vector3(Random.Range(-spawnwidthlength, spawnwidthlength), transform.position.y, Random.Range(-spawnwidthlength, spawnwidthlength));
            Debug.Log("Spawning target " + (i + 1) + " at " + spawnpos + (spawnpos+Vector3.down));
            Ray ray = new Ray(spawnpos, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Debug.Log("Hit ground at " + hit.point);
                var j = Instantiate(prefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

                spawnedTargets.Add(j);
            }
        }
    }

    private void Update()
    {
        int counter = 0;
        foreach (var target in spawnedTargets)
        {
            if (target.ragdolled)
            {
                counter++;
            }
        }

        if (counter == spawnedTargets.Count &&  !_IsGameOver)
        {
            _IsGameOver =  true;
            Debug.Log("All targets down, respawning...");
            GameOverUI.SetActive(true);
        }
    }
}
