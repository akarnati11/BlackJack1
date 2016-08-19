using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace BlackJack
{
    class Player
    {
        private ArrayList myCards;
        private int total;

        public Player()
        {
            myCards = new ArrayList();
            total = 0;
        }


        /// <summary>
        /// Returns the player's cards to the deck object.
        /// Used at the end of a game.
        /// </summary>
        public ArrayList returnCards()
        {
            ArrayList tempCards = new ArrayList();
            tempCards.AddRange(myCards);
            myCards.Clear();
            total = 0;
            return tempCards;
        }

        /// <summary>
        /// Adds the specificed card to the player's list of cards
        /// </summary>
        public void addCard(Card c1)
        { 
            myCards.Add(c1);
            total += c1.getCardValue();
        }

        /// <summary>
        /// Gets the total value of the player's cards.
        /// </summary>
        public int getTotalValue()
        { return total; }

        /// <summary>
        /// Gets the image of the card at the specific index in the player's
        /// cards.
        /// </summary>
        public Image getCardImg(int index)
        {
            return ((Card) myCards[index]).getCardImg();
        }

        /// <summary>
        /// Checks if there are any aces in the player's cards,
        /// returns false if there are none.
        /// </summary>
        public bool hasAce()
        {
            foreach (Card c in myCards)
            {
                if (c.getCardValue() == 11)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the card value of the next ace in the player's cards 
        /// to 1, if the original value of 11 increased the total over 21.
        /// </summary>
        public void setAceLow()
        {
            foreach (Card c in myCards)
            {
                if (c.getCardValue() == 11)
                {
                    c.setCardValue(1);
                    total -= 10;
                    return;
                }
            }
        }
    }
}
