using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectOrientedPrograms_CS.DeckofCards
{
    class Cards
    {
        //generating a random number
        Random random = new Random();
        public void Suffle()
        {
            //creating a list of suit which contain 4(club,diamond,heart,spade)
            var suit = new List<string>
            {
                "Club","Diamond","Heart","Spade"
            };
            //creating list which contain card number range from 2-10 and A,K,Q,J
            var rank = new List<string>
            {
                "2","3","4","5","6","7","8","9","10","J","Q","K","A"
            };
            //Taking linked list to store all 52 cards with 4 types of suits
            LinkedList<string> cards = new LinkedList<string>();
            //Linked list of storing player (4 player)
            LinkedList<string> players = new LinkedList<string>();
            Console.WriteLine("Printing all the cards");
            for (int i = 0; i < suit.Count; i++)
            {
                foreach (var mem in rank)
                {
                    cards.AddLast(suit[i] + mem); //Adding the all cards in the linked list of cards
                }
            }
            //Printing the cards 
            foreach (var member in cards)
            {
                Console.Write(member + " ");
            }
            Console.WriteLine(" ");
            //Dictionary to store player with list of cards in value
            Dictionary<string, LinkedList<string>> playersWithCards = new Dictionary<string, LinkedList<string>>();
            //Initializing player to 1
            int player = 1;
            while (player != 5) //player should be 4
            {
                LinkedList<string> card = new LinkedList<string>();
                while (card.Count < 9) //9 cards to be distributed
                {
                    int ransuit = random.Next(0, suit.Count);
                    int ranrank = random.Next(0, rank.Count);
                    card.AddLast(rank[ranrank] + suit[ransuit]);
                }
                playersWithCards.Add(("\nPlayer-" + player), card);
                Console.WriteLine("");
                player++;
            }
            //Printing the player with cards after sorting them
            foreach (var member in playersWithCards)
            {
                players.AddLast(member.Key);
                Console.WriteLine(member.Key);
                //caliing sorting method
                Sorting(member.Value);
                Console.WriteLine(" ");
            }
        }

        public void Sorting(LinkedList<string> playarray)
        {
            char[] arr = { '2', '3', '4', '5', '6', '7', '8', '9' };
            LinkedList<string> sorted = new LinkedList<string>();
            var temp = new List<string>();
            //sorting for numbers present in cards
            foreach (var i in playarray.OrderBy(value => value))
            {
                if (arr.Contains(i[0]))
                {
                    sorted.AddLast(i); //sorted store only values 2-9
                }
                else
                {
                    temp.Add(i); //temp store cards with 10,K,Q,J,A
                }
            }
            temp = temp.OrderBy(t => t).ToList(); 
            //Sort array a containing Ranks 10,J,K,Q,A
            for (int i = 0; i < temp.Count - 1; i++)
            {
                for (int j = i + 1; j < temp.Count; j++)
                {
                    if ((temp[i][0] == 'K' && temp[j][0] == 'Q') || (temp[i][0] == 'A' && temp[j][0] == 'Q') || (temp[i][0] == 'A' && temp[j][0] == 'J') || (temp[i][0] == 'A' && temp[j][0] == 'K'))
                    {
                        string tmp = temp[i];
                        temp[i] = temp[j];
                        temp[j] = tmp;
                    }
                }
            }
            foreach (var i in temp)//temp data now added in last to sorted 
            {
                sorted.AddLast(i);
            }
            //Printing values of deck of cards
            Console.WriteLine("Cards after sorting:-\n");
            foreach (var member in sorted)
            {
                Console.Write(member + " ");
            }
        }
    }
}

