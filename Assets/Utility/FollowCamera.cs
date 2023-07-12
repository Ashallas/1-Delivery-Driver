using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float zBuffer;
    
    GameObject target;

    void Awake()
    {
        target = FindObjectOfType<Car>().gameObject;    
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + zBuffer);
    }
}
