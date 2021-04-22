using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cross : MonoBehaviour
{
    #region Variables
    int count = 0;
    public List<GameObject> crosses;
    public List<GameObject> mainCrosses;
    public bool youCanDestroy = false;
    #endregion

    void Update()
    {
        if (youCanDestroy)
        {
            transform.DOScale(Vector3.one * 0, 0.25f).OnComplete(() =>
            {
                gameObject.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;
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
                mainCrosses.Add(transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross);
                count++;
            }
        }

        if (count >= 2)
        {
            for (int i = 0; i < mainCrosses.Count; i++)
            {
                for (int j = 0; j < mainCrosses[i].transform.childCount; j++)
                {
                    if (mainCrosses[i].transform.GetChild(j).GetComponent<TriggerControl>().fill && mainCrosses[i].transform.GetChild(j).GetComponent<TriggerControl>().cellWithCross != gameObject)
                    {
                        crosses.Add(mainCrosses[i].transform.GetChild(j).GetComponent<TriggerControl>().cellWithCross);
                    }
                }
            }
            DestroyCrosses();
        }
        else
        {
            for (int i = 0; i < mainCrosses[0].transform.childCount; i++)
            {
                if (mainCrosses[0].transform.GetChild(i).GetComponent<TriggerControl>().fill && mainCrosses[0].transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross != gameObject)
                {
                    crosses.Add(mainCrosses[0].transform.GetChild(i).GetComponent<TriggerControl>().cellWithCross);
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
        youCanDestroy = true;
        for (int i = 0; i < mainCrosses.Count; i++)
        {
            mainCrosses[i].GetComponent<Cross>().youCanDestroy = true;
        }
        for (int i = 0; i < crosses.Count; i++)
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
