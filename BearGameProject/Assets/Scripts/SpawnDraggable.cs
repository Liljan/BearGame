using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDraggable : MonoBehaviour
{
    Ray Ray;
    RaycastHit Hit;
    public GameObject Prefab;
    public Camera MainCamera;
    public int HeightOffset;
    //public GameObject GroundPlane;

    List<GameObject> spawnedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("ResetGame", ClearSpawnedObjects);
    }

    // Update is called once per frame
    void Update()
    {
        ////For debugging
        //if (Input.GetKeyDown("space"))
        //{
        //    ClearSpawnedObjects();
        //}

    }

    void OnMouseDown()
    {
        if(Input.GetMouseButton(0) && Prefab != null)
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Ray, out Hit))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    GameObject obj = Instantiate(Prefab, new Vector3(Hit.point.x, Hit.point.y, Hit.point.z), Quaternion.identity) as GameObject;
                    obj.GetComponent<DraggablePerspective>().MainCamera = MainCamera;
                    obj.GetComponent<DraggablePerspective>().HeightOffset = HeightOffset;
                    obj.GetComponent<DraggablePerspective>().BeginDrag();

                    spawnedObjects.Add(obj);
                }
            }
        }
    }

    public void ClearSpawnedObjects()
    {
        foreach( GameObject spawned in spawnedObjects)
        {
            Destroy(spawned);
        }

        spawnedObjects.Clear();
    }
}
