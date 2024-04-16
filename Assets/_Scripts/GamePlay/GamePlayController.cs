using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int totalCard;
    [SerializeField] private int countCard;
    [SerializeField] private Transform tfHolder;

    public Sprite[] sprites = new Sprite[100];
    public List<Card> cards = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Icons");
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        CheckImg();
    }
    private void Init()
    {
        for (int i = 0; i < totalCard; i++)
        {
            var card = Instantiate(cardPrefab, tfHolder);
            int id = i / 2;
            card.InitData(id, sprites[id]);
            cards.Add(card);
        }
    }

    private void CheckImg()
    {
        Card firstCard = null;
        Card secondCard = null;

        foreach (var card in cards)
        {
            if (card.isOpened)
            {
                if (firstCard == null)
                {
                    firstCard = card;
                    Debug.Log(firstCard.id);
                }
                else
                {
                    secondCard = card;
                    Debug.Log(secondCard.id);
                    break; // We found two flipped cards, no need to continue the loop
                }
            }
        }

        if (firstCard != null && secondCard != null)
        {
            if (firstCard.id == secondCard.id)
            {
                // Cards match, do something
                Debug.Log("add");
                
            }
            else
            {
                // Cards don't match, flip them back
                Debug.Log("sub");
             
                firstCard.FlipDown();
                secondCard.FlipDown(); 

            }
        }
    }


}
