using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class MusicScore
{
    public List<int> songid = new List<int>();
    public List<int> gameid = new List<int>();
    public List<string> songname = new List<string>();
    public List<int> type = new List<int>();
    public List<int> difficulty = new List<int>();
    public List<int> notes = new List<int>();
    public List<int> value1 = new List<int>();
    public List<string> value2 = new List<string>();

    /*    public int[] songid;   //曲ID
        public int[] gameid;   //度のゲーム?(今のところ全部0)
        public string[] songname; //曲名
        public int[] type;        //属性
        public int[] difficulty; //難易度
        public int[] notes;       //ノーツ数
        public int[] value1;       //ノーツ数
        public string[] value2;       //ノーツ数
        */
}