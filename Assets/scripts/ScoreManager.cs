using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float highscore=100;

    public void sethighscore(float score)
    {
        highscore += score;
        PlayerPrefs.SetFloat("Highscore", highscore); // Salva o highscore
        PlayerPrefs.Save(); // Garante que ele seja salvo
        Debug.Log("Highscore atualizado: " + highscore);
    }
    public float Gethighscore()
    {
        return highscore;
    }
}
