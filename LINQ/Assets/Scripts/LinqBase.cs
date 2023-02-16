using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqBase : MonoBehaviour
{
    private int[] _numbers;
    private string[] _names;
    private int[] _resultArray;

    void Start()
    {
        _numbers = new[] { 2, 1, 10, 0, -3, 100 };
        _names = new[] { "Anim", "Anim2", "Anom", "Atom", "Anim", "Ar" };
        _resultArray = new int [_numbers.Length];
        LinqSort();
        LinqSortText();

        int x = 49;
        if (x is (> 1 or 0) and < 50)
        {
            print("done");
        }

    }

    private void LinqSort()
    {
        var resultArr = from n in _numbers where n is (> 0 or 0) and < 50 select n;

        _resultArray = resultArr as int[] ?? resultArr.ToArray();
        foreach (var item in _resultArray)
        {
            print(item);
        }
    }

    private void LinqSortText()
    {
        var resultArr = from item in _names where item.Contains("Anim") select item;
        foreach (var item in resultArr)
        {
            print(item);
        }
    }


    void Update()
    {
        
    }
}
