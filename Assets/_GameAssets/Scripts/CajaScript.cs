using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaScript : MonoBehaviour {

    [SerializeField] GameObject prefabScore;
    private bool estaIntacta = true;

    [SerializeField] protected ParticleSystem psExplosion;
    [SerializeField] Transform posExploGeneracion;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (estaIntacta && collision.gameObject.name == "PolloCabreao") {
            Instantiate(prefabScore, transform.position, Quaternion.identity);
            estaIntacta = false;
            ParticleSystem ps = Instantiate(psExplosion, posExploGeneracion.position, Quaternion.identity);
            ps.Play();
            Destroy(this.gameObject);
        }
        /*if (collision.gameObject.name == "TNT") {
            ParticleSystem ps = Instantiate(psTNTExplosion, posTNTExploGeneracion.position, Quaternion.identity);
            ps.Play();
            Destroy(transform.parent.gameObject);
        }*/
    }
}
