using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] private GameObject[] plataforma1 = new GameObject[4];
    [SerializeField] private GameObject[] plataforma2 = new GameObject[4];
    [SerializeField] private GameObject[] plataforma3 = new GameObject[4];
    [SerializeField] private int PuntoInicial, modulosPreTransformacion;
    int contadorDeModulosPasados;
    int aleatorio, numeroModulos, moduloActual;

    void Start()
    {
        numeroModulos = plataforma1.Length;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            contadorDeModulosPasados++;
            Debug.Log("Colicion");
            Debug.Log(contadorDeModulosPasados);

            if(moduloActual == 0)
            {
                Instantiate(plataforma1[aleatorio], new Vector3(PuntoInicial, 0, 0), Quaternion.identity);
            }
            if (moduloActual == 1)
            {
                Instantiate(plataforma2[aleatorio], new Vector3(PuntoInicial, 0, 0), Quaternion.identity);
            }
            //if (moduloActual == 2)
            {
                //Instantiate(plataforma3[aleatorio], new Vector3(PuntoInicial, 0, 0), Quaternion.identity);
            }
            
            aleatorio = Random.Range(0, numeroModulos);
            if(contadorDeModulosPasados == modulosPreTransformacion)
            {
                contadorDeModulosPasados = 0;
                moduloActual++;
            }
        }
    }
}
