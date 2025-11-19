using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [Header("Movimiento")]
    private float movimientoX;
    public float velocidad = 2;
    private Rigidbody2D rb2d;

    [Header("************ Salto ************")]
    public float fuerzaSalto = 2;

    [Header("******* CompruebaSuelo *******")]
    private bool estaEnSuelo = false;
    public LayerMask layerSuelo;
    private float radioEsferaTocaSuelo = 0.1f;
    public Transform compruebaSuelo;

     [Header("******** Sonido ********")]
    public AudioSource audioSource;
    public AudioClip clipMoneda;

     [Header("******* Animaciones *******")]
    private Animator animator;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        rb2d.linearVelocity = new Vector2(movimientoX * velocidad, rb2d.linearVelocity.y);
        animator.SetBool("estaCorriendo", movimientoX != 0);

    
    }


    void FixedUpdate()
    {
        estaEnSuelo = Physics2D.OverlapCircle(compruebaSuelo.position, radioEsferaTocaSuelo, layerSuelo);
    }

    private void OnMove(InputValue inputMovimiento)
    {
        movimientoX = inputMovimiento.Get<Vector2>().x;

        if (movimientoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX), 1, 1);
            animator.SetBool("estaCorriendo", true);
        }
    }

    private void OnJump(InputValue inputSalto)
    {
        if (estaEnSuelo)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);
        
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Moneda"))
        {
            FindObjectOfType<GameManager>().SumarPuntos();
            audioSource.PlayOneShot(clipMoneda);
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Enemigo") || collision.transform.CompareTag("SueloMuerte"))
        {
            FindObjectOfType<GameManager>().QuitarVida();
        }

        if (collision.transform.CompareTag("Castillo"))
        {
            SceneManager.LoadScene(2);
        }
    }
    
}

