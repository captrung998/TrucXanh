using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Sprites : MonoBehaviour
{

    public bool autoTiling;
    [SerializeField] private List<Img> imgs = new List<Img>();
    [SerializeField] private List<Sprite> spritesList = new List<Sprite>();
    

    [SerializeField] private Sprite img1;
    [SerializeField] private Sprite img2;
    [SerializeField] private Sprite img3;
    [SerializeField] private Sprite img4;
    [SerializeField] private Sprite img5;



    private void Start()
    {
        AddSpriteToList();
        AddIdtoSprites();
        SpawnSprites();


    }
    private void AddSpriteToList()
    {
        spritesList = new List<Sprite>();
        spritesList.Add(img1);
        spritesList.Add(img2);
        spritesList.Add(img3);
        spritesList.Add(img4);
        spritesList.Add(img5);
    }

    private void AddIdtoSprites()
    {
        for (int i = 0; i < spritesList.Count; i++)
        {
            Img img = new Img();
            img.sprite = spritesList[i];
            img.id = i + 1;
            imgs.Add(img);
        }
    }

    private void SpawnSprites()
    {
        Vector3 pos = new Vector3(-5, 0, 1);
        for (int i = 0; i < imgs.Count; i++)
        {
            GameObject newSprite = new GameObject("Sprite" + (i + 1));

            //Position
            pos = new Vector3(pos.x + 2, 0, 1); ;
            newSprite.transform.position = pos;

            //Tag
            newSprite.tag = "Card";

            //Add Script
            CheckClick checkClick = newSprite.AddComponent<CheckClick>();
            
            //Add Sprite
            SpriteRenderer spriteRenderer = newSprite.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = imgs[i].sprite;
           

            //Add Rigidbody
            Rigidbody2D rigidbody2 = newSprite.AddComponent<Rigidbody2D>();
            rigidbody2.bodyType = RigidbodyType2D.Static;

            //Add Collider
            Collider2D collider2 = newSprite.AddComponent<BoxCollider2D>();
        }
    }


}
