using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIProfile : MonoBehaviour
{
    public float viewDistance;
    public float waitForTurn;
    public Transform player; // Objeto que actúa como el jugador (para simular la detección)

    protected bool playerDetected;

    public abstract void ExecuteProfile();
    public abstract void OnPlayerDetected();
    public abstract void DetectPlayer();
}
