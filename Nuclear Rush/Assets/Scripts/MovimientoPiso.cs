using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPiso : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float tiempoDeDestruccion;
    public float puntoFinal;
    Piso piso;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Jugador");
        piso = player.GetComponent<Piso>();
        Destroy(gameObject, tiempoDeDestruccion);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - piso.velocidad * Time.deltaTime, 0f, 0f);
    }
}
