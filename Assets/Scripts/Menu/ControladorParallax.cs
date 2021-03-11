using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorParallax : MonoBehaviour, IControllerParallaxView {
    public RawImage cielo, edificios, pasto, piso, paredFondo, faroles;
    [SerializeField]
    private float speed = 0.007f;
    private ParalaxLogic logic;
    private const float one = 1;
    private const float zero = 0;

    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    private void Start()
    {
        logic = new ParalaxLogic(this, speed);
    }

    // Update is called once per frame
    void Update () {
        cielo.uvRect = CreateRect(cielo, 1);
        edificios.uvRect = CreateRect(edificios, 3);
        paredFondo.uvRect = CreateRect(paredFondo, 2.5f);
        pasto.uvRect = CreateRect(pasto, 2);
        faroles.uvRect = CreateRect(faroles, 1.8f);
        piso.uvRect = CreateRect(piso, 1);
    }

    private Rect CreateRect(RawImage image, float speedRelative)
    {
        return new Rect(logic.MoveParallax(image.uvRect.x, speedRelative), zero, one, one);
    }
}