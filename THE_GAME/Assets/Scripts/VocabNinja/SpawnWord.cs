using UnityEngine;
using System.Collections;

public class SpawnWord : MonoBehaviour {

    public GameObject wordPrefab;
    public GameObject missingPrefab;
    public GameObject missing_let;
    public Sprite[] letterSprites;
    public Transform[] WordSpawnPoints;
    public string[] words = new string[]{"bad", "bed", "dead"};
    public char[] key = new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
    public Sprite missing_letter;
    public static char[] chars;
    //public ArrayList StringLetters;
    public static int charLength;
    public int randomCharIndx;
    public int tempIndx;
    public int tempIndx2;
    public int tempIndx3;
    public int tempIndx4;
    public GameObject missing3;

    // Use this for initialization
    void Start () {

        MakeWord();
    }
	
    public void MakeWord()
    {

        string letterName;
        int wordIdx = Random.Range(0, words.Length);
        string selected_word = words[wordIdx];

   //     Debug.Log("Selected Word is " + selected_word);
        chars = selected_word.ToCharArray();
        charLength = chars.Length;


        for (int i = 0; i < charLength; i++)
        {
            for (int j = 0; j < 26; j++)
            {

                if (chars[i] == key[j])
                {
                    Sprite letterSprite = letterSprites[j];
                    letterName = letterSprite.name;
                    GameObject newLetter = (GameObject)Instantiate(wordPrefab, WordSpawnPoints[i].position, Quaternion.identity);
                    newLetter.name = letterName;
                    newLetter.GetComponent<SpriteRenderer>().sprite = letterSprite;
                }
            }
        }

        if (charLength == 3)
        {
            MissingLetter();
        }
        else if (charLength == 4 || charLength == 5)
        {
            MissingLetter();
            tempIndx = randomCharIndx;
            MissingLetter();
        }
        else if (charLength == 6 || charLength == 7)
        {
            MissingLetter();
            tempIndx = randomCharIndx;
            MissingLetter();
            tempIndx2 = randomCharIndx;
            MissingLetter();
        }
        else if (charLength == 8)
        {
            MissingLetter();
            tempIndx = randomCharIndx;
            MissingLetter();
            tempIndx2 = randomCharIndx;
            MissingLetter();
            tempIndx3 = randomCharIndx;
            MissingLetter();
        }
        else if (charLength == 9 || charLength == 10)
        {
            MissingLetter();
            tempIndx = randomCharIndx;
            MissingLetter();
            tempIndx2 = randomCharIndx;
            MissingLetter();
            tempIndx3 = randomCharIndx;
            MissingLetter();
            tempIndx4 = randomCharIndx;
            MissingLetter();
        }

    }

    //Used to display the question box for the missing letters
    public void MissingLetter()
    {
        randomCharIndx = Random.Range(0, charLength);

        //while loop to prevent the missing letter from appearing in the same spot
        while (tempIndx == randomCharIndx || tempIndx2 == randomCharIndx || tempIndx3 == randomCharIndx || tempIndx4 == randomCharIndx)
        {
            randomCharIndx = Random.Range(0, charLength);
        }
        missing_let = (GameObject)Instantiate(missingPrefab, WordSpawnPoints[randomCharIndx].position, Quaternion.identity);
        missing_let.name = missing_letter.name;
        missing_let.GetComponent<SpriteRenderer>().sprite = missing_letter;
    }


    public static void CorrectLetter(string correct)
    {
        SpawnWord instance = new SpawnWord();

        Debug.Log("Inside CorrectLetter " + correct);

        for (int k = 0; k < charLength; k++)
        {
            if (correct == chars[k].ToString().ToUpper())
            {
                Debug.Log("wwwwwww");
                instance.missing3.SetActive(false);
            }
        }


    }

}
