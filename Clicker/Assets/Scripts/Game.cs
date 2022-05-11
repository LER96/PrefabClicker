using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    public Text ui;
    public List<int> shovel;
    public List<int> tree;
    public List<int> airgun;
    [SerializeField] private GameObject _shovelPf; 
    [SerializeField] private GameObject _treePf; 
    [SerializeField] private GameObject _airgunPf; 
    [SerializeField] private Transform _shovelPfHolder; 
    [SerializeField] private Transform _treePfHolder; 
    [SerializeField] private Transform _airgunPfHolder;
    [SerializeField] private List<Sprite> _multiplierImageList = new List<Sprite>();
    [SerializeField] private GameObject _clickHandGO;
    [SerializeField] private Image _clickHand;
    [SerializeField] private Animation _clickHandAnim;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Text LPS;


    private void Start()
    {
        Cursor.visible = false;
        _clickHand.sprite = _multiplierImageList[GameManager.multiplier-1];
    }
    public void Increment()
    {
        GameManager.leave += GameManager.multiplier;
    }

    [Obsolete]
    public void Buy(int num)
    {
        if (num == 4 && GameManager.leave >= 30)
        {
            GameManager.multiplier++;
            GameManager.leave -= 30;
            if (_multiplierImageList.Count > GameManager.multiplier - 1)
            _clickHand.sprite = _multiplierImageList[GameManager.multiplier-1];
        }

        if (num == 1 && GameManager.leave >= 25)
        {
            //GameManager.multiplier += 1;
            tree.Add(1);
            GameManager.leave -= 25;
            Instantiate(_treePf, _treePfHolder);
        }
        if (num == 2 && GameManager.leave >= 70)
        {
            //GameManager.multiplier += 10;
            shovel.Add(2);
            GameManager.leave -= 70;
            Instantiate(_shovelPf, _shovelPfHolder);
        }
        if (num == 3 && GameManager.leave >= 200)
        {
            //GameManager.multiplier += 100;
            airgun.Add(3);
            GameManager.leave -= 200;
            Instantiate(_airgunPf, _airgunPfHolder);
        }
        _particle.emissionRate = GameManager.leave / 100;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickHandAnim.Play();
        }
        _clickHandGO.transform.position = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y,2));
        GameManager.leave += shovel.Count* Time.fixedDeltaTime*0.1f;
        GameManager.leave += tree.Count * Time.fixedDeltaTime*0.3f;
        GameManager.leave += airgun.Count * Time.fixedDeltaTime*0.6f;
        LPS.text = (((shovel.Count * Time.fixedDeltaTime * 0.1f) + (tree.Count * Time.fixedDeltaTime * 0.3f) + (airgun.Count * Time.fixedDeltaTime * 0.6f))*100).ToString();
        ui.text = "Leaves: " + (int)GameManager.leave;
    }


}

