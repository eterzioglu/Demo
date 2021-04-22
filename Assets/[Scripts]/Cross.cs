using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cross : MonoBehaviour
{
    int count = 0;
    int index = 0;
    public GameObject[] crosses;
    public bool youCanDestroy = false;

    void Start()
    {
        crosses = new GameObject[3];
        crosses[index] = gameObject;
    }

    void Update()
    {
        if (youCanDestroy) Destroy(gameObject);
    }

    public void ControlCells()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log("ilk döngü");
            if (transform.GetChild(i).GetComponent<TriggerControl>().fill)
            {
                Debug.Log("komşu bulundu");
                index++;
                crosses[index] = transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross;
                count++;
                if (count == 2)
                {
                    Debug.Log("ikinci eleman bulundu");
                    GridManager.instance.DestroyCrosses(crosses);
                    break;
                }
            }
        }

        if (count == 1)
        {
            for (int i = 0; i < crosses[1].transform.childCount; i++)
            {
                Debug.Log("ikinci döngü");
                if (crosses[index].transform.GetChild(i).GetComponent<TriggerControl>().fill && crosses[index].transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross != gameObject)
                {
                    index++;
                    Debug.Log("eleman bulundu");
                    crosses[index] = crosses[index].transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross;
                    count++;
                    if (count == 2)
                    {
                        Debug.Log("yok edildi");
                        GridManager.instance.DestroyCrosses(crosses);
                        break;
                    }
                }
            }
        }
    }

    public void ActivateChilds()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
