using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Sprite defaultSprite, pressedSprite;
    [SerializeField] private AudioSource clicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked.Play();
        img.sprite = pressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.sprite = defaultSprite;
    }

    public void StartGame()
    {
        CreateText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CreateText()
    {
        //Path of file
        string path = Application.dataPath + "/Log.txt";
        //Create file if file doesnt exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Log: \n\n");
        }
        
        string content = "Login date: " + System.DateTime.Now + "\n";
        File.AppendAllText(path, content);
    }
}
