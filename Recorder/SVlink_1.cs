using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SVlink_1 : MonoBehaviour {

    public ScrollRect mainScrollRect;
    public ScrollRect tateScrollRect;
    public ScrollRect yokoScrollRect;

    // Use this for initialization
    public void tateSVpositionChanged()
    {
        mainScrollRect.verticalNormalizedPosition = tateScrollRect.verticalNormalizedPosition;
    }
    public void yokoSVpositionChanged()
    {
        mainScrollRect.horizontalNormalizedPosition = yokoScrollRect.horizontalNormalizedPosition;
    }

    public void mainSVpositionChanged()
    {
        tateScrollRect.verticalNormalizedPosition = mainScrollRect.verticalNormalizedPosition;
        yokoScrollRect.horizontalNormalizedPosition = mainScrollRect.horizontalNormalizedPosition;
    }

}
