using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField]
    WaveConfigSO waveConfig;

    List<Transform> waypoints;
    int waypointsIndex = 0;
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointsIndex].position;

    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointsIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointsIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if(transform.position == targetPosition)
            {
                waypointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
