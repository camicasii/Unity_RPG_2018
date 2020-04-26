using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range
{
    float min;
    float max;
    public float Min{get{return min;}}
    public float Max{get{return max;}}
    public Range(float _min, float _max){
    min=_min;
    max=_max;
    }
    
}
