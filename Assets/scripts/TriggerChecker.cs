using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Tag do objeto que queremos detectar
    public string tagDoObjetoAlvo = "copo";

    // Método chamado quando outro objeto entra na área do trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto possui a tag especificada
        if (other.CompareTag(tagDoObjetoAlvo))
        {
             Debug.Log("Iniciando enchimento do copo!");
            // Tenta acessar o script EncherCopo no objeto detectado e inicia o enchimento
            encher encherCopoScript = other.GetComponentInChildren<encher>();
            if (encherCopoScript != null)
            {
                Debug.Log("ta enchendo o bicho");
                encherCopoScript.IniciarEnchimento();
               
            }
        }
    }

    // Método chamado quando o objeto sai da área do trigger
    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu do trigger possui a tag especificada
        if (other.CompareTag(tagDoObjetoAlvo))
        {
             Debug.Log("Parando enchimento do copo!");

            // Tenta acessar o script EncherCopo no objeto detectado e para o enchimento
            encher encherCopoScript = other.GetComponentInChildren<encher>();
            if (encherCopoScript != null)
            {
                Debug.Log("ta parando o bicho");
                encherCopoScript.PararEnchimento();
               
            }
        }
    }
}
