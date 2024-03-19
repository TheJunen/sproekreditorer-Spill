using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Item_Shop
    {
        //private Button ItemShop1;
        //private Button ItemShop2;
        //private Button ItemShop3;
        //private Button ItemShop4;
        //private Button ItemShop5;
        //private Button ItemShop6;
        //private Button ItemShop7;
        //private Button ItemShop8;
        private List<Button> itemShopButtons = new List<Button>();
        //private PictureBox ItemSunPictureBox;
        private Label TestInItemShop;
        private Form1 form1;
        public Item_Shop(Form1 form1)
        {
            itemShopButtons.AddRange(new List<Button>{
                new Button { Text = "hei" },
                new Button { Text = "Shishan"},
                new Button { Text = "kageyama"}
            });

            foreach (var button in itemShopButtons)
            {
                button.Click += ItemShopButtons_Click;
            }

            this.form1 = form1;
        }

        //public Item_Shop(/*PictureBox itemSun,*/ Label test/*, Form1 form1*/)
        //{
        //    //ItemSunPictureBox = itemSun;
        //    this.TestInItemShop = test;
        //    //Form1 = form1;
        //}

        //internal void labeltest()
        //{
        //    AddButtonsTextToTest();
        //    //form1.test.Visible = true;
        //}

        internal void labeltest()
        {
            ////MessageBox.Show("Hei");
            //// Sjekk om en Invoke er nødvendig
            //if (form1.InvokeRequired)
            //{
            //    form1.Invoke(new MethodInvoker(delegate
            //    {
            //        AddButtonsTextToTest();
            //    }));
            //}
            //else
            //{
            //    /*AddButtonsTextToTest()*/;
            //}
            AddButtonsTextToTest();
        }


        private void AddButtonsTextToTest()
        {

            //foreach (Button button in itemShopButtons)
            //{
            //    Form1.UpdateTest(button.Text, true);
            //}
            //Form1.UpdateTest(but.Text, true);
            form1.UpdateTest("Yo", true);

        }

        

        internal void ItemShopButtons_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            //int IntClickedButton = Convert.ToInt32(clickedButton);

            int itemNumber = itemShopButtons.IndexOf(clickedButton);
            if (clickedButton.Name == "ItemShop1")
            {
                BuySun();
            }
            else if (clickedButton.Name == "ItemShop2")
            {
                Buy2xCoins();
            }
            else if (clickedButton.Name == "ItemShop8")
            {
                form1.DisableItemShopPanel();
            }

            //if (clickedButton == )
            //MessageBox.Show($"{IntClickedButton}");
        }

        private void BuySun()
        {
            var ItemSun = form1.ReturnItemSun();
            //ItemSunPictureBox.Visible = true;
            form1.PictureBoxesFromItem_Shop(ItemSun, true);
            //var BuySunCost = form1.collectionCoins - 20;
            form1.collectionCoins -= 10;
        }

        private void Buy2xCoins()
        {
            if (form1.CoinsMultiplier == 1 && form1.collectionCoins >= 10)
            {
                form1.CoinsMultiplier += 1;
                form1.collectionCoins -= 10;
            }
            else if (form1.collectionCoins >= 10)
            {
                MessageBox.Show("You bought 2x Coins successfully");
                var multiplyingcoins = form1.CoinsMultiplier * 2;
                form1.CoinsMultiplier = multiplyingcoins;
                //var BuySunCost = form1.collectionCoins - 10;
                form1.collectionCoins -= 10;
            }
        }


    }


}
