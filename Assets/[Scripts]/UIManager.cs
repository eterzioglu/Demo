using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    #region Variables
    public InputField gridCount;
    public Button button;
    #endregion

    #region Singleton
    public static UIManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void GenerateGridButton()
    {
        gridCount.image.DOFade(0, 0.5f);
        gridCount.transform.GetChild(1).GetComponent<Text>().DOFade(0, 0.5f);
        button.image.DOFade(0, 0.5f);
        button.transform.GetChild(0).GetComponent<Image>().DOFade(0, 0.5f);
        button.transform.GetChild(1).GetComponent<Text>().DOFade(0, 0.5f).OnComplete(() =>
        {
            gridCount.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
            GridManager.instance.GenerateGrid();
        });
    }
}
