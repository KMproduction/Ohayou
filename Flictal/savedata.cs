using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class savedata
{
    public int _jiki;
    public bool _sound;
    public bool _BGM;
//    public bool music;//
    //上位の記録
    public int[] _bestscore;//上位スコア,10件まで bestscore[1]が最高の三角
    public int[] _maxcombo;//コンボ数
    public int[] _sv_level;//最大レベル
    public float[] _lefttime;//残された時間
    public string _date;//クリア日付
                        //  public string ;//
    public int _jikicount;
    public List<bool> _jikiflag = new List<bool>();
    public List<int> _list1;
    public List<int> _list2;
    public List<int> _list3;
    public List<int> _list4;
    public List<int> _list5;
    public int _yobi1;
    public int _yobi2;
    public int _yobi3;
    public int _yobi4;
    public int _yobi5;
    public string _name;
    public string _yobi6;
    public string _yobi7;
}