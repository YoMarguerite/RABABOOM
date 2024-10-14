using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<StringValue> letters;

    public string display;

    List<GameObject> alreadyDisplay = new List<GameObject>();

    public float timeBetweenLetter = 0.5f;

    public float timeForSpace = 1;

    public float timeRespawn = 10;

    public float timeKill = 60;


    void Start()
    {
        StartCoroutine(Generation());
    }

    IEnumerator Generation()
    {
        while (true)
        {
            var word = TakeLetters();

            foreach (var letter in word)
            {
                if (letter != null)
                {
                    var l = Instantiate(letter, transform);
                    alreadyDisplay.Add(l);
                    StartCoroutine(KillLetter(l));
                    yield return new WaitForSeconds(timeBetweenLetter);
                }
                else
                {
                    yield return new WaitForSeconds(timeForSpace);
                }
            }
            yield return new WaitForSeconds(timeRespawn);
        }
    }

    IEnumerator KillLetter(GameObject letter)
    {
        yield return new WaitForSeconds(timeKill);
        Destroy(letter);
    }

    List<GameObject> TakeLetters()
    {
        List<GameObject> list = new List<GameObject>();

        foreach(char c in display)
        {
            StringValue sv = letters.Find((l) => Char.ToLower(l.value) == Char.ToLower(c));

            if(sv != null)
                list.Add(sv.gameObject);
            else list.Add(null);
        }

        return list;
    }
}
