using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BlackJack
{
    class Card
    {
        private int value;
        private Image cardImg;

        public Card(int num, Image card)
        {
            value = num;
            cardImg = card;
        }

        /// <summary>
        /// Gets the value of the card.
        /// </summary>
        public int getCardValue()
        { return value; }

        /// <summary>
        /// Gets the image of the card.
        /// </summary>
        public Image getCardImg()
        { return cardImg; }

        /// <summary>
        /// Sets the value of the card.
        /// </summary>
        /// <param name="val"></param>
        public void setCardValue(int val)
        { value = val; }
    }
}
