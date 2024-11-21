using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightCheck : MonoBehaviour
{
    // Altura mínima antes de destruir ou resetar o objeto
    private float alturaMinima = 0.9f;
    private Quaternion rotacaoInicial;

    // Posição inicial para respawn
    private Vector3 posicaoInicial;

    // Tag para verificar se o objeto deve ser destruído
    public string minhaTag;


    private void Start()
    {
        minhaTag = gameObject.tag;
        // Armazena a posição inicial do objeto
        posicaoInicial = transform.position;
         rotacaoInicial = transform.rotation;
    }

    private void Update()
    {
        // Verifica se o objeto caiu abaixo da altura mínima
        if (transform.position.y < alturaMinima)
        {
            Debug.Log("asdasdasd");
            if (minhaTag=="copo" || minhaTag=="beer" || minhaTag=="caco"|| minhaTag=="carne" || minhaTag=="can")
            {
                // Destroi o objeto se a tag for "Destruir"
                Debug.Log($"{gameObject.name} foi destruído por cair abaixo da altura mínima.");
                Destroy(gameObject);
            }
            else
            {
                // Reseta o objeto para a posição inicial
                Debug.Log($"{gameObject.name} voltou para a posição inicial.");
                Respawn();
            }
        }
    }

    // Método para resetar o objeto para a posição inicial
    private void Respawn()
    {
        transform.position = posicaoInicial;
        // Opcional: Resetar rotação ou outras propriedades
         transform.rotation = rotacaoInicial;
    }
}