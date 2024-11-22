using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public TextMeshPro highscoreText; // Arraste um Text UI do Canvas no Inspector

    void Start()
    {
        // Busca o highscore salvo e exibe
        float highscore = PlayerPrefs.GetFloat("Highscore", 0); // 0 é o valor padrão
        highscoreText.text = "Parabens novato tiveste um highscore de " + highscore.ToString("F2");
    }
}