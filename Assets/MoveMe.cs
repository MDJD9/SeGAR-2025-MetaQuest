using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void MoveForward() {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
    }
    
}
