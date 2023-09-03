using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardia : AIProfile
{
    private float nextTurnTime;
    private Quaternion targetRotation;

    private void Update()
    {
        DetectPlayer();
        ExecuteProfile();
    }
    private void Start()
    {
        targetRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public override void ExecuteProfile()
    {
        if (Time.time >= nextTurnTime)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 30f);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 5f)
            {
                // Cambiar la dirección de giro
                targetRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                nextTurnTime = Time.time + waitForTurn;
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