using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForTime: MonoBehaviour
{
    /// <summary>
    /// 销毁物体
    /// </summary>
    private float time = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", time);
    }
    public void Destroy()
    {
        DestroyImmediate(this.gameObject);  
    }
}
