using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveEffect : MoveEffect
{
    private static int counter = 0;

    private void Start()
    {
        folowTime = ++counter;
        Color color = msr.color;
        color.a = tsr.color.a - (0.2f * counter);
        int plu = 50 / 255;
        color.r = tsr.color.r - plu;
        color.g = tsr.color.g - plu;
        color.b = tsr.color.b - plu;
        msr.color = color;
    }
}
