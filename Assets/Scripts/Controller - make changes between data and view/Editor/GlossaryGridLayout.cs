using Codice.Client.BaseCommands.Merge;
using GitHub.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryGridLayout : LayoutGroup
{
    private enum FitType
    {
        Uniform,
        Width, 
        Height,
        FixedRows, 
        FixedColumns,
    }

    private FitType fitType = FitType.FixedColumns;
    private int rows;
    private int columns = 2;
    private Vector2 Column1_cellSize = new Vector2(200, 0);
    private Vector2 Column2_cellSize = new Vector2(500, 0);

    public Vector2 spacing;
    public bool fitX;
    public bool fitY;
    public float cellHeight;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        if(fitType== FitType.Uniform || fitType == FitType.Height || fitType == FitType.Width)
        {
            fitX = true;
            fitY = true;
            float sqrRt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrRt);
            columns = Mathf.CeilToInt(sqrRt);
        }

        if(fitType == FitType.Width || fitType == FitType.FixedColumns)
        {
            rows = Mathf.CeilToInt(transform.childCount / (float)columns);
        }
        if (fitType == FitType.Height || fitType == FitType.FixedRows)
        {
            columns = Mathf.CeilToInt(transform.childCount / (float)rows);
        }

        int columnCount = 0;
        int rowCount = 0;
        int rowcounter = 0;
        float cummulative_Y = 0;

        for(int i = 0; i < rectChildren.Count; i+=2)
        {
            rowCount = rowcounter / columns;
            columnCount = rowcounter % columns;

            var term = rectChildren[i];
            var defintion = rectChildren[i + 1];

            if(i == 0)
            {
                //First row to be inserted
                cummulative_Y = (spacing.y * rowCount) + padding.top;
            }

            //Calculations
            var xPosDef = (Column1_cellSize.x) + (spacing.x * columnCount) + padding.left;

            //term
            SetChildAlongAxis(term, 0, 0, Column1_cellSize.x);
            SetChildAlongAxis(term, 1, cummulative_Y, Column1_cellSize.y);

            //definition
            SetChildAlongAxis(defintion, 0, xPosDef, Column2_cellSize.x);
            SetChildAlongAxis(defintion, 1, cummulative_Y, defintion.rect.yMax);

            float ymin = defintion.rect.yMin;
            float ymax = defintion.rect.yMax;

            Debug.Log("Ymin: " + ymin + ", Ymax: " + ymax);
            //increments this at the end of inserting a rows

            cummulative_Y += (cellHeight + padding.top);

            Debug.Log("cummulative Y: " + cummulative_Y);
            rowcounter++;

        }
    }
    public override void CalculateLayoutInputVertical()
    {

    }

    public override void SetLayoutHorizontal()
    {

    }

    public override void SetLayoutVertical()
    {

    }
}
