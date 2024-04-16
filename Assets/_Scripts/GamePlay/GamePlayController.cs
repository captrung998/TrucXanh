using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int totalCard;
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
}
