using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour
{
    public float velocidadMovimiento = 3.0f;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0) * velocidadMovimiento * Time.deltaTime;

        transform.Translate(movimiento);
    }
}
