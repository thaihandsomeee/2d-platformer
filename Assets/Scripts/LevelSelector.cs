using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
    public int level;
    [SerializeField] private AudioSource clicked;

    public void OpenScene()
    {
        clicked.Play();
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
