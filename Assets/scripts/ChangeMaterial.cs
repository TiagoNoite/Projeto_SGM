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

    void Start()
    {
        // Obter o Renderer do objeto
        objectRenderer = GetComponent<Renderer>();

      
    }

    void Update()
    {
        if (isInTrigger )
        {
            // Incrementar o tempo enquanto o objeto está no trigger
            timeInTrigger += Time.deltaTime;

               if (timeInTrigger >= firstChangeTime && timeInTrigger <= secondChangeTime)
            {
                objectRenderer.material = firstMaterial;
                
            }

            // Mudar o material com base no tempo
            if (timeInTrigger >= secondChangeTime)
            {
                objectRenderer.material = secondMaterial;
              
            }
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
        // Resetar apenas o estado do trigger, mas não o material
        if (other.CompareTag("Trigger"))
        {
            isInTrigger = false;

            // Não resetamos `timeInTrigger` ou o material, para manter a mudança permanente
        }
    }
}