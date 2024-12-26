using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_tag : MonoBehaviour
{
    public GameObject cilindor;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        float altura=cilindor.GetComponent<encher>().GetAlturaInicial();
        if (altura>=1.5f){
            gameObject.tag = "copo";
        }
        Debug.Log("altura inicial :" + altura);
    }
}
