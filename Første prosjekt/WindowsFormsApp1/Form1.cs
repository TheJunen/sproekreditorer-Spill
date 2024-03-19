using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public System.Windows.Forms.Label test { get; set; }
        //internal PictureBox ItemSunPictureBox;
        private Item_Shop instance;

        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            button1.Visible = false;
            //ItemShopPanel.Height = 29;
            ItemSun.Visible = false;
            Hala.Visible = false;
            test = Hala;
            //ItemSunPictureBox = ItemSun;
            //MessageBox.Show("Hala refers to Test: " + (this.Test == Hala));
            //Item_Shop item_shop = new Item_Shop(/*ItemSunPictureBox,*/ Hala, this);
            //Item_Shop item_shop2 = new Item_Shop(ItemSunPictureBox, Hala, this);
            var item_shop = new Item_Shop(this);
            instance = item_shop;
            MessageBox.Show($"{instance}");
            item_shop.labeltest();
            //item_shop2.labeltest();
            this.ItemShop.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop1.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop2.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop3.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop4.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop5.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop6.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop7.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            this.ItemShop8.Click += new System.EventHandler(instance.ItemShopButtons_Click);
            //ItemShopPanel.BringToFront();
            ItemShopToggle.Enabled = false;
            button1.Enabled = false;
            ItemShopPanel.Enabled = false;
            ItemShop.Enabled = false;
        }

        private void NewGame()
        {
            if (timer1.Enabled == false)
            {
                button1.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TreesMove(gamespeed);
            Enemy(gamespeed);
            Coins(gamespeed);
            CoinsCollection();
            GameOverIntersect();
            NewGame();
        }

        void TreesMove(int speed)
        {
            pictureBox2.Left -= speed;
            pictureBox3.Left -= speed;
            if (pictureBox2.Right <= 0)
            {
                pictureBox2.Left = this.Width;
            }
            if (pictureBox3.Right <= 0)
            {
                pictureBox3.Left = this.Width;
            }
        }


        int gamespeed = 2;
        bool allowCharacterMovement = true;
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            //ItemShopPanel.Visible = false;
            if (allowCharacterMovement)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (jogger.Left < 1360)
                    {
                        jogger.Left += 8;
                    }
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (jogger.Left > 0)
                    {
                    
                        jogger.Left += -8;
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (jogger.Bottom < 560)
                    {
                        jogger.Top += 8;
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (jogger.Top > 314)
                    {

                        jogger.Top += -8;
                    }
                }
                if (e.KeyCode == Keys.L)
                {
                    if (gamespeed < 5 /*&& gamespeed > 3*/)
                    {
                        gamespeed++;
                    }
                }
                if (e.KeyCode == Keys.K)
                {
                    if (gamespeed > 2)
                    {
                        gamespeed--;
                    }
                }
                if (e.KeyCode == Keys.S)
                {
                    ToggleItemShop();
                }
            }
            //ItemShopPanel.Visible = true;
        }

        Random r = new Random();
        int x, y;


        void Enemy(int speed)
        {
            //enemy1.Left -= speed;
            if (enemy1.Right <= 0)
            {
                y = r.Next(300, 530);
                enemy1.Location = new Point(1420, y);
            }
            else { enemy1.Left -= speed; enemy1.Left -= speed; }
            //enemy1.Left -= speed;
            if (enemy2.Right <= 0)
            {
                y = r.Next(300, 530);
                enemy2.Location = new Point(1420, y);
            }
            else { enemy2.Left -= speed; }
            //enemy3.Left -= speed;
            if (enemy3.Right <= 0)
            {
                y = r.Next(300, 530);
                enemy3.Location = new Point(1420, y);
            }
            else { enemy3.Left -= speed; enemy3.Left -= speed; }
            if (enemy4.Right <= 0)
            {
                y = r.Next(300, 530);
                enemy4.Location = new Point(1420, y);
            }
            else { enemy4.Left -= speed; }
        }

        void Coins(int speed)
        {
            if (coin1.Right <= 0)
            {
                y = r.Next(300, 530);
                coin1.Location = new Point(1420, y);
            }
            else { coin1.Left -= speed; coin1.Left -= speed; }
            //enemy1.Left -= speed;
            if (coin2.Right <= 0)
            {
                y = r.Next(300, 530);
                coin2.Location = new Point(1420, y);
            }
            else { coin2.Left -= speed; }
            //enemy3.Left -= speed;
            if (coin3.Right <= 0)
            {
                y = r.Next(300, 530);
                coin3.Location = new Point(1420, y);
            }
            else { coin3.Left -= speed; }
        }

        internal int collectionCoins = 0;

        internal int CoinsMultiplier = 1;

        void CoinsMultiplierToCollectionCoins()
        {
            collectionCoins += CoinsMultiplier;
        }
        void CoinsCollection()
        {
            if (jogger.Bounds.IntersectsWith(coin1.Bounds))
            {
                CoinsMultiplierToCollectionCoins();
                label1.Text = "Coins=" + collectionCoins.ToString();
                y = r.Next(300, 530);
                coin1.Location = new Point(1420, y);
            }
            if (jogger.Bounds.IntersectsWith(coin2.Bounds))
            {
                CoinsMultiplierToCollectionCoins();
                label1.Text = "Coins=" + collectionCoins.ToString();
                y = r.Next(300, 530);
                coin2.Location = new Point(1420, y);
            }
            if (jogger.Bounds.IntersectsWith(coin3.Bounds))
            {
                CoinsMultiplierToCollectionCoins();
                label1.Text = "Coins=" + collectionCoins.ToString();
                y = r.Next(300, 530);
                coin3.Location = new Point(1420, y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        void GameOverIntersect()
        {
            if (jogger.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
                button1.Visible = true;
            }
            if (jogger.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
                button1.Visible = true;
            }
            if (jogger.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
                button1.Visible = true;
            }
        }


        //private void ItemShop_Click_1(object sender, EventArgs e)
        //{
        //    if (ItemShopPanel.Height == 366)
        //    {
        //        ItemShopPanel.Height = 29;
        //    }
        //    else
        //    {
        //        ItemShopPanel.Height = 366;
        //    }

        //    timer1.Enabled = false;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ItemShop_Click(object sender, EventArgs e)
        {
            ItemShopPanel.Enabled = false;
        }

        internal void UpdateTest(string newText, bool visibility)
        {
            //MessageBox.Show("Heij jajaj");
            //MessageBox.Show("Seya");

            test.Text = newText;
            test.Visible = visibility;
        }

        internal void PictureBoxesFromItem_Shop(PictureBox picturebox, bool visibility)
        {
            picturebox.Visible = visibility;
        }

        //private void Buy2xCoinsReceiver()
        //{

        //}


        private void ToggleItemShop()
        {
            ItemShopPanel.Enabled = !ItemShopPanel.Enabled;
            if (ItemShopPanel.Enabled)
            {
                timer1.Enabled = false;
            }
            else if (!ItemShopPanel.Enabled)
            {
                timer1.Enabled = true;
            }
        }

        internal PictureBox ReturnItemSun()
        {
            return ItemSun;
        }

        internal void DisableItemShopPanel()
        {
            ItemShopPanel.Enabled = false;
        }








    }
}
