using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaPingPong : AIProfile
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private int direction = 1; // 1 para avanzar, -1 para retroceder

    public override void ExecuteProfile()
    {
        // Moverse hacia el siguiente punto de patrulla
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex += direction;

            if (currentWaypointIndex >= waypoints.Length || currentWaypointIndex < 0)
            {
                // Cambiar de dirección
                direction *= -1;
                currentWaypointIndex += direction;
            }
        }
    }

    public override void OnPlayerDetected()
    {
        Debug.Log("Player found");
    }

    public override void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= viewDistance)
        {
            playerDetected = true;
            OnPlayerDetected();
        }
        else
        {
            playerDetected = false;
        }
    }
}
