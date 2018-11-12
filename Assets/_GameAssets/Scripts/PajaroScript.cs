using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {

    public int maxForce = 200;
    Touch[] pulsaciones;
    Touch pulsacion;
    Vector2 posicionInicial;
    Vector2 posicionFinal;


    void Update() {
        pulsaciones = Input.touches;
        //Si no hay pulsaciones no seguimos
        if (pulsaciones.Length == 0) {
            return;
        }
        //Recojo la pulsación
        pulsacion = pulsaciones[0];

        if (!ComprobarPulsacionObjetoByName(pulsacion, "PolloCabreao")) {
            return;
        }

        //Evaluar las pulsaciones
        switch (pulsacion.phase) {
            case (TouchPhase.Began):
                ComenzarToque();
                break;
            case (TouchPhase.Moved):
                MoverToque();
                break;
            case (TouchPhase.Ended):
                FinalizarToque();
                break;
            case (TouchPhase.Canceled):
                //CancelarToque();
                break;
            case (TouchPhase.Stationary):
                //PausarToque();
                break;
            default:
                //EjecutarAccionPorDefectoToque();
                break;
        }
    }

    void ComenzarToque() {
        //Obtenemos el vector de posición en el mundo del juego
        Vector2 posicionConvertida = getWorldPosition(pulsacion);
        //Asignamos la nueva posición
        transform.position = posicionConvertida;
        posicionInicial = posicionConvertida;
    }

    void MoverToque() {
        //Obtenemos el vector de posición en el mundo del juego
        Vector2 posicionConvertida = getWorldPosition(pulsacion);
        //Asignamos la nueva posición
        transform.position = posicionConvertida;
    }

    void FinalizarToque() {
        //Asignamos la nueva posición
        posicionFinal = getWorldPosition(pulsacion);
        //Calculamos direccion
        Vector2 vectorDistancia = (posicionInicial - posicionFinal);
        Vector2 vectorDireccion = vectorDistancia.normalized;
        float distancia = vectorDistancia.magnitude;
        //Ponemos el rigidbody2d en modo kinematic
        GetComponent<Rigidbody2D>().isKinematic = false;
        //Le damos un empujon
        GetComponent<Rigidbody2D>().AddRelativeForce(vectorDireccion * distancia * maxForce);
    }

    private Vector2 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector2(_t.position.x, _t.position.y));
    }

    private bool ComprobarPulsacionObjetoByName(Touch _t, string _name) {
        bool estaPulsado = false;
        //Posicion del Touch en funcion del mundo
        Vector3 touchWorldPosition = getWorldPosition(_t);
        //Obtencion del objeto pulsado
        RaycastHit2D rch2d = Physics2D.Raycast(Camera.main.transform.position, touchWorldPosition);
        //Comprobacion
        if (rch2d.transform != null && rch2d.transform.gameObject.name == _name) {
            estaPulsado = true;
        }
        return estaPulsado;
    }

}
