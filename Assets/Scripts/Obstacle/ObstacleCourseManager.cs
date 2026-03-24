using System;
using UnityEngine;

public class ObstacleCourseManager : MonoBehaviour
{
    [SerializeField] Killbox killbox;
    [SerializeField] Checkpoint[] checkpoints;
    [SerializeField] Transform startingPos;

    Transform resetPoint; 


    private void Awake()
    {
        killbox.OnPlayerTouch += HandlePlayerDeath;
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.OnPassCheckpoint += (newResetPoint) => resetPoint = newResetPoint;
        }
    }
    private void Start()
    {
        resetPoint = startingPos;
    }

    private void HandlePlayerDeath(GameObject player)
    {
        player.transform.position = resetPoint.position;
    }
}
