using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoPuntos;
    private int puntos = 0;
    private int vida;
    public TMP_Text textoVidaValor;
    public Jugador jugador;       
    public GameObject puntoInicial;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntos = 0;
        textoPuntos.text = "0";

        vida = 2;
        textoVidaValor.text = vida.ToString();
    }

    public void SumarPuntos()
    {
        puntos++;
        textoPuntos.text = puntos.ToString();
    }

     public void QuitarVida()
    {
        vida--;
        textoVidaValor.text = vida.ToString();
        /*jugador.characterController.enabled = false; 
        jugador.transform.position = puntoInicial.transform.position;
        jugador.characterController.enabled = true;*/

        if (vida <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}
