using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    public GameObject groundPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(groundPrefab, new Vector3(0f, 0f, 45f), Quaternion.identity);
    }


}
