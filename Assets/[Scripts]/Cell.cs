using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    public int value = 0;

    void Update()
    {
        if (transform.childCount > 0) value = 1;
        else value = 0;
    }

    void OnMouseDown()
    {
        SpriteRenderer cross = Instantiate(Resources.Load<SpriteRenderer>("cross"), transform.position, Quaternion.identity, transform);
        cross.transform.DOScale(Vector3.one, 0.25f).OnComplete(() =>
        {
            cross.GetComponent<Cross>().ActivateChilds();
            DOVirtual.DelayedCall(0.1f, () => cross.GetComponent<Cross>().ControlCells());
        });
    }
}
