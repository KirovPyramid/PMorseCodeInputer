using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CodeTest : MonoBehaviour
{
    public AudioSource SoundManager;    //用來播聲音的SoundManager
    public AudioClip Dot;               //摩斯密碼-點(Dot)
    public AudioClip Dash;              //摩斯密碼-劃(Dash)
    public Text text;                   //UI放打出來的字

    private string nowInput;            //現在輸入
    //private string theOutput;         //輸出(沒用到ㄏㄏ)

    //private bool reset;
    private bool resetCountStart;       //輸入重設倒數是否開始

    private float resetTime = 0.5f;     //輸入重設時間(不按按鈕0.5秒後就會去判斷輸入，給出輸出)
    private float resetCounter;         //輸入後目前經過幾秒

    public Dictionary<char, string> MorseCodeDictionary = new Dictionary<char, string>()    //摩斯密碼本
    {
        {'A' , ".-"},
        {'B' , "-..."},
        {'C' , "-.-."},
        {'D' , "-.."},
        {'E' , "."},
        {'F' , "..-."},
        {'G' , "--."},
        {'H' , "...."},
        {'I' , ".."},
        {'J' , ".---"},
        {'K' , "-.-"},
        {'L' , ".-.."},
        {'M' , "--"},
        {'N' , "-."},
        {'O' , "---"},
        {'P' , ".--."},
        {'Q' , "--.-"},
        {'R' , ".-."},
        {'S' , "..."},
        {'T' , "-"},
        {'U' , "..-"},
        {'V' , "...-"},
        {'W' , ".--"},
        {'X' , "-..-"},
        {'Y' , "-.--"},
        {'Z' , "--.."},
        {'0' , "-----"},
        {'1' , ".----"},
        {'2' , "..---"},
        {'3' , "...--"},
        {'4' , "....-"},
        {'5' , "....."},
        {'6' , "-...."},
        {'7' , "--..."},
        {'8' , "---.."},
        {'9' , "----."},
        {'.' , ".-.-.-"},
        {':' , "---..."},
        {',' , "--..--"},
        {';' , "-.-.-."},
        {'?' , "..--.."},
        {'=' , "-...-"},
        {'/' , "-..-."},
        {'!' , "-.-.--"},
    };


    void Start()
    {
        resetCounter = 0;       //輸入重設時間
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))                        //按下Z(點)
        {
            SoundManager.clip = Dot; SoundManager.Play();       //播聲音
            nowInput += ".";                                    //現在輸入+一個點
            Debug.Log(nowInput);                                //印出現在的輸入
            resetCounter = 0;                                   //歸零重置計時器
            resetCountStart = true;                             //重置計時器倒數開始
        }
        if (Input.GetKeyDown(KeyCode.X))                        //按下X(劃)
        {
            SoundManager.clip = Dash; SoundManager.Play();      //播聲音
            nowInput += "-";                                    //現在輸入+一個劃
            Debug.Log(nowInput);                                //印出現在的輸入
            resetCounter = 0;                                   //歸零重置計時器
            resetCountStart = true;                             //重置計時器倒數開始
        }

        ResetandOutputMorseCode();                              //重置計時器函式
    }

    void ResetandOutputMorseCode()                                              //重置計時器函式
    {
       
        if (resetCountStart == true)                                                                //如果重置計時器倒數開始
        {
            resetCounter += Time.deltaTime;                                                         //重置計時器累加經過時間

            if (resetCounter > resetTime)                                                           //如果重置計時器經過時間大於重設時間(0.5秒)
            {
                if (MorseCodeDictionary.ContainsValue(nowInput))                                    //如果輸入有對應到字典裡的摩斯密碼

                {
                    text.text+=(MorseCodeDictionary.FirstOrDefault(c => c.Value == nowInput).Key);  //UI字框加上摩斯密碼對應的字母、數字或符號
                }

                resetCounter = 0;                               //歸零重置計時器
                nowInput = "";                                  //重置輸入
                Debug.Log("ClearCode!");                        //印出"清除輸入!"
                resetCountStart = false;                        //重置計時器倒數關閉
            }
        }
    }
}
