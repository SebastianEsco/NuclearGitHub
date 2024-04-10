using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    GestionadorDePlataformas gestionador;
    private GameObject gestionadorObjeto;
    GameObject plataforma;

    private bool instanciado;

    public void Update()
    {
        
    }

    public void Start()
    {
        gestionadorObjeto = GameObject.Find("ControladorPlataformas");
        gestionador = gestionadorObjeto.GetComponent<GestionadorDePlataformas>();

    }

    public void FixedUpdate()
    {
        if(transform.position.x < 17 && !instanciado)
        {
            Debug.Log("------ Nueva Plataforma -------");
            plataforma = gestionador.EscogerPlataforma();
            Instantiate(plataforma, transform.position, Quaternion.identity);
            instanciado = true;
        }
    }



}
