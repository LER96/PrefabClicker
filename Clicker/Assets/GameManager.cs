using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int leave;
    public static int multiplier;
    void Start()
    {
        multiplier = 1;
        leave = 0;
    }
}
