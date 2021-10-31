using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public PlayerStart end;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            end.EndTheGame();
        }
    }
}
