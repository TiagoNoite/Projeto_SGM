using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAxis : MonoBehaviour
{
   public float fixedHeight = 1.6f; // Defina a altura desejada para a câmera

    void LateUpdate()
    {
        // Mantém a posição X e Z atuais, mas fixa o Y na altura desejada
        transform.position = new Vector3(transform.position.x, fixedHeight, transform.position.z);
    }
}
