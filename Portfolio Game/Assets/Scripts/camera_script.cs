using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    private Vector3 Offset;
    [SerializeField]
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + Offset;
    }
}
