using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{

    public GameObject localThing;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var coordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(localThing, new Vector3(coordinates.x, coordinates.y, 1), Quaternion.Euler(0, 0, 0));

            Move.AddPoint(coordinates);
        }
    }
}
