using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    public GameObject Player;
    private GameObject Target;
    public float CameraZ = -10;
    // Update is called once per frame
    void FixedUpdate() {
        Vector3 TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, CameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 2f);
    
    
    }
}
