using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBasedTrigger : MonoBehaviour
{
    // Referência ao Collider da Collision Box
    public Collider collisionBoxTrigger;

    // Ângulos mínimo e máximo para ativar o Collider
    public float anguloMinimo = -40.0f;
    public float anguloMaximo = 40.0f;

    void Update()
    {
        // Obter a rotação do objeto em ângulos de Euler
        Vector3 rotacaoAtual = transform.eulerAngles;
      
        // Verificar se a rotação no eixo X está dentro do intervalo
        if (rotacaoAtual.x <= anguloMinimo && rotacaoAtual.x >= anguloMaximo)
        {
        
            // Ativar o Collider se a rotação estiver no intervalo
            if (!collisionBoxTrigger.enabled)
            {
                collisionBoxTrigger.enabled = true;
                Debug.Log("Collider ativado!");
            }
        }
        else
        {
            // Desativar o Collider se a rotação estiver fora do intervalo
            if (collisionBoxTrigger.enabled)
            {
                collisionBoxTrigger.enabled = false;
                Debug.Log("Collider desativado!");
            }
        }
    }
}
