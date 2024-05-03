using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int totalCard = 24;
    [SerializeField] private int countCard;
    [SerializeField] private Transform tfHolder;

    public Sprite[] sprites = new Sprite[100];
    public List<Card> cards = new List<Card>();
    private Action<Card> actionClickCard;
    private ScoreManager scoreManager;


    private Card card1;
    private Card card2;
    // Start is called before the first frame update
    void Start()
    {

        sprites = Resources.LoadAll<Sprite>("Icons");
        Init();
    }

    // Update is called once per frame
    void Update()
    {

        //CheckImg();
    }


    private void Init()
    {

        List<int> randomIndexes = new List<int>();


        for (int i = 0; i < totalCard / 2; i++)
        {
            randomIndexes.Add(i);
            randomIndexes.Add(i);
        }

        ShuffleList(randomIndexes);


        for (int i = 0; i < totalCard; i++)
        {
            var card = Instantiate(cardPrefab, tfHolder);
            int id = randomIndexes[i];
            card.InitData(id, sprites[id], OnClickCard);
            cards.Add(card);
        }
    }

    // Phương thức để trộn một danh sách
    private void ShuffleList<mixList>(List<mixList> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            mixList value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }



    private void test()
    {
        Debug.Log("Debug");
    }
    private void OnClickCard(Card card)
    {
        StopAllCoroutines();
        StartCoroutine(CheckMatching(card));
    }
    private IEnumerator CheckMatching(Card card)
    {
        if (card1 == null)
        {
            card1 = card;
            card1.ShowCard();
            yield break;
        }
        if (card2 == null)
        {
            card2 = card;
            card2.ShowCard();
        }
        yield return new WaitForSeconds(0.8f);

        if (card1.id == card2.id && card2 != card1)
        {
            card1.HideCard();

            card2.HideCard();

            ScoreManager.AddScore(1);
        }
        else
        {
            card1.FlipDown(false);
            card2.FlipDown(false);

        }
        card1 = null;
        card2 = null;
    }


}
