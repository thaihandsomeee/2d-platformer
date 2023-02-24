using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int count;
    [SerializeField] private Text itemText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            SoundManager.Instance.PlayCollectedSound();
            Destroy(collision.gameObject);
            count++;

            //Xu ly luu diem vao bo nho
            Prefs.currentScore = count;
            if (count > Prefs.bestScore) Prefs.bestScore = count;
            
            itemText.text = "" + count;
        }
    }
}
