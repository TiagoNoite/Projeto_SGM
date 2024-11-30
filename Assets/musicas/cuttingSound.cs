using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuttingSound : MonoBehaviour
{
    public AudioSource audioSource; // Referência ao AudioSource
    public AudioClip somDeCorte; // O som de corte

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Obtém o AudioSource automaticamente
        }
    }

    // Função para tocar o som de corte
    public void Cortar()
    {
        if (somDeCorte != null && audioSource != null)
        {
            audioSource.PlayOneShot(somDeCorte); // Toca o som de corte
        }
    }
    private void OnTriggerEnter(Collider other)
    {   
         Debug.Log("colision");
        if (other.CompareTag("meat")) // Verifica se o objeto é cortável
        {
            Debug.Log("ola");
            Cortar(); // Toca o som de corte
        }
        if (other.CompareTag("carne")) // Verifica se o objeto é cortável
        {
            Debug.Log("ola");
            Cortar(); // Toca o som de corte
        }

    }
}