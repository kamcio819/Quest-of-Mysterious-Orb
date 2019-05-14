using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.up, 2f * Time.deltaTime);
    }
}
