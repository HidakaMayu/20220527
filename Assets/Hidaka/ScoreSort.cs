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
    Dictionary<string, int> dictionary = new Dictionary<string, int>();

    void Start()
    {
        dictionary.Add("Apple", 120);
        dictionary.Add("Grape", 220);
        dictionary.Add("Spe", 20);
        dictionary.Add("Orange", 90);
        dictionary.Add("Orage", 10);
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
    

}
