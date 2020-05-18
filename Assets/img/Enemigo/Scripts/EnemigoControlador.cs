using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemigoControlador : MonoBehaviour, InterfaceParaCosaGolpeable {
    //cambio de colo
    private SpriteRenderer sp;
    private GameObject target;
    public GameObject sangre, golpe;
    private float xMov, yMov;
    private Rigidbody2D rb;
    protected Animator an;
    private float speed;
    private float tiempoParaBuscarlo = 0;
    private bool izquierda, derecha, arriba, abajo = false;
    private bool morir;
    private float salud = 10f;
    ControladorDelMundo controladorDeMundo;

    private bool golpear = false;
    [SerializeField]
    protected bool VaHacerAlgo = true;

    public TextMeshProUGUI contadorMostrador;

    public int oleadaPerteneciente;

    List<Color> listaDeColores = new List<Color> ();
    // Start is called before the first frame update
    void Start () {
        controladorDeMundo = GameObject.Find ("ControladorDelMundo").GetComponent<ControladorDelMundo> ();
        LlenarColores ();
        sp = GetComponent<SpriteRenderer> ();
        sp.color = ColorRandom ();
        target = GameObject.Find ("Jose");
        rb = GetComponent<Rigidbody2D> ();
        an = GetComponent<Animator> ();
        speed = 2.5f;
    }

    // Update is called once per frame
    void Update () {
        tiempoParaBuscarlo += Time.deltaTime;
        if (tiempoParaBuscarlo >= 1) {
            tiempoParaBuscarlo = 0;
            BuscaObjetivo ();
        }
        if (morir) {
            derecha = false;
            izquierda = false;
            arriba = false;
            abajo = false;
            return;
        }
        Caminar (1, false, false);
    }

    private Color ColorRandom () {
        int random = Random.Range (0, this.listaDeColores.Count);
        return this.listaDeColores[random];
    }
    private void BuscaObjetivo () {
        Vector3 resultante = target.transform.position - transform.position;
        if (resultante.x > 0) {
            derecha = false;
            izquierda = true;
            arriba = false;
            abajo = false;
        } else if (resultante.x < 0) {
            derecha = true;
            izquierda = false;
            arriba = false;
            abajo = false;
        }
    }
    public void IrseDelObjetivo () {
        Vector3 resultante = transform.position - target.transform.position;
        if (resultante.x > 0) {
            derecha = false;
            izquierda = true;
            arriba = false;
            abajo = false;
        } else if (resultante.x < 0) {
            derecha = true;
            izquierda = false;
            arriba = false;
            abajo = false;
        }
    }
    private void LlenarColores () {
        //this.listaDeColores.Add (Color.black);
        this.listaDeColores.Add (Color.blue);
        this.listaDeColores.Add (Color.cyan);
        this.listaDeColores.Add (Color.green);
        this.listaDeColores.Add (Color.grey);
        this.listaDeColores.Add (Color.magenta);
        this.listaDeColores.Add (Color.red);
        //this.listaDeColores.Add (Color.white);
        this.listaDeColores.Add (Color.yellow);
    }

    private void Caminar (float movimiento, bool golpeSuave, bool golpeDuro) {
        if (!VaHacerAlgo) {
            return;
        }
        if (golpear) {
            return;
        }
        if (izquierda) {
            movimiento = 1;
        } else if (derecha) {
            movimiento = -1;
        } else if (morir) {
            movimiento = 0;
        } else {
            movimiento = 0;
        }
        xMov = movimiento * speed;

        rb.velocity = new Vector2 (xMov, rb.velocity.y);

        an.SetFloat ("xmov", Mathf.Abs (xMov));
        if (xMov != 0) {
            // tambien flipeamos todos los cosos
            sangre.transform.rotation = Quaternion.Euler (sangre.transform.rotation.x, xMov < 0 ? 180 : 0, sangre.transform.rotation.z);
            golpe.transform.rotation = Quaternion.Euler (golpe.transform.rotation.x, xMov < 0 ? 180 : 0, golpe.transform.rotation.z);
            GetComponent<SpriteRenderer> ().flipX = xMov < 0;
        }
    }

    public void RestarVida (int vida) {
        salud -= vida;
        contadorMostrador.text = salud.ToString ();
        //colocamos la sangre en la pares, para despues hacer una probabilidad de que pase
        sangre.GetComponent<ColocarSangreEnPared> ().ColocarSangre ();
    }

    public float GetSalud () {
        return salud;
    }
    public void MorirEnemigo () {
        morir = true;
        salud = 0;
        an.SetTrigger ("morir");
    }

    public void Morir1 () {
        //Aqui desactivamos todo
        Destroy (GetComponent<Rigidbody2D> ());
        GetComponent<BoxCollider2D> ().enabled = false;
        transform.Find ("vidaFront").gameObject.SetActive (false);
    }
    public void Morir2 () {
        controladorDeMundo.MuereEnemigo ();
        if (!VaHacerAlgo) {
            Destroy (gameObject);
        }
        gameObject.tag = "Muerto";
        GetComponent<EnemigoControlador> ().enabled = false;
    }

    IEnumerator Golpear () {
        an.SetTrigger ("golpeDuro");
        yield return new WaitForSeconds (0);
    }

    public void QueNoHagaNada () {
        VaHacerAlgo = false;
    }

    public void QueLoHagaTodo () {
        VaHacerAlgo = true;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.transform.CompareTag ("Player")) {
            if (!VaHacerAlgo) {
                return;
            }
            an.SetTrigger ("golpeDuro");
        }
    }
}