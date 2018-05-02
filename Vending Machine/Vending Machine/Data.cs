using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Data
    {

        public static string[,] vendingMenu = new string[,]

        {
            {"D1",   "Spite:                            10kr", "Spite", "10" },
            {"D2",   "Puka-Cola:                        10kr", "Puka-Cola", "10" },
            {"D3",   "Razorade:                         10kr", "Razorade", "10" },
            {"D4",   "Overpriced tap water:             98kr", "Overpriced tap water", "98" },
            {"F1",   "Peanut butter and bacon sandwich: 23kr", "Peanut butter and bacon sandwich", "23" },
            {"F2",   "Bag of Flays potato chips:        16kr", "Bag of Flays potato chips", "16" },
            {"F3",   "Lump of Spam:                      5kr", "Lump of Spam",  "5" },
            {"F4",   "Mystery Taco:                     39kr", "Mystery Taco", "39" },
            {"S1",   "Kittycat Bar:                     12kr", "Kittycat Bar", "12" },
            {"S2",   "Non-flavor bubblegum:              9kr", "Non-flavor bubblegum",  "9" },
            {"S3",   "Box of Girl Scout Cookies:        25kr", "Box of Girl Scout Cookies", "25" },
            {"S4",   "Everlasting Discomfort:           13kr", "Everlasting Discomfort", "13" }
        };


        public static Dictionary<string, string> descriptions = new Dictionary<string, string>
        {
            { "Spite", "Spite: All hatred, no sugar." },
            { "Puka-Cola" , "Puka-Cola: Tastes almost as good going down as it does going up!" },
            { "Razorade" , "Razorade: Energizing, hydrating, internally haemorraging." },
            { "Overpriced tap water" , "Overpriced tap water: Because the price tag shows how good it is." },

            { "Peanut butter and shrimp sandwich" , "PB&S sandwich: Two great tastes that go not-so-great together." },
            { "Bag of Flays potato chips" , "Flays: Rich in nutritious human skin." },
            { "Lump of Spam" , "Spam: It's meat. Probably." },
            { "Mystery Taco" , "Mystery Taco: What's in it? It's a secret to everybody!" },

            { "Kittycat Bar" , "Kittycat Bar: You can taste the cuteness!" },
            { "Non-flavor bubblegum" , "Pure chewing satisfaction, and nothing else." },
            { "Box of Girl Scout Cookies" , "Girl Scout Cookies: Made from real Girl Scouts!" },
            { "Everlasting Discomfort" , "Everlasting Discomfort: What even is this thing? Just eat it, maybe." }


        };


    }
}
