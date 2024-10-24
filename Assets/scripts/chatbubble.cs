using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
public class chatbubble : MonoBehaviour
{
    string[] foods = {"passa me uma cerverja", "cota me ai uns bocados de carne para comer", "tem bolo do caco?", "ha para ai ainda cerveja?", "ha poncha?"};
    private SpriteRenderer backgroundSpriteRenderer;
    private SpriteRenderer iconSpriteRendere;
    private TextMeshPro textMeshPro;
    private void Awake(){
        backgroundSpriteRenderer = transform.Find("background").GetComponent<SpriteRenderer>();
        iconSpriteRendere = transform.Find("food").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text (TMP)").GetComponent<TextMeshPro>();
    }

    private void Start(){
        int xcount = Random.Range(0,4);

        Setup(foods[xcount]);
    }  

    private void Setup( string text){
        textMeshPro.SetText(text);

    }

}
