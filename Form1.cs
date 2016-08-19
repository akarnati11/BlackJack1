using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        private bool over;
        private int pCounter;
        private int dCounter;
        private PictureBox[] dealerBoxes;
        private PictureBox[] playerBoxes;
        private Player p1;
        private Deck deck;
        private Player dealer;

        public Form1()
        {
            InitializeComponent();

            Image[] images = new Image[52];

            string resource;
            for (int i = 0; i < 52; i++)
            {
                resource = "img" + (i + 1).ToString() + ".png";
                images[i] = Image.FromFile(resource);
            }

            p1 = new Player();
            dealer = new Player();
            deck = new Deck(images);

            pCounter = 2;
            dCounter = 2;

            dealerBoxes = new PictureBox[] {dPic1, dPic2, dPic3, dPic4, dPic5, dPic6, dPic7, dPic8, dPic9, dPic10};
            playerBoxes = new PictureBox[] {pPic1, pPic2, pPic3, pPic4, pPic5, pPic6, pPic7, pPic8, pPic9, pPic10, pPic11, pPic12};
            over = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            hitButton.Enabled = true;
            holdButton.Enabled = true;
            startButton.Enabled = false;

            if (over)
                reset();

            for (int i = 0; i < 2; i++)
            {
                dealer.addCard(deck.deal());
                p1.addCard(deck.deal());

                playerBoxes[i].Image = p1.getCardImg(i);
            }
            dPic2.Image = Image.FromFile("imgBack.png");
            dPic2.BringToFront();
            dPic1.Image = dealer.getCardImg(0);

            pPic2.BringToFront();

            playerTotal.Text = p1.getTotalValue().ToString();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            p1.addCard(deck.deal());

            movingBox.Location = pictureBox1.Location;

            playerBoxes[pCounter].Image = p1.getCardImg(pCounter);
            playerBoxes[pCounter].BringToFront();

            while (p1.getTotalValue() > 21 && p1.hasAce())
                p1.setAceLow();

            playerTotal.Text = p1.getTotalValue().ToString();
            pCounter++;

            if (p1.getTotalValue() > 21)
            {
                updateText.Text = "You Lose";
                hitButton.Enabled = false;
                holdButton.Enabled = false;
                startButton.Enabled = true;
                over = true;
            }
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            hitButton.Enabled = false;
            holdButton.Enabled = false;

            dPic2.Image = dealer.getCardImg(1);
            dPic2.BringToFront();

            while (dealer.getTotalValue() < 17)
            {
                dealer.addCard(deck.deal());
                dealerBoxes[dCounter].Image = dealer.getCardImg(dCounter);
                dealerBoxes[dCounter].BringToFront();
                dealerTotal.Text = dealer.getTotalValue().ToString();

                while (dealer.getTotalValue() > 21 && dealer.hasAce())
                    dealer.setAceLow();

                dCounter++;
            }

            dealerTotal.Text = dealer.getTotalValue().ToString();

            checkForWinner();
        }

        private void checkForWinner()
        {
            if (dealer.getTotalValue() > p1.getTotalValue() && dealer.getTotalValue() <= 21)
                updateText.Text = "You Lose";
            else if ((dealer.getTotalValue() < p1.getTotalValue())
                        || dealer.getTotalValue() > 21)
                updateText.Text = "You Win!";
            else
                updateText.Text = "Tie!";

            startButton.Enabled = true;
            startButton.Text = "Reset";
            over = true;
        }

        private void reset()
        {
            deck.receiveCards(p1.returnCards());
            deck.receiveCards(dealer.returnCards());
            deck.shuffle();

            foreach (PictureBox p in dealerBoxes)
                p.Image = null; 
            foreach (PictureBox p in playerBoxes)
                p.Image = null;

            playerTotal.Text = "0";
            dealerTotal.Text = "    ";
            updateText.Text = "    ";
            pCounter = dCounter = 2;
            over = false;
        }
        
    }
}
