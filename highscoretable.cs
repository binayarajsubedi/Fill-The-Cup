using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highscoretable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private void Awake()
    {
        entryContainer = transform.Find("Highscore entry container");
        entryTemplate = entryContainer.Find("Highscore entry template");
        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 20f;
        for (int i=0; i<10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
