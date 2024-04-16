using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Button btnCard;
    [SerializeField] private Image imgIcon;

    public int id;
    private bool isOpened;
    private Sprite sprite;
    
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
        if (isOpened)
        {
            imgIcon.gameObject.SetActive(false);
            isOpened = false;
        }
        else { imgIcon.gameObject.SetActive(true);
            isOpened = true;
        }
    }
    public void InitData(int id, Sprite sprite)
    {
        this.id = id;
        imgIcon.sprite = sprite; 
    }
}
