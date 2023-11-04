using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiftCollector : MonoBehaviour
{
    public TextMeshProUGUI giftText;
    public int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        giftText.SetText(score.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("gift")){
            score += 1;
            Destroy(collision.gameObject);
        }
    }
}
