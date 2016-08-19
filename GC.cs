using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BlackJack
{
    class GC
    {
        public Player p1;
        public Player dealer;
        public Deck deck;
        public string resource;
        public GC()
        {
            Image[] images = new Image[52];

            for (int i = 0; i < 52; i++)
            {
                resource = "img" + (i + 1).ToString() + ".png";
                images[i] = Image.FromFile(resource);
            }

            p1 = new Player();
            dealer = new Player();
            deck = new Deck(images);
        }
    }
}
