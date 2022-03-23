using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Text ui;
public void Increment()
    {
        GameManager.leave += GameManager.multiplier;
    }

    public void Buy(int num)
    {
        if (num == 1 && GameManager.leave >= 25)
        {
            GameManager.multiplier += 1;
            GameManager.leave -= 25;
        }
        if (num == 2 && GameManager.leave >= 40)
        {
            GameManager.multiplier += 10;
            GameManager.leave -= 40;
        }
        if (num == 3 && GameManager.leave >= 80)
        {
            GameManager.multiplier += 100;
            GameManager.leave -= 80;
        }
    }

    public void Update()
    {
        ui.text = "Leaves: " + GameManager.leave;
    }
}

