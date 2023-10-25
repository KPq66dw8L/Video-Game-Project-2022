using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIonScreen : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;
    
    // Basically, same script as CameraFollow, except for the y value
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Max(-1, targetToFollow.position.y) -3f,
            transform.position.z);
    }
}
