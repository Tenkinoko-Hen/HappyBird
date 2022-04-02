using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipelineC : MonoBehaviour
{
    public float pipielineSpeed;
    public float maxRandowm=3;
    public float minRandowm=-1;
    private float random;
 
    // Start is called before the first frame update
    void Start()
    {
        p_init();
     
    }
    float time = 0;
    public void p_init()
    {
        float random = Random.Range(minRandowm, maxRandowm);
        this.transform.localPosition = new Vector3(0, random, 0);

  
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        time += 0.02f;
   
        if (time >= 7f)
        {
            
            time = 0;
            p_init();
        }
    }

    private void Move()
    {
        this.transform.position += new Vector3(-pipielineSpeed, random) * 0.02f;
    }
   

}
