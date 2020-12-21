using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollBehaviour : MonoBehaviour
{
    public Scrollbar scrollbar2;
    // Use this for initialization

    public Vector3 StartPoint2;
    public Vector3 EndPoint2;
    float move;


    public void movecameraVertical()
    {
        //sets the scrollbar to move between the points set in startpoint and endpoint by the value of move
        move = scrollbar2.value;
        Camera.main.transform.position = Vector3.Lerp(StartPoint2, EndPoint2, move);
    }
}
