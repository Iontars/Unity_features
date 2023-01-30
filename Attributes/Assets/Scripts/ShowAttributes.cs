using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[DefaultExecutionOrder(-110)]
[RequireComponent(typeof(ShowAttributes))]
[DisallowMultipleComponent]
[AddComponentMenu("A_CustomEditor/ShowAttributes")]
[HelpURL("https://github.com/Iontars?tab=repositories")]
public class ShowAttributes : MonoBehaviour
{
    public enum GameState 
    { 
      [InspectorName("»грать")] play,
      [InspectorName("ќстановить")] stop 
    }

    [Header("Private float values")][Space(3)]
    [SerializeField] private float _speedIncrease;
    [SerializeField] private float _speedDecrease;
    [SerializeField] private float _speed;
    [Space(10)][SerializeField][Min(.1f)] private float _mass;
    [SerializeField][Min(.1f)] private float _ipulse;

    [Header("Public int values")][Space(3)]
    public List<int> valueStorage;
    [HideInInspector] public int currenrValue;

    [Header("Public string values")][Space(3)]
    [Multiline(5)]
    public string dataText;
    [Space(3)][SerializeField]public static string nameOfNextHeader;

    [Header("TextArea")][Space(3)]
    [TextArea(2, 4)]
    public string dataText_2;

    [Header("Game Objects")]
    public Text textGO;
    Rigidbody2D rigidbody;

    [Header("Speed of text typing")][Space(3)]
    [Range(0, 1)][Tooltip("скорость вывода текста на экран")] public float typeSpeed;

    [Header("Text color")][Space(3)]
    [ColorUsage(true,false)]
    [Tooltip("÷вет текст вывода нра экран")]
    public Color textColor;


    [Space(5)][Header("Text color")][Space(3)]
    public GameState gameState;

    ShowAttributes showAttributes;

    private void Awake()
    {
        showAttributes = GameObject.Find("Base")?.GetComponent<ShowAttributes>();
        if (GetComponent<Rigidbody2D>())
        {
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.mass = _mass;
        }
    }

    private void Start()
    {            
        StartCoroutine(nameof(TypeTextOn));   
    }

    IEnumerator TypeTextOn()
    {
        textGO.color = textColor;
        for (int i = 0; i < dataText.Length; i++)
        {
            yield return new WaitForSeconds(1f - typeSpeed);
            textGO.text += dataText[i];
        }
    }



}
