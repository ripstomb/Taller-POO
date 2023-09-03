using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIProfile : MonoBehaviour
{
    public float viewDistance = 3.0f;
    public float waitForTurn;
    public Transform player; // Objeto que act�a como el jugador (para simular la detecci�n)

    protected bool playerDetected;

    public abstract void ExecuteProfile();
    public abstract void OnPlayerDetected();
    public abstract void DetectPlayer();
}
