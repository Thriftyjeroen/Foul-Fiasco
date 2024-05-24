using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RekenenScript : MonoBehaviour
{
    //in this field will be a bunch of variables decleared that will be used in this scirpt.
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_InputField inputField;
    List<string> sum = new List<string>();
    bool operatorFound = false;
    string sSum = "";
    bool correctValue;
    string answer = "";
    void Start()//when the sene start with this script this code will run
    {
        SumGenerator();//here will be a sum generated
        text.text = sSum;//the text of the sum will be displayed on the text from TextMeshPro(TMP)
        CalculationOrder();//the sum needs to be calculated bevore the user can give input.
        float temperarly = float.Parse(sum[0]);//i knew that some anser could be a decimal. so i parsed it to a temperarly variable to use the answer more than once 
        print(temperarly);//to make it possible for the developer to check the value (just in case something go's wrong) i made the temperarly value print in the console
        answer = Mathf.Round(temperarly).ToString();//the round funktion/method only accept float as a arguments, so i had to parse the answer of the sum to a float. and the answer is a string so i used a ToString method for that.(yes i could use the float or int as a answer, bud sinds the user can use every butten as a answer i think it is smarter to use a string to compare the values later
        print(answer);//for testing purposes it is way faster to get the answer already printed in the console insted of calculating it first
    }
    void SumGenerator()
    {
        for (int times = UnityEngine.Random.Range(2, 5); times > 0; times--)//the sum will have a random length, from 2 values to 4 values
        {
            sum.Add(UnityEngine.Random.Range(1, 101).ToString());//the sum will get a random number as a string
            print(sum.Last());//for testing purpose the generated number will be printed to the console
            switch (UnityEngine.Random.Range(1, 5))//based on the random number a opperator will be chosen and added to the sum
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
        sum.RemoveAt(sum.Count() - 1);//if the sum is generated there will be a opperator at the end witch would break the application, so i remove it from the sum
        foreach (string sumValue in sum)//i wand the sum beïng shown in the aplication when it is generated, so i loop trough the sum and add it to the sSum with a space between them to make a variable that cani printed in the TMP text
        {
            sSum += " " + sumValue;
        }
    }
    void CalculationOrder()
    {
        int lokation;
        do//the do-while loop runs at least once and as long the contion in the while statement is true, the code in the loop will run again
        {
            operatorFound = false;//it is possible that there is more than one opperator in the operator, so if this loop tries to search for another operator it needs this bool on flase because it is not found jet
            lokation = 0;// the location is reset to 0 every time, otherwise you will continue counting while start searching again from the beginning which means that the next lokation that is found will be outside of the indext of the sumlist, wich is not possible. and the variable will let the script later know where the operator is
            foreach (string value in sum)//there will be looped trough the sum list
            {
                switch (value)//here will be checked if the value is a opperator 
                {
                    case "*":
                    case "/":
                    case "%":
                        operatorFound = true;//if the opperator is found the variable will be set true to let the script later know to run or don't run certain code
                        break;
                    default:
                        break;
                }
                if (!(operatorFound)) lokation++;//if the operator is not found the value of the lokation will be added with 1
            }
            Thread.Sleep(100);//i beleve the aplication was running to fast so with the tread.sleep it will slow it down with 0.1 secconds so the next code will be runned
            if (operatorFound) Calculate(lokation);//if there is a operatorFound it will be calculated in the calculate method with the lokation as a argument
        } while (sum.Contains("*") || sum.Contains("/") || sum.Contains("%"));//if there is 1 of there opperators stil in the sum list it will loop again
        do//this is exactly the same as the code above, bud than for the + and - opperators, and yeah i could do it bouth at once, bud i wand to use the calculation order witch means /,%,* first than +,-
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
    void CalculateCountingOperators(int pLokation)//this method is exactly the same as the calculate method bud then for + and -
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
    void Calculate(int pLokation)// in deze method worden de *,/,% berekent met de meegegeven waarde//in this method the part of the sum with *,/,% will be calculated based on the lokation that is given 
    {
        correctValue = true;//the correctValue is set to true since the value (if correct) is now correct for the calculation
        if (sum[pLokation] == "*")//Here it is checked whether the value is * (multiply sign) and the 2 adjacent values ​​are calculated. below the explanation in detail with | as a boundary for each piece of code
        {//We don't want this code to  |the value for the * is converted to a |the value after the *that is also converted |of course the Double type is not
         //be run with the same values |data type that can handle decimal     |to a type that can handle comma numbers..   |the same as a string like the 
         //​​every time, so they are     |numbers and is multiplied by...       |                                            |one in the list, so after the 
         //replaced with the answer to |                                      |                                            |calculation the answer is 
         //this calculation            |                                      |                                            |converted to a string
            sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) * Convert.ToDouble(sum[pLokation + 1])).ToString();
        }
        else if (sum[pLokation] == "%") sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) % Convert.ToDouble(sum[pLokation + 1])).ToString();//What happened above is also done here, but instead of multiplying it is modulo, maar inplaats van vermedigvuldigen is het modulo
        else if (sum[pLokation] == "/") sum[pLokation] = (Convert.ToDouble(sum[pLokation - 1]) / Convert.ToDouble(sum[pLokation + 1])).ToString();//The same is done here too, but then the values ​​are devided with each other
        else correctValue = false;//there is also a chance that things can go wrong, then the correctValue or false is set
        if (correctValue)//if the value is correct, the other values ​​are also removed since they have already been calculated. In terms of code it can look strange, I will explain it to you there
        {
            sum.RemoveAt(pLokation - 1);//first the value for the answer is removed
            sum.RemoveAt(pLokation);//then the value at the location of the answer, but that sounds crazy, but it is correct. Since the value for the answer has been removed, all values ​​are shifted forward by 1. so the answer goes to the old location of the value before the answer, and the value after the answer goes to the old location of the answer and by removing the location of the old answer we remove the value after the answer.
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))//if the enter button is pressed on the keypad or the big enter button on your keyboard (this is origanaly called the return button so that is why i use the return keycode to make it possible that the other enter butten can be used)
        {
            if (inputField.text == answer)//if the answer is the same as the value of the inputfield will the Value of the Coins playerpref will be 1 more and the mainmenu scene will be loaded
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
                SceneManager.LoadScene("MainMenu");
            }
            else inputField.text = "wrong answer";
        }
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainMenu");//if the player decide to go back to main menu it can do so by pressing Escape button
    }
}
