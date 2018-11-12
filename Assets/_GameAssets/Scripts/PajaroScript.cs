using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {

    Touch [] pulsaciones;
    Touch pulsacion;
    
	void Update () {
        pulsaciones = Input.touches;
        if (pulsaciones.Length==0) {
            return;
        }
        //Recojo la pulsación
        pulsacion = pulsaciones[0];

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
        Vector3 posicionConvertida = getWorldPosition(pulsacion);
        //Restauramos la Z original del pájaro
        posicionConvertida.z = transform.position.z;
        //Asignamos la nueva posición
        transform.position = posicionConvertida;
    }

    void MoverToque() {

    }

    void FinalizarToque() {

    }
    
    private Vector3 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector3(_t.position.x, _t.position.y, 0));
    }

}
