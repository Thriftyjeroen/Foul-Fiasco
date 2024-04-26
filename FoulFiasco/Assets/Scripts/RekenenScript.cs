using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RekenenScript : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text answerText;
    List<string> sum = new List<string>();
    bool operatorFound = false;
    string sSum = "";
    bool correctValue;
    string answer = "";
    List<string> input = new List<string>();
    string userAnswer = "";
    // Start is called before the first frame update
    void Start()
    {
        SumGenerator();
        text.text = sSum;
        CalculationOrder();
        float temperarly = float.Parse(sum[0]);
        print(temperarly);
        answer = Mathf.Round(temperarly).ToString();
        print(answer);
    }
    void SumGenerator()
    {
        for (int times = UnityEngine.Random.Range(2, 8); times > 0; times--)
        {
            sum.Add(UnityEngine.Random.Range(1, 101).ToString());
            print(sum.Last());
            switch (UnityEngine.Random.Range(1, 5))
            {
                case 1:
                    sum.Add("*");
                    break;
                case 2:
                    sum.Add("/");
                    break;
                case 3:
                    sum.Add("+");
                    break;
                case 4:
                    sum.Add("-");
                    break;
                default:
                    print("er is iets mis gegaan in rekenenScript in SumGenerator Method");
                    break;
            }
        }
        sum.RemoveAt(sum.Count() - 1);
        foreach (string sumValue in sum)
        {
            sSum += " " + sumValue;
        }
    }
    void CalculationOrder()
    {
        int lokation;
        do//de do-while loop runt minimaal 1 keen en zolang de contie in de statement van while staat word de code in de loop weer geloopt
        {
            operatorFound = false;// er kan meerdere malen door een lijst heen geloopt worden. voor elke keer moet deze variabele wel weer op false gezet worden
            lokation = 0;// de lokatie word  elke keer weer op 0 gezet aangezien je anders door gaat tellen terwijl er weer vanaf het begin weer word geloopt, maar om de lokatie van de operator te achterhalen moet de waarde van deze lokatie het zelfde zijn als hoeveelste waarde de foreach loop is, anders is de lokatie dus buiten de lengte van de lijst wat dus niet kan.
            foreach (string value in sum)//er word door de lijst met waardes heen geloopt
            {
                switch (value)//hier word gekeken of de waarde een operator is
                {
                    case "*":
                    case "/":
                    case "%":
                        operatorFound = true;//als er een operator gevonden is die gezocht word word de operatorFound op true gezet
                        break;
                    default:
                        break;
                }
                if (!(operatorFound))//zo lang er geen operator is gevonden word de lokatie met 1 verhoogd
                {
                    lokation++;//je zou zeggen als de lokatie met 1 groter word totdat de operator word gevonden dat je er dan 1 naast zit, maar het lokaliseren van een waarde in een list begint op 1, waardoor je dan gelijk de waarde hebt die vertelt welke operator het  is
                }
            }
            Thread.Sleep(100);
            if (operatorFound)//als er een operator is gevonden word deze code gerunt
            {
                Calculate(lokation);//hier word de Calculate method opgeroepen en word de lokatie van de operator mee gegeven
            }
        } while (sum.Contains("*") || sum.Contains("/") || sum.Contains("%"));
        do// dit is exact de zelfde code als in de loop hierboven, maar dan met een andere method die word opgeroepen en worden er andere operators gezogt, ja ik kon dat allemaal in 1 keer doen, maar er bestaat iets als de reken volg orde, dan doe je eerst de berekeningen van *,/,% en dan de berekeningen van + en -. Dus door die arpart te doen achter elkaar houd de aplicatie zich aan de reken volgorde
        {
            operatorFound = false;
            lokation = 0;
            foreach (string value in sum)
            {
                switch (value)
                {
                    case "+":
                    case "-":
                        operatorFound = true;
                        break;
                    default:
                        break;
                }
                if (!(operatorFound))
                {
                    lokation++;
                }
            }
            Thread.Sleep(100);
            if (operatorFound)
            {
                CalculateCountingOperators(lokation);
            }
        } while (sum.Contains("+") || sum.Contains("-"));
    }
    void CalculateCountingOperators(int pLokation)// je ziet een p staan voor lokation, en dat hout in dat de variabele een parameter van lokation is, dus die ontvangt de waarde van lokation. verder is deze method exact het zelfde als de Calculate method, maar dan voor + en -
    {
        correctValue = true;
        if (sum[pLokation] == "+")
        {
            sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) + Convert.ToDouble(sum[pLokation + 1])).ToString();
        }
        else if (sum[pLokation] == "-")
        {
            sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) - Convert.ToDouble(sum[pLokation + 1])).ToString();
        }
        else
        {
            correctValue = false;
        }
        if (correctValue)
        {
            sum.RemoveAt(pLokation - 1);
            sum.RemoveAt(pLokation);
        }
    }
    void Calculate(int pLokation)// in deze method worden de *,/,% berekent met de meegegeven waarde
    {
        correctValue = true;//de correctValue word op true gezet aangezien de waarde nu (als het goed is nu klopt voor de berekening)
        if (sum[pLokation] == "*")//hier word gekeken of de waarde * (vermedigvuldig teken) is en worden de 2 aan grenzende waardes berekent. hieronde de uitleg in detail met | alsgrens voor elk stukje van de code
        {// we willen niet dat elke    |de waarde voor de * om gezet naar een   |de waarde na de * die ook word omgezet naar| natuurlijk is de type 
         // keer deze code word gerunt |data type die met comma getallen om     |een type die comma getallen kan verwerken..|Double niet de zelfde als 
         // met de zelfde waardes,     |kan gaan en die word vermedigvuldigd    |                                           |een string zoals die in de 
         // dus die worden vervangen   |met...                                  |                                           |list, daarom word na de 
         // met het andwoord van deze  |                                        |                                           |berkening het andwoord 
         // berekening                 |                                        |                                           |omgezet naar een string
            sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) * Convert.ToDouble(sum[pLokation + 1])).ToString();
        }
        else if (sum[pLokation] == "%")//wat hierboven gebeurd word ook hier gedaan, maar inplaats van vermedigvuldigen is het modulo
        {
            sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) % Convert.ToDouble(sum[pLokation + 1])).ToString();
        }
        else if (sum[pLokation] == "/")// ook hier word het zelfde gedaan, maar dan worden de waardes met elkaar gedeelt
        {
            sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) / Convert.ToDouble(sum[pLokation + 1])).ToString();
        }
        else//er is ook een kans dat het mis kan gaan, dan word de gebruiker erover geinvormeer
        {
            correctValue = false;// hier word de variabele correcteValue op false gezet aangezien er inderdaat niet de juiste waarde is gevonden op de een of andere manier
        }
        if (correctValue)// als de waarde correct is worden ook de andere waardes weg gehaald aangezien die al berekent zijn. kwa code kan het gek uit zien, ik leg het je daar dan uit
        {
            sum.RemoveAt(pLokation - 1);//eerst word de waarde voor het antwoord verwijderd,
            sum.RemoveAt(pLokation);//daarna de waarde op de lokatie van het antwoord, maar dat klinkt gek, maar het klopt wel. aangezien de waarde voor het antwoord is verwijderd worden alle waardes met 1 naar voren geschoven. dus het antwoord komt op de oude lokatie van de waarde voor het antwoord, en de waarde na het antwoord komt op de oude lokatie van het antwoord en door de lokatie van het oude antwoord te verwijderen verwijderen we de waarde achter het antwoord.
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)) ChangeList("0");
        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) ChangeList("1");
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) ChangeList("2");
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) ChangeList("3");
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) ChangeList("4");
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) ChangeList("5");
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) ChangeList("6");
        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) ChangeList("7");
        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) ChangeList("8");
        else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) ChangeList("9");
        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus)) ChangeList("-");
        else if (Input.GetKeyDown(KeyCode.Backspace)) ChangeList("");
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PrintInput();
            if (userAnswer == answer)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
    void ChangeList(string value)
    {
        if (value == "") input.RemoveAt(input.Count() - 1);
        else input.Add(value);
        PrintInput();
    }
    void PrintInput()
    {
        userAnswer = "";
        if (input != null)
        {
            foreach (string number in input)
            {
                userAnswer += number;
            }
        }
        else userAnswer = "";
        answerText.text = userAnswer;
    }
}
