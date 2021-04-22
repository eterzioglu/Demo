using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cross : MonoBehaviour
{
    #region Variables
    int count = 0;
    int index = 0;
    public GameObject[] crosses;
    public bool youCanDestroy = false;
    #endregion

    void Start()
    {
        crosses = new GameObject[3];
        crosses[index] = gameObject;
    }

    void Update()
    {
        if (youCanDestroy)
        {
            transform.DOScale(Vector3.one * 0, 0.25f).OnComplete(() =>
            {
                Destroy(gameObject);
                youCanDestroy = false;
            });
        }
    }

    public void ControlCells()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<TriggerControl>().fill)
            {
                index++;
                crosses[index] = transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross;
                count++;
                if (count == 2)
                {
                    DestroyCrosses();
                    break;
                }
            }
        }

        if (count == 1)
        {
            for (int i = 0; i < crosses[1].transform.childCount; i++)
            {
                if (crosses[1].transform.GetChild(i).GetComponent<TriggerControl>().fill && crosses[1].transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross != gameObject)
                {
                    index++;
                    crosses[index] = crosses[1].transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross;
                    count++;
                    if (count == 2)
                    {
                        DestroyCrosses();
                        break;
                    }
                }
            }
        }
    }

    void DestroyCrosses()
    {
        UIManager.instance.scoreCount++;
        for (int i = 0; i < crosses.Length; i++)
        {
            crosses[i].GetComponent<Cross>().youCanDestroy = true;
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
