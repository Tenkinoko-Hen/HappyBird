using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManage : MonoBehaviour
{
    public static PipelineManage instance;
    public GameObject pipelineFarber;

    List<pipelineC> pipelines = new List<pipelineC>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    Coroutine coroutine = null;

    public void StartPipeline()
    {
        coroutine= StartCoroutine(Createpipe());
       
    
    }

    public void StopPipeline()
    {
        StopCoroutine(coroutine);
       for(int i=0;i<pipelines.Count;i++)
        {
            pipelines[i].enabled = false;
        }
    }


   IEnumerator Createpipe() {
       

        for (int i = 0; i < 3; i++)
        {

            if (pipelines.Count < 3)
            {
                Createpipeline();
            }
            else
            {
                pipelines[i].enabled = true;
                pipelines[i].p_init();
            }
            
                yield return new WaitForSeconds(2.5f);
        }

       


    }

    


    void Createpipeline()
    {
       
        if (pipelines.Count < 3)
        {
       
            GameObject obj = Instantiate(pipelineFarber, this.transform);
            pipelines.Add(obj.GetComponent<pipelineC>());


        }
    }

    public void init()
    {
        for (int i = 0; i <pipelines.Count; i++)
        {
            Destroy(pipelines[i].gameObject);
    
        }
        pipelines.Clear();
        Debug.Log("我的值是:" + pipelines.Count);
    }

}
