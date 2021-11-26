using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Point : MonoBehaviour
{
    public Player player;
    public string tagToCheck = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == tagToCheck)
        {
            Debug.Log("Bati nas bola");
            CountPoint();
        }
    }

    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }

}
