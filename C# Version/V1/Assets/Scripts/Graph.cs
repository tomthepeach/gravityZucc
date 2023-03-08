using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Graph : MonoBehaviour {

    public float graphWidth;
    public float graphHeight;
    LineRenderer newLineRenderer;
    public List<int> energy;
    int vertexAmount = 50;
    float xInterval;

     GameObject parentCanvas;

     // Use this for initialization
     void Start ()
     {
         parentCanvas = GameObject.Find("Canvas");
         graphWidth = transform.Find("Linerenderer").GetComponent<RectTransform>().rect.width;
         graphHeight = transform.Find("Linerenderer").GetComponent<RectTransform>().rect.height;
         newLineRenderer = GetComponentInChildren<LineRenderer>();
         newLineRenderer.SetVertexCount(vertexAmount);

         xInterval = graphWidth / vertexAmount;
     }

     //Display 1 minute of data or as much as there is.
     public void Draw(List<int> energy)
     {
         if (energy.Count == 0)
             return;

         float x = 0;

         for (int i = 0; i < vertexAmount && i < energy.Count; i++)
         {
             int _index = energy.Count - i - 1;

             float y = energy[_index] * (graphHeight/130); //(Divide grapheight with the maximum value of energys.
             x = i * xInterval;

             newLineRenderer.SetPosition(i, new Vector3(x - graphWidth / 2 , y - graphHeight / 2 , 0));
         }
     }
 }