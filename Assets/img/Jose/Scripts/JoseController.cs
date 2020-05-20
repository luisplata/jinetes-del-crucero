using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoseController : MonoBehaviour {
    private float xMov, yMov;
    private Rigidbody2D rb;
    private Animator an;
    [SerializeField]
    private int speed = 5;
    private Vector2 jumpForce = new Vector2 (0, 350);
    private int cantidadDeSaltosPermitidos = 2;
    private SpriteRenderer spriteRenderer;
    private int saltosRealizados = 0;

    public Image vidaPlayer;
    private bool mover = true;
    private Transform golpe, patada;
    private bool isTocandoEscalera;

    public GameObject camaraNormal, camaraShake, dialogoSprite;
    public TextMeshProUGUI texto;

    //Parametros de Salud del jugador
    private float salud;
    //guardar datos en memoria con PlayerPrefs API
    //Guardar los controles en memoria

    private int danioDeGolpe;
    // Start is called before the first frame update
    void Start () {
        salud = 100;
        vidaPlayer.fillAmount = (salud / 100);
        golpe = transform.Find ("golpe");
        patada = transform.Find ("Patada");
        rb = GetComponent<Rigidbody2D> ();
        an = GetComponent<Animator> ();
        danioDeGolpe = 1;
        GetComponent<SpriteRenderer> ().flipX = true;
        GetComponent<SpriteRenderer> ().color = new Color (
            220, 220, 220
        );
        //rotamos el golpe, ya que al inicio comienza mirando a la derecha
        golpe.transform.rotation = Quaternion.Euler (golpe.rotation.x, 180, golpe.rotation.z);
        //igual para la patada
        patada.transform.rotation = Quaternion.Euler (golpe.rotation.x, 180, golpe.rotation.z);
    }

    // Update is called once per frame
    void Update () {
        //miramos que tecla preciona el jugador
        //WebRequest para conectar con servidor
        if (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Space)) {
            //salto
            /*if (saltosRealizados < cantidadDeSaltosPermitidos) {
                rb.AddForce (jumpForce);
                an.SetTrigger ("salto");
                an.SetBool ("piso", false);
            }
            saltosRealizados++;*/
        }
        Movimiento ();
    }
    private void Movimiento () {
        if (Input.GetKeyDown (KeyCode.Joystick1Button3) || Input.GetKeyDown (KeyCode.Z)) {
            an.SetTrigger ("golpeSuave");
        } else if (Input.GetKeyDown (KeyCode.Joystick1Button2) || Input.GetKeyDown (KeyCode.X)) {
            an.SetTrigger ("golpeDuro");
        }
        if (!mover) {
            return;
        }
        xMov = Input.GetAxis ("Horizontal") * speed;

        //movimiento en Y
        if (isTocandoEscalera) {
            yMov = xMov;
        } else {
            yMov = rb.velocity.y;
        }
        rb.velocity = new Vector2 (xMov, rb.velocity.y);
        an.SetFloat ("xmov", Mathf.Abs (xMov));
        //flipear el split y los objetos de golpes
        if (xMov != 0) {
            golpe.transform.rotation = Quaternion.Euler (golpe.rotation.x, xMov < 0 ? 0 : 180, golpe.rotation.z);
            patada.transform.rotation = Quaternion.Euler (golpe.rotation.x, xMov < 0 ? 0 : 180, golpe.rotation.z);
            GetComponent<SpriteRenderer> ().flipX = xMov > 0;
        }
    }

    public void QueNoSeMueva () {
        mover = false;
    }
    public void QueSeMueva () {
        mover = true;
    }
    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.name == "enemigo") {

        } else if (other.transform.CompareTag ("escalera")) {
            rb.gravityScale = 0;
            isTocandoEscalera = true;
            Debug.Log ("Toco la escalera escala es" + rb.gravityScale);
        }
    }

    private void OnCollisionExit2D (Collision2D other) {
        if (other.transform.CompareTag ("escalera")) {
            rb.gravityScale = 4;
            isTocandoEscalera = false;
            Debug.Log ("Se fue de la escalera escala es" + rb.gravityScale);
        }
    }

    public int GetGolpeSuave () {
        return this.danioDeGolpe * 5;
    }

    public int GetGolpeDuro () {
        return this.danioDeGolpe * 10;
    }

    public void RestarVida () {
        salud -= 10;
        Debug.Log ("Le pegaron " + salud);
        vidaPlayer.fillAmount = (salud / 100);
        if (salud <= 0) {
            StartCoroutine ("Morir");
            
            Debug.Log ("murio? " + salud);
        } else {
            an.SetTrigger ("fueGolpeado");
            Debug.Log ("le pegaron? " + salud);
        }
    }

    public void GameOver () {
        StartCoroutine ("MorirFade");
        GameObject.Find ("ControladorDelMundo").GetComponent<ControladorDelMundo> ().GameOver ();
        mover = false;
    }

    public void Restart () {
        Time.timeScale = 1;
    }

    IEnumerator Morir () {
        //Debug.Log ("corrutina");
        an.SetTrigger ("morir");
        yield return new WaitForSeconds (2);
        //debemos mandar el UI de Game Over
        Debug.Log ("Game Over");
        mover = false;
    }

    IEnumerator MorirFade () {
        float timeScale = Time.timeScale;
        Time.timeScale = 0;
        yield return new WaitForSeconds (0);
    }

    public void CamaraShakeEntrar () {
        StartCoroutine ("CamaraShake");
    }

    IEnumerator CamaraShake () {
        camaraNormal.SetActive (false);
        camaraShake.SetActive (true);
        yield return new WaitForSeconds (1);
        camaraNormal.SetActive (true);
        camaraShake.SetActive (false);
    }
    IEnumerator ActivacionDeDialogos () {
        texto.text = "jajajaja me dieron ganas de pelear! vamos a darle!";
        dialogoSprite.SetActive (true);
        //dialogoSprite.transform.position = new Vector3 (6, 6, 0);
        yield return new WaitForSeconds (4);
        dialogoSprite.SetActive (false);
    }

}