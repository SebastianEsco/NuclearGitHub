using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPiso : MonoBehaviour
{
    // Start is called before the first frame update

    public float puntoDeDestruccion;
    Piso piso;
    private GameObject player;
    void Start()
    {
        ReferenciarJugador(); // la etiqueta cambia dependiendo del personaje, ¿ como puedo hacer para cambiarla automaticamente?
        piso = player.GetComponent<Piso>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ReferenciarJugador();
        transform.position = new Vector3(transform.position.x - piso.velocidad * Time.deltaTime, 0f, 0f);

        if(transform.position.x <= puntoDeDestruccion)
        {
            Destroy(gameObject);
        }
    }

    public void ReferenciarJugador()
    {
        if(GameObject.Find("Jugador") != null)
        {
            player = GameObject.Find("Jugador");
        }
        else if (GameObject.Find("MonoAraña") != null)
        {
            player = GameObject.Find("MonoAraña");
        }
        else if (GameObject.Find("Pajaro") != null)
        {
            player = GameObject.Find("Pajaro");
        }
        else
        {
            Debug.Log("No se encontró al jugador en la escena");
        }
    }
}
