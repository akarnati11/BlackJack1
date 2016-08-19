using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace BlackJack
{
    class Deck
    {
        private ArrayList cards;
        private ArrayList tempCards;
        private Random rand;

        public Deck(Image[] imgs)
        {
            int counter = 0;
            Card tempCard;
            cards = new ArrayList();
            tempCards = new ArrayList();
            rand = new Random();

            //for each suit
            for (int i = 0; i < 4; i++)
            {
                //numerical cards
                for (int j = 2; j <= 10; j++)
                {
                    tempCard = new Card(j, imgs[counter]);
                    cards.Add(tempCard);
                    counter++;
                }
                //face cards except for the ace
                for (int k = 0; k < 3; k++)
                {
                    cards.Add(new Card(10, imgs[counter]));
                    counter++;
                }
                //the ace
                cards.Add(new Card(11, imgs[counter]));
                counter++;
            }
            shuffle();
        }

        /// <summary>
        /// Shuffles the deck with a random number generator.
        /// </summary>
        public void shuffle()
        {
            int curRandNum = 0;
            tempCards.AddRange(cards);
            cards.Clear();
            
            for (int i = 0; i < 52; i++)
            {
                curRandNum = rand.Next(0, tempCards.Count - 1);
                cards.Add(tempCards[curRandNum]);
                tempCards.RemoveAt(curRandNum);
            }
            tempCards.Clear();
        }

        /// <summary>
        /// Deals a card to a player.
        /// </summary>
        public Card deal()
        {
            Card tempCard = (Card) cards[0];
            cards.RemoveAt(0);
            return tempCard;
        }

        /// <summary>
        /// Adds the returned cards back to the deck's list of cards.
        /// </summary>
        public void receiveCards(ArrayList cardsToReturn)
        { cards.AddRange(cardsToReturn); }
    }
}
