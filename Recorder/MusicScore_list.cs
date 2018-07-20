using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class MusicScore_list
{
    public List<int> songid = new List<int>();
    public List<int> gameid = new List<int>();
    public List<string> songname = new List<string>();
    public List<int> type = new List<int>();
    public List<int> difficulty= new List<int>();
    public List<int> notes = new List<int>();
    public List<int> value1 = new List<int>();
    public List<string> value2 = new List<string>();
}