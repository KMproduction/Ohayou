using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class MusicResult
{
    public List<int> songid = new List<int>();
    public List<int> gameid = new List<int>();
    public List<int> score = new List<int>();
    public List<int> perfect = new List<int>();
    public List<int> great = new List<int>();
    public List<int> good = new List<int>();
    public List<int> FS = new List<int>();
    public List<int> miss = new List<int>();
    public List<int> maxcombo = new List<int>();
    public List<bool> FC = new List<bool>();
    public List<bool> clear = new List<bool>();
    public List<string> etc = new List<string>();
  //マニュアルで情報量増やせるなら可変にするかもね…
}