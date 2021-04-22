using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    public bool fill = false;
    public GameObject cellWithCross;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cell" && other.GetComponent<Cell>().value == 1)
        {
            fill = true;
            cellWithCross = other.gameObject.transform.GetChild(0).gameObject;
        }
    }
}
