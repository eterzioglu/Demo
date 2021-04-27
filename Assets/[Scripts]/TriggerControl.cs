using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    public bool fill = false;
    public GameObject cross;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cross")
        {
            fill = true;
            cross = other.gameObject;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
