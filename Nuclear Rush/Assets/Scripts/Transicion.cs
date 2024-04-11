using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion : MonoBehaviour
{
    private GameObject jugador;
    public string nombreScriptADesactivar;
    public string nombreScriptAActivar;

   
    private void OnTriggerEnter(Collider other)
    {
        jugador = GameObject.Find("MonoAraña");

        if (other.CompareTag("Player"))
        {
            // Buscar los scripts por nombre en el objeto del jugador
            MonoBehaviour scriptADesactivar = jugador.GetComponent(nombreScriptADesactivar) as MonoBehaviour;
            MonoBehaviour scriptAActivar = jugador.GetComponent(nombreScriptAActivar) as MonoBehaviour;

            if (scriptADesactivar != null && scriptAActivar != null)
            {
                // Desactivar el script actual del jugador
                scriptADesactivar.enabled = false;
                // Activar el nuevo script del jugador
                scriptAActivar.enabled = true;
            }
            else
            {
                Debug.LogError("Uno o ambos scripts no fueron encontrados en el jugador.");
            }
        }
    }
}
