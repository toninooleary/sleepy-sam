using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCameraShake : MonoBehaviour
{
    public Animator cameraAnimation;

    public void CameraShake(){
        cameraAnimation.SetTrigger("shaking");
    }

}
