using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform mainCharacter;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(mainCharacter.position.x, mainCharacter.position.y+2, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed); ;
    }
}
