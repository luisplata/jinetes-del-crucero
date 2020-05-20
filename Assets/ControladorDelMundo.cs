using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDelMundo : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    private int cantidadDeEnemigos, enemigosSpwneados, enemigosEliminados = 0; //cantidad de enemigos en pantalla

    public GameObject camara1, camara2, marcador, enemigos, contadorParaNuevaOleada;
    float deltaTime = 0;

    //1,2,4,8,16,32,64,128,256,512//Por ahora
    [SerializeField]
    public List<int> cantidadDeEnemigosPorOleada;
    public GameObject gameOver, score, pausa, jugador;
    [SerializeField]
    private int oleada;
    private UIController uIController;
    [SerializeField]
    private bool isNuevaOleada;
    [SerializeField]
    public bool primerEnemigo = true;

    public GameObject puntoUno, puntoDos, puntoTres;
    public float tiempoEscala = 1;
    private bool isCalmado = false;

    private bool activarSpawner = true;
    private bool isPausa = true;
    private int rangoDeTiempoParaSpawnear;

    void Start () {
        uIController = GameObject.Find ("UIController").GetComponent<UIController> ();
        oleada = 0;
        rangoDeTiempoParaSpawnear = 5;
        deltaTime = 0;
        //creando las cantidades de cada nivel
        cantidadDeEnemigosPorOleada = new List<int> ();
        cantidadDeEnemigosPorOleada.Add (1);
        for (int i = 0; i < 10; i++) {
            cantidadDeEnemigosPorOleada.Add (cantidadDeEnemigosPorOleada[i] * 2);
        }
        uIController.ActualizarEnemigos (cantidadDeEnemigosPorOleada[this.oleada]);
        enemigosEliminados = cantidadDeEnemigosPorOleada[this.oleada];

        //spawnear al primer enemigo
        if (primerEnemigo) {
            puntoUno.GetComponent<Spawner> ().PrimerEnemigo ();
        }
    }
    //sumar y restar a la variable de enemigos para saber cuantos enemigos hay en pantalla
    //sumatoria de los enemigos y compararla con cantidadDeEnemigosPorOleada[this.oleada] para saber si me detengo o no en el spawn
    private void Update () {
        if ((Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Joystick1Button9)) && isPausa) {
            Pausar ();
        } else if ((Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Joystick1Button9)) && !isPausa) {
            Reanudar ();
        }
        //controlamos las nuevas oleadas
        if (primerEnemigo) {
            GameObject enemigoModificadoo = GameObject.FindGameObjectWithTag ("Enemigo");
            primerEnemigo = enemigoModificadoo != null;
        }
        deltaTime += Time.deltaTime;
        if (!primerEnemigo) {
            Debug.Log ("rangoDeTiempoParaSpawnear " + rangoDeTiempoParaSpawnear);
            if (deltaTime >= rangoDeTiempoParaSpawnear) {
                if (!isCalmado) {
                    rangoDeTiempoParaSpawnear = Random.Range (0, 7);
                    //colocamos a uno de los spwners a spwanear
                    puntoUno.GetComponent<Spawner> ().SpawnearEnemigo ();
                    puntoDos.GetComponent<Spawner> ().SpawnearEnemigo ();
                    puntoTres.GetComponent<Spawner> ().SpawnearEnemigo ();
                    deltaTime = 0;
                } else {
                    //aqui termina la musica de descanzo
                    //isCalmado = false;
                }
            }
        }
        //ahora necesitamos estar verificando los enemigos y cuandos faltan
        if ((cantidadDeEnemigosPorOleada[this.oleada] - enemigosEliminados) > 0 || primerEnemigo) {
            //aun hay enemigos en la escena
            isNuevaOleada = true;
        } else {
            //significa que ya no hay enemigos en la scena
            //comienza una nueva oleada
            if (isNuevaOleada) {
                NuevaOleada ();
                isNuevaOleada = false;
            }
        }
    }
    public void Pausar () {
        Debug.Log (jugador.GetComponent<SpriteRenderer> ().sprite.name);
        int index;
        if (jugador.GetComponent<SpriteRenderer> ().sprite.name.Split ('_').Length <= 1) {
            index = 1;
        } else {
            index = int.Parse (jugador.GetComponent<SpriteRenderer> ().sprite.name.Split ('_') [1]); //si no lo combirte esposible que sea los sprinte de caminar
        }
        string indexString = index < 10 ? "0" + index.ToString () : index.ToString ();
        //ahora colocamos random la cara
        int randomCara = Random.Range (1, 4);
        string caraSeleccionada = "caras" + (randomCara >= 2 ? randomCara.ToString () : "") + "/caras" + ((randomCara >= 2 ? randomCara.ToString () : "") + indexString);
        Sprite spriteSeleccionada = Resources.Load<Sprite> (caraSeleccionada);
        jugador.GetComponent<SpriteRenderer> ().sprite = spriteSeleccionada;
        isPausa = false;
        camara2.SetActive (!isPausa);
        Time.timeScale = 0;
        //hacemos que el jugador no se pueda mover
        jugador.GetComponent<JoseController> ().QueNoSeMueva ();
        pausa.SetActive (!isPausa);
        jugador.GetComponent<Animator> ().enabled = isPausa;
    }
    public void Reanudar () {
        isPausa = true;
        camara2.SetActive (!isPausa);
        Time.timeScale = 1;
        pausa.SetActive (!isPausa);
        jugador.GetComponent<Animator> ().enabled = isPausa;
        jugador.GetComponent<JoseController> ().QueSeMueva ();
    }
    public void GameOver () {
        //Aqui lo va a pasar es:
        //Abrir UI del Game Over
        //Cerrar UI de Score
        gameOver.SetActive (true);
        score.SetActive (false);
    }

    public void RestarGame () {
        Reanudar ();
        gameObject.SetActive (false);
        score.SetActive (true);
        Time.timeScale = 1;
        SceneManager.LoadScene ("Game");
    }

    public void NuevaOleada () {
        //verificamos que si termina la oleada 10, mandarlo a la pantalla de 
        if (oleada == 10) {
            SceneManager.LoadScene ("Creditos");
        }
        //aqui comienza la musica de descanzo
        StartCoroutine ("HacerPalpitarMarcador");
        //isCalmado = true;
        //StartCoroutine ("ContadorParaNuevaOleada");
        oleada++;
        //ahora colocamos en la GUI la oleada
        uIController.ActualizarOleada ();
        uIController.ActualizarEnemigos (cantidadDeEnemigosPorOleada[this.oleada]);
        enemigosEliminados = 0;
        enemigosSpwneados = 0;
        rangoDeTiempoParaSpawnear = 7;
        cantidadDeEnemigos = cantidadDeEnemigosPorOleada[this.oleada];
    }

    public int EnemigosFaltantes () {
        return cantidadDeEnemigosPorOleada[this.oleada];
    }
    public int OleadaActual () {
        return this.oleada + 1;
    }

    public void SpawnEnemigo () {
        AumentoDeEnemigo ();
    }
    public void MuereEnemigo () {
        StartCoroutine ("HacerPalpitarMarcadorEnemigos");
        enemigosSpwneados--;
        cantidadDeEnemigos--;
        enemigosEliminados++;
        uIController.ActualizarEnemigos (cantidadDeEnemigosPorOleada[this.oleada] - enemigosEliminados);
    }
    public int GetVantidadDeEnemigos () {
        return cantidadDeEnemigos;
    }

    public void AumentoDeEnemigo () {
        enemigosSpwneados++;
    }

    public int EnemigosSumados () {
        return enemigosSpwneados;
    }

    public void Salir () {
        //lo mandamos a la pantalla de menu
        //Application.Quit ();
        SceneManager.LoadScene ("Menu");
    }

    IEnumerator HacerPalpitarMarcador () {
        for (int i = 0; i < 10; i++) {
            marcador.GetComponent<Image> ().color = i % 2 == 0 ? Color.red : Color.white;
            yield return new WaitForSeconds (0.1f);
        }
    }

    IEnumerator HacerPalpitarMarcadorEnemigos () {
        for (int i = 0; i < 10; i++) {
            enemigos.GetComponent<Image> ().color = i % 2 == 0 ? Color.red : Color.white;
            yield return new WaitForSeconds (0.05f);
        }
    }

    IEnumerator ContadorParaNuevaOleada () {
        isCalmado = true;
        PrenderContador ();
        for (int i = 6; i > 0; i--) {
            UpDateContador (i.ToString ());
            yield return new WaitForSeconds (1);
        }
        ApagarContador ();
        isCalmado = false;
    }

    public void UpDateContador (string numero) {
        contadorParaNuevaOleada.GetComponent<TextMeshProUGUI> ().text = numero;
    }

    public void PrenderContador () {
        contadorParaNuevaOleada.SetActive (true);
    }
    public void ApagarContador () {
        contadorParaNuevaOleada.SetActive (false);
    }

}