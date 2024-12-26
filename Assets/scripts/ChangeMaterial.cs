using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material firstMaterial;    // Primeiro material
    public Material secondMaterial;   // Segundo material
    public float firstChangeTime = 2f;  // Tempo para a primeira mudança
    public float secondChangeTime = 4f; // Tempo para a segunda mudança

    private Renderer objectRenderer;  // Renderer do objeto
    private float timeInTrigger = 0f; // Tempo dentro do trigger
    private bool isInTrigger = false; // Verificar se está no trigger
    private bool firstMaterialApplied = false; // Verificar se o primeiro material foi aplicado
    private bool secondMaterialApplied = false; // Verificar se o segundo material foi aplicado
    public AudioSource readyTGo;

    void Start()
    {
        // Obter o Renderer do objeto
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isInTrigger)
        {
            // Incrementar o tempo enquanto o objeto está no trigger
            timeInTrigger += Time.deltaTime;

            // Mudar para o primeiro material e tocar som apenas uma vez
            if (timeInTrigger > firstChangeTime && timeInTrigger < secondChangeTime && !firstMaterialApplied)
            {
                PlayAudioOnce();
                objectRenderer.material = firstMaterial;
                firstMaterialApplied = true;
                gameObject.tag = "caco";
            }
            // Mudar para o segundo material e tocar som apenas uma vez
            else if (timeInTrigger >= secondChangeTime && !secondMaterialApplied)
            {
                PlayAudioOnce();
                objectRenderer.material = secondMaterial;
                secondMaterialApplied = true;
                gameObject.tag = "caco_cozido";
            }
        }
    }

    private void PlayAudioOnce()
    {
        // Tocar som apenas se não estiver tocando
        if (!readyTGo.isPlaying)
        {
            readyTGo.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ativar a lógica quando entrar no trigger
        if (other.CompareTag("Trigger")) // Certifique-se de que o trigger tem a tag correta
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Resetar apenas o estado do trigger
        if (other.CompareTag("Trigger"))
        {
            isInTrigger = false;
            timeInTrigger = 0f; // Resetar o tempo no trigger
        }
    }
}