using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private Transform tfHolder;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private TextMeshProUGUI txtError;
    [SerializeField] private ScoreManager scoreManager;

    public Sprite[] sprites = new Sprite[100];
    public List<Card> cards = new List<Card>();
    private Action<Card> actionClickCard;
    private int numberMap;



    private Card card1;
    private Card card2;
    // Start is called before the first frame update
    void Start()
    {
        
        txtError.text = "";
        sprites = Resources.LoadAll<Sprite>("Icons");
        buttonPlay.onClick.AddListener(OnClickPlayButon);
    }

    // Update is called once per frame
    void Update()
    {

        //CheckImg();
    }


    private void Init()
    {
        scoreManager.RunTime(numberMap);

        List<int> randomIndexes = new List<int>();


        for (int i = 0; i < numberMap / 2; i++)
        {
            randomIndexes.Add(i);
            randomIndexes.Add(i);
        }

        ShuffleList(randomIndexes);


        for (int i = 0; i < numberMap; i++)
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
    private void OnClickPlayButon()
    {
        numberMap = int.Parse(inputField.text);

        if (CheckNumberMap(numberMap))
        {
            Init();
            inputField.gameObject.SetActive(false);
            buttonPlay.gameObject.SetActive(false);
            txtError.gameObject.SetActive(false);
            scoreManager. CountdownTimer(numberMap);
        }
    }

    private bool CheckNumberMap(int numberMap)
    {
        bool canUseNumberMap = true;
        if (numberMap == 0)
        {
            canUseNumberMap = false;
            txtError.text = "Khong duoc bang 0";
        }

        else if (numberMap < 0)
        {
            canUseNumberMap = false;
            txtError.text = "Khong duoc so am";
        }
        else if (numberMap % 2 != 0)
        {
            canUseNumberMap = false;
            txtError.text = "Khong duoc so le";
        }
        else if (numberMap > 30)
        {
            canUseNumberMap = false;
            txtError.text = "Khong duoc lon hon 30";
        }
        return canUseNumberMap;
    }
   
}
