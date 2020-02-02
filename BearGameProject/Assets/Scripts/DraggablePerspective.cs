using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DraggablePerspective : MonoBehaviour
{
    public Camera MainCamera;
    public int HeightOffset;

    [Space]
    //[SerializeField]
    //public UnityEvent OnBeginDrag;
    //[SerializeField]
    //public UnityEvent OnEndDrag;

    // Private Properties
   // float ZPosition;
    bool Dragging;

    private void Update()
    {
        if (Dragging)
        {
            Transform draggingObject = transform;
            float planeY = /*GroundPlane.transform.position.y + */HeightOffset;
            Plane plane = new Plane(Vector3.up, Vector3.up * (Mathf.Abs(planeY))); //Draggable plane

            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                draggingObject.position = ray.GetPoint(distance); // distance along the ray
            }
        }
    }

    void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDrag();
        }
    }

    void OnMouseUp()
    {
        EndDrag();
    }

    public void BeginDrag()
    {
        //OnBeginDrag.Invoke();
        Dragging = true;
    }

    public void EndDrag()
    {
        //OnEndDrag.Invoke();
        Dragging = false;
    }
}
