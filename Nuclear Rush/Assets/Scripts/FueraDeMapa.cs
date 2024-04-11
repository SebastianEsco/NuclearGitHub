using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FueraDeMapa : MonoBehaviour
{
    PlayerController controller;
    GameObject jugador;
    void Start()
    {
        jugador = GameObject.Find("Jugador");
        controller = jugador.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOCO EL TRIGGER GAMEOVER");
        if (other.CompareTag("GameOver"))
        {
            controller.vivo = false;
        }
    }
}
