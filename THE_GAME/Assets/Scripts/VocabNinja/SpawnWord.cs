using UnityEngine;
using System.Collections;

public class SpawnWord : MonoBehaviour {

    public GameObject wordPrefab;
    public GameObject missingPrefab;
    public GameObject missing_let;
    public Sprite[] letterSprites;
    public GameObject[] missingList;
    public Transform[] WordSpawnPoints;
    public string[] words = new string[]{"bad", "bed", "dead"};
    public char[] key = new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
    public Sprite missing_letter;
    public char[] chars;
    //public ArrayList StringLetters;
    public static int charLength;
    public int randomCharIndx;
    public int tempIndx;
    public int tempIndx2;
    public int tempIndx3;
    public int tempIndx4;
    public GameObject missing0;
    public ArrayList covered;
    public static string sliced;
    public ArrayList hey;
    GameObject player;
    HealthManager healthManager;
    

    
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        healthManager = player.GetComponent<HealthManager>();

        foreach (GameObject g in missingList)
        {
            Debug.Log("Start");
            g.SetActive(false);
            Debug.Log("Start222222");
        }
   //     missing0 = GameObject.FindGameObjectWithTag("missing0");
    //    missing0.SetActive(false);


        MakeWord();
    }
	
    public void MakeWord()
    {
        covered = new ArrayList();
        hey = new ArrayList();
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
                    hey.Add(newLetter);
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

        //string indxx = randomCharIndx.ToString();
      //  GameObject.FindGameObjectWithTag("missing" + indxx);
        missingList[randomCharIndx].SetActive(true);
        covered.Add(randomCharIndx);
    }



    public void CorrectLetter(string letter)
    {
        bool inWord = false;
        int num;
        Debug.Log("Correct LEtter: " + letter);
        //string correct = sliced;



        for (int k = 0; k < charLength; k++)
        {
            if (letter == chars[k].ToString().ToUpper())
            {
                inWord = true;
                num = k;
                if (covered.Contains(k))
                {
                    Debug.Log("Inside CorrectLetter " + letter);
                    missingList[k].SetActive(false);
                    covered.Remove(k);
                }

            }

        }
        if (!inWord)
            healthManager.takeDamage();
    }


    void Update()
    {
        if (covered.Count == 0)
        {
            ScoreManager.score += 10;
            foreach (GameObject g in hey)
            {
                Destroy(g);
            }
            MakeWord();
        }
    }
}
