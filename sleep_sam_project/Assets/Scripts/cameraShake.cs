using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public IEnumerator Shake(float durationTime, float shakeStrength){
        
        Vector3 originalPosition = transform.localPosition;
        
        float timePassed = 0.0f;

        while (timePassed < durationTime){
            float x = Random.Range(-1f, 1f) * shakeStrength;
            float y = Random.Range(-1f, 1f) * shakeStrength;

            transform.localPosition = new Vector3(x,y, originalPosition.z);

            //increases it by the time that has passed by
            timePassed += Time.deltaTime;

            //waits for next frame to start
            yield return null;
        }

        //resets the camera position
        transform.localPosition = originalPosition;
    }
}
