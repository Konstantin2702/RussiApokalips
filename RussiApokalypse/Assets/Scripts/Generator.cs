using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        var left = this.transform.position.x - 0.5f;
        var right = this.transform.position.x + 0.5f;
        var bottom = GameObject.Find("bottom").transform.position.x;
        var top = GameObject.Find("top").transform.position.x;
        GameObject ob = obj;
        ob.transform.position = new Vector3((left - (right - left) / 2), obj.transform.position.y, obj.transform.position.z);
        Instantiate(ob, ob.transform.position, ob.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
