using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutMeat : MonoBehaviour
{
    public GameObject meatPiecePrefab; // Prefab do pedaço de carne que será instanciado
    public GameObject SlicedmeatPiecePrefab; // Prefab do pedaço de carne que será instanciado
    public Transform spawnPoint;      // Posição onde o pedaço de carne será instanciado
    public Transform spawnPointSliced;      // Posição onde o pedaço de carne será instanciado
    public float sliceSpeedThreshold = 2f; // Velocidade mínima para considerar como "corte"

    private Vector3 lastPosition;    // Posição da faca no frame anterior
    private Vector3 currentSpeed;    // Velocidade da faca

    void Start()
    {
        // Inicializar a posição anterior da faca
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calcular a velocidade atual da faca
        currentSpeed = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar se a faca entrou em contato com a carne
        if (other.CompareTag("meat"))
        {   
         
            
            // Verificar se a velocidade da faca é suficiente para considerar como corte
            if (currentSpeed.magnitude > sliceSpeedThreshold)
            {
                // Instanciar o pedaço de carne no ponto de spawn
                Instantiate(meatPiecePrefab, spawnPoint.position, spawnPoint.rotation);

                // Opcional: Desativar ou destruir o objeto original (carne)
                //Destroy(other.gameObject);

                // Opcional: Adicionar um som ou efeito de corte
                Debug.Log("Carne cortada!");
            }
        }
    }
}
