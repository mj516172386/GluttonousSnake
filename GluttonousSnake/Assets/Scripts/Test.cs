using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision!=null)
        {
            print(collision.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
