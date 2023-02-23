using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
