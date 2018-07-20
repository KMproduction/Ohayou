using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class MusicListDX
{
    public int _songid;
    public int _gameid;
    public int _score;
    public int _perfect;
    public int _great;
    public int _good;
    public int _FS;
    public int _miss;
    public int _maxcombo;
    public bool _FC;
    public bool _clear;
    public int _combo;
    public string _etc;
   
    public MusicListDX(int songid,int gameid,int score,int perfect,int great,int good,int FS,int miss,int maxcombo,
        bool FC,bool clear,int combo)//,string etc)
    {
        _songid = songid;
        _gameid = gameid;
        _score = score;
        _perfect = perfect;
        _great = great;
        _good = good;
        _FS =FS;
        _miss = miss;
        _maxcombo = maxcombo;
        _FC = FC;
        _clear = clear;
        _combo = combo;
       // etc =  _etc;
    }
    
}