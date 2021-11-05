using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CopyPlayerPos : MonoBehaviour
{

    public Transform playerPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z);
    }
}
