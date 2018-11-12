using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScript : MonoBehaviour {

    public float orthoZoomSpeed = 0.5f;
    private float zoom = 10;

    private void Start() {
        Camera.main.orthographicSize = zoom;
    }

    void Update () {

        if (zoom>8) {
            zoom = zoom - Time.deltaTime * 5;
            Camera.main.orthographicSize = zoom;

        }

        if (Input.touchCount == 2) {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
                        
                Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            
        }
    }
}
