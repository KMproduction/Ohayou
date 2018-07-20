using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;


/*
 * 垂直モード
 * 15 30 45 60 75 90 105
 * (7個)
 * 水平モード
 * 
 * (14個)
 * 
 * 各々2回ずつ
    */
public static class Sort
{
    /// <summary>
    /// ランダムに並び替えた新しい配列を返します
    /// </summary>
    public static T[] Shuffle<T>(this T[] array)
    {
        var length = array.Length;
        var result = new T[length];
        Array.Copy(array, result, length);

        var random = new Random();
        int n = length;
        while (1 < n)
        {
            n--;
            int k = random.Next(n + 1);
            var tmp = result[k];
            result[k] = result[n];
            result[n] = tmp;
        }
        return result;
    }
}