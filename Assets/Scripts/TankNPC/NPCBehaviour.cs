using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCBehaviour : MonoBehaviour
{
    public GameObject text;


    private List<Collider> triggerList;
    
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        triggerList = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        triggerList.Add(other);
        text.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        triggerList.Remove(other);
        if (triggerList.Count <= 0)
            text.SetActive(false);
    }
}
