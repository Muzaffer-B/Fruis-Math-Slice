using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public Dictionary<string, int> BeginnerQuesitons()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();


        string[] OP = new string[] { "a", "s", "m", "d" };

        for (int i = 0; i < 150; i++)
        {
            int x = Random.Range(1, 10);
            int y = Random.Range(1, 10);
            int operation = Random.Range(0, 4);
            if (operation == 0)
            {
                if (dictionary.ContainsKey(x.ToString() + "+" + y.ToString()))
                {

                    dictionary.Remove(x.ToString() + "+" + y.ToString());
                }
                else
                {
                    dictionary.Add(x.ToString() + "+" + y.ToString(), x + y);
                }

            }
            if (operation == 1)
            {
                if (dictionary.ContainsKey(x.ToString() + "-" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "-" + y.ToString());
                }
                else
                {
                    if (x < y)
                    {
                        if (dictionary.ContainsKey(y.ToString() + "-" + x.ToString()))
                        {
                            dictionary.Remove(y.ToString() + "-" + x.ToString());
                        }
                        dictionary.Add(y.ToString() + "-" + x.ToString(), y - x);
                    }
                    else
                    {
                        if (dictionary.ContainsKey(x.ToString() + "-" + y.ToString()))
                        {
                            dictionary.Remove(x.ToString() + "-" + y.ToString());
                        }
                        dictionary.Add(x.ToString() + "-" + y.ToString(), x - y);
                    }
                }


            }
            if (operation == 2)
            {
                if (dictionary.ContainsKey(x.ToString() + "X" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "X" + y.ToString());
                }
                else
                {
                    dictionary.Add(x.ToString() + "X" + y.ToString(), x * y);
                }

            }
            if (operation == 3)
            {

                if (dictionary.ContainsKey(x.ToString() + "/" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "/" + y.ToString());
                }
                else
                {
                    if (x % y == 0)
                    {
                        dictionary.Add(x.ToString() + "/" + y.ToString(), x / y);
                    }
                    else
                    {
                        i = i - 1;
                    }
                }



            }
        }
        //dictionary.Add("2+2", 4);
        //dictionary.Add("3+3", 6);
        //dictionary.Add("2X2", 4);
        //dictionary.Add("3X3", 9);
        //dictionary.Add("2/2", 1);
        //dictionary.Add("3+7", 10);


        return dictionary;
    }
    public Dictionary<string, int> IntermediateQuesitons()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();


        string[] OP = new string[] { "a", "s", "m", "d" };

        for (int i = 0; i < 150; i++)
        {

            int operation = Random.Range(0, 4);
            if (operation == 0)
            {
                int x = Random.Range(50, 500);
                int y = Random.Range(50, 500);
                if (dictionary.ContainsKey(x.ToString() + "+" + y.ToString()))
                {

                    dictionary.Remove(x.ToString() + "+" + y.ToString());
                }
                else
                {
                    dictionary.Add(x.ToString() + "+" + y.ToString(), x + y);
                }

            }
            if (operation == 1)
            {
                int x = Random.Range(50, 500);
                int y = Random.Range(50, 500);
                if (dictionary.ContainsKey(x.ToString() + "-" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "-" + y.ToString());
                }
                else
                {
                    if (x < y)
                    {
                        if (dictionary.ContainsKey(y.ToString() + "-" + x.ToString()))
                        {
                            dictionary.Remove(y.ToString() + "-" + x.ToString());
                        }
                        dictionary.Add(y.ToString() + "-" + x.ToString(), y - x);
                    }
                    else
                    {
                        if (dictionary.ContainsKey(x.ToString() + "-" + y.ToString()))
                        {
                            dictionary.Remove(x.ToString() + "-" + y.ToString());
                        }
                        dictionary.Add(x.ToString() + "-" + y.ToString(), x - y);
                    }
                }


            }
            if (operation == 2)
            {
                int x = Random.Range(15, 80);
                int y = Random.Range(15, 80);
                if (dictionary.ContainsKey(x.ToString() + "X" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "X" + y.ToString());
                }
                else
                {
                    dictionary.Add(x.ToString() + "X" + y.ToString(), x * y);
                }

            }
            if (operation == 3)
            {
                int x = Random.Range(50, 1000);
                int y = Random.Range(50, 1000);

                if (dictionary.ContainsKey(x.ToString() + "/" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "/" + y.ToString());
                }
                else
                {
                    if (x % y == 0)
                    {
                        dictionary.Add(x.ToString() + "/" + y.ToString(), x / y);
                    }
                    else
                    {
                        i = i - 1;
                    }
                }



            }
        }




        //dictionary.Add("20+25", 45);
        //dictionary.Add("30+34", 64);
        //dictionary.Add("22X4", 88);
        //dictionary.Add("12X12", 144);
        //dictionary.Add("64/4", 16);
        //dictionary.Add("37+41", 78);
        //dictionary.Add("67+25", 92);
        //dictionary.Add("11+72", 83);
        //dictionary.Add("16X7", 112);
        //dictionary.Add("6X13", 78);
        //dictionary.Add("144/3", 48);
        //dictionary.Add("120+114", 234);
        //dictionary.Add("110+114", 224);
        //dictionary.Add("130+114", 244);
        //dictionary.Add("140+114", 254);
        //dictionary.Add("150+114", 264);
        //dictionary.Add("160+114", 274);
        //dictionary.Add("170+114", 284);
        //dictionary.Add("180+114", 294);
        //dictionary.Add("90+84", 174);
        //dictionary.Add("60+44", 104);
        //dictionary.Add("90+86", 176);
        //dictionary.Add("90+88", 178);
        //dictionary.Add("90+87", 177);
        //dictionary.Add("90+81", 171);
        //dictionary.Add("90+82", 172);
        //dictionary.Add("60+144", 204);
        //dictionary.Add("90+121", 221);
        //dictionary.Add("90+84", 174);
        //dictionary.Add("90+84", 174);
        //dictionary.Add("90+84", 174);
        //dictionary.Add("90+84", 174);

        return dictionary;
    }
    public Dictionary<string, int> HardQuesitons()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        string[] OP = new string[] { "a", "s", "m", "d" };

        for (int i = 0; i < 150; i++)
        {

            int operation = Random.Range(0, 4);
            if (operation == 0)
            {
                int x = Random.Range(400, 3000);
                int y = Random.Range(400, 3000);
                if (dictionary.ContainsKey(x.ToString() + "+" + y.ToString()))
                {

                    dictionary.Remove(x.ToString() + "+" + y.ToString());
                }
                else
                {
                    dictionary.Add(x.ToString() + "+" + y.ToString(), x + y);
                }

            }
            if (operation == 1)
            {
                int x = Random.Range(400, 3000);
                int y = Random.Range(400, 3000);
                if (dictionary.ContainsKey(x.ToString() + "-" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "-" + y.ToString());
                }
                else
                {
                    if (x < y)
                    {
                        if (dictionary.ContainsKey(y.ToString() + "-" + x.ToString()))
                        {
                            dictionary.Remove(y.ToString() + "-" + x.ToString());
                        }
                        dictionary.Add(y.ToString() + "-" + x.ToString(), y - x);
                    }
                    else
                    {
                        if (dictionary.ContainsKey(x.ToString() + "-" + y.ToString()))
                        {
                            dictionary.Remove(x.ToString() + "-" + y.ToString());
                        }
                        dictionary.Add(x.ToString() + "-" + y.ToString(), x - y);
                    }
                }


            }
            if (operation == 2)
            {
                int x = Random.Range(40, 100);
                int y = Random.Range(40, 100);
                if (dictionary.ContainsKey(x.ToString() + "X" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "X" + y.ToString());
                }
                else
                {
                    dictionary.Add(x.ToString() + "X" + y.ToString(), x * y);
                }

            }
            if (operation == 3)
            {
                int x = Random.Range(400, 3000);
                int y = Random.Range(400, 3000);
                if (dictionary.ContainsKey(x.ToString() + "/" + y.ToString()))
                {
                    dictionary.Remove(x.ToString() + "/" + y.ToString());
                }
                else
                {
                    if (x % y == 0)
                    {
                        dictionary.Add(x.ToString() + "/" + y.ToString(), x / y);
                    }
                    else
                    {
                        i = i - 1;
                    }
                }



            }
        }


        return dictionary;
    }



}
