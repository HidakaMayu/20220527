using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Specialized;

public class ScoreSort : MonoBehaviour
{
    private int scores;
    private string names;

    [SerializeField] Text text;

    //OrderedDictionary dictionary = new OrderedDictionary();
    static public Dictionary<string, int> dictionary = new Dictionary<string, int>();

    void Start()
    {



        //dictionary.Add(" ", 0);
        //ã‹L”’l‚Æ•¶Žš—ñ‚Íˆê—á
        foreach (var s in dictionary.OrderByDescending(s => s.Value))
        {
            text.text += $"{s.Key}  {s.Value}point\n";
        }
        //IDictionaryEnumerator enumerator = dictionary.GetEnumerator(); //•À‚×‘Ö‚¦
        //while (enumerator.MoveNext())
        //{
        //    text.text += $"{enumerator.Key}  {enumerator.Value}point\n";
        //}
    }
    

    public void InputScore(string x, int y)
    {
        dictionary.Add(x, y);
        foreach (var s in dictionary.OrderByDescending(s => s.Value))
        {
            text.text += $"{s.Key}  {s.Value}point\n";
        }
    }

}
