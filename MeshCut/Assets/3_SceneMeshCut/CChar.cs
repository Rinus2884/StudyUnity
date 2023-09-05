using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CChar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Debug.Log("Submeshes: " + mesh.subMeshCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
