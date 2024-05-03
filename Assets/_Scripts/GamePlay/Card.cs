using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Button btnCard;
    [SerializeField] private Image imgIcon;
    [SerializeField] private CanvasGroup cgCard;
    public int id;
    public bool isOpened;
    private Sprite sprite;
    private Action<Card> action;


    // Start is called before the first frame update
    void Start()
    {
        btnCard.onClick.AddListener(OnClickCard);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnClickCard()
    {
        action.Invoke(this);        
    }
    public void InitData(int id, Sprite sprite, Action<Card> onClickCard)
    {
        this.id = id;
        imgIcon.sprite = sprite;
        this.action = onClickCard;

    }
    public void FlipDown(bool isFlip)
    {
        imgIcon.gameObject.SetActive(isFlip);
    }

    public void HideCard()
    {
        cgCard.alpha = 0;
        cgCard.interactable =false;
    }

    public void ShowCard()
    {
        cgCard.alpha = 1;
        cgCard.interactable = true;
        imgIcon.gameObject.SetActive(true);
    }
}
