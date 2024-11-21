using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceMeat : MonoBehaviour
{
    public GameObject newObject; // Arraste o prefab do novo objeto para este campo no Inspector.

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o objeto específico (pode usar tag ou nome)
        if (other.CompareTag("Trigger")) // Substitua "TriggerObject" pela tag do Objeto 2
        {
            // Cria o novo objeto na posição e rotação do objeto atual
            Instantiate(newObject, transform.position, transform.rotation);

            // Destroi o objeto atual
            Destroy(gameObject);
        }
    }
}