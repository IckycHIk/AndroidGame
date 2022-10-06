using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderController : MonoBehaviour
{

    private LineRenderer lineRend;

    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
    }
 
    // Update is called once per frame
    void Update()
    {
      
    }

    public void setUpLine(List<Vector3> points) {

       
        lineRend.positionCount = points.Count;
     
        for (int i = 0; i < points.Count; i++)
        {

            lineRend.SetPosition(i, points[i]);

        }

    }





}
