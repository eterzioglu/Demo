using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    #region Variables
    int gridCount;
    public Camera cam;
    Vector3 camPos;
    public GameObject[,] cells;
    #endregion

    #region Singleton
    public static GridManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void GenerateGrid()
    {
        gridCount = Convert.ToInt32(UIManager.instance.gridCount.text);
        cells = new GameObject[gridCount, gridCount];

        SetCamPos(gridCount);

        int x = 0 - gridCount / 2;
        int y = 0 + gridCount / 2;

        for (int i = 0; i < gridCount; i++)
        {
            for (int j = 0; j < gridCount; j++)
            {
                GameObject cell = Instantiate(Resources.Load<GameObject>("cell"), new Vector2(x, y), Quaternion.identity, transform);
                cells[i, j] = cell;
                cell.transform.DOScale(Vector3.one * 0.75f, 0.25f);
                x++;
            }
            x = 0 - gridCount / 2;
            y--;
        }
    }

    void SetCamPos(int count)
    {
        if (count % 2 == 0)
        {
            camPos = new Vector3(-0.5f, 0, gridCount * (-1) * 2);
            cam.transform.position = camPos;
        }
        else
        {
            camPos = new Vector3(0, 0, gridCount * (-1) * 2);
            cam.transform.position = camPos;
        }
    }
}
