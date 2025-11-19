using UnityEngine;
using UnityEngine.SceneManagement;

public class Perder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Jugar() {
        SceneManager.LoadScene(0);  //Carga la escena del juego
    }

    public void Salir() {
        Debug.Log("Saliendo...");  //Mensaje en consola
        Application.Quit();        //Cierra el juego (solo funciona en build)
    }

}
