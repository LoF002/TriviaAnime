using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//da acceso a interfaces de usuario
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Dificultad[] bancoDePreguntas;
    public Text enunciado;
    public Text[] respuesta;
    public int nivelPregunta;
    public int preguntaAlAzar;

    // Start is called before the first frame update
    void Start()
    {
        nivelPregunta = 0;
        SeleccionarPregunta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Este metodo recibe la respuesta seleccionada por el jugador
    /// </summary>
    /// <param name="respuestaSeleccionada"></param>
    public void Respuesta(int respuestaSeleccionada)
    {
        Debug.Log("Ha seleccionado la opcion" + respuestaSeleccionada.ToString());
        EvaluarPregunta(respuestaSeleccionada);
    }//Fin metodo

    public void SeleccionarPregunta()
    {
        //se elige un indice del arreglo al azar
        preguntaAlAzar = Random.Range(0, bancoDePreguntas[nivelPregunta].preguntas.Length);

        //asigna text del banco de preguntas en la interfaz del enunciado
        enunciado.text = bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].enunciado;

        //carga texto de cada respuesta
        for(int i = 0; i < respuesta.Length; i++)
        {
            respuesta[i].text = bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestas[i].texto;
        }//Fin for

    }//Fin metodo

    public bool EvaluarPregunta(int respuestaJugador)
    {
        if(respuestaJugador == bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestaCorrecta)
        {
            //reinicio del problema con mayor dificultad
            nivelPregunta++;
            
            if(nivelPregunta == bancoDePreguntas.Length)
            {
                //desplegar pantalla de victoria
                SceneManager.LoadScene("Gane");
            }//Fin if
            else
            {
                //subir nivel
                SeleccionarPregunta();

            }//Fin else

            return true;
        }//Fin if
        else
        {
            SceneManager.LoadScene("Perder");
            return false;
        }//Fin else
    }//Fin metodo

}//Fin clase
