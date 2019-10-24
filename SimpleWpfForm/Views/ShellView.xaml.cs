using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CommonLibrary.PlayingCards;
using SimpleWpfForm.ViewModels;


namespace SimpleWpfForm.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button2.IsEnabled = true;

            MyFiveCards.Items.Clear();
            var rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                var rndCard = rnd.Next(0, 52);
                var c = NewDeck.Items[rndCard];
                var moveOn = false;
                if (MyFiveCards.Items.Count > 0)
                {
                    while (!moveOn)
                    {
                        moveOn = true;
                        if (!MyFiveCards.Items.Cast<object>().Any(crd =>
                            ((PlayingCard) crd).CardName == ((PlayingCard) c).CardName &&
                            ((PlayingCard) crd).SuitName == ((PlayingCard) c).SuitName)) continue;
                        rndCard = rnd.Next(0, 52);
                        c = NewDeck.Items[rndCard];
                        moveOn = false;
                    }
                   
                }
                
                var h = new MyHand
                {
                    CardName = (c as PlayingCard).CardName,
                    SuitName = (c as PlayingCard).SuitName,
                    SuitColorName = (c as PlayingCard).SuitColorName,
                    SuitColor = (c as PlayingCard).SuitColor,
                    HierarchyValue = (c as PlayingCard).HierarchyValue,
                    OverAllHierarchyCardValue = (c as PlayingCard).OverAllHierarchyCardValue,
                    Discard = false
                };
                //Default to Spades
                var path = AppDomain.CurrentDomain.BaseDirectory;
                path = path.Replace(@"\bin\Debug\", "");
                var imagePath = path + @"\img\Spade.png";
                

                var switchData = h.SuitName;
                switch (switchData)
                {

                    case "CLUBS":
                        imagePath = path + @"\img\Club.png";
                        break;
                    case "HEARTS":
                        imagePath = path + @"\img\Heart.png";
                        break;
                    case "DIAMONDS":
                        imagePath = path + @"\img\Diamond.png";
                        break;

                }
                Uri uri = new Uri(imagePath);
                var bmp = new System.Windows.Media.Imaging.BitmapImage(uri);
                var myImage = bmp; //System.Drawing.Image.FromFile(imagePath);
                h.Image = myImage;
                MyFiveCards.Items.Add(h);
              
            }
            SortDataGrid(MyFiveCards, 4, ListSortDirection.Ascending);
        }

        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0,
            ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];

            // Clear current sort descriptions
            dataGrid.Items.SortDescriptions.Clear();

            // Add the new sort description
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            // Apply sort
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }

            column.SortDirection = sortDirection;

            // Refresh items to display sort
            dataGrid.Items.Refresh();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button2.IsEnabled = false;
            var rmList = (from object i in MyFiveCards.Items let cName = (i as MyHand).CardName let cSuit = (i as MyHand).SuitName let a = (i as MyHand).Discard where a select cName + cSuit).ToList();

            foreach (var r in rmList)
            {
                var ct = 0;
                foreach (var i in MyFiveCards.Items)
                {
                    var cName = (i as MyHand).CardName;
                    var cSuit = (i as MyHand).SuitName;
                    var a = (i as MyHand).Discard;
                    if (a)
                    {
                        MyFiveCards.Items.RemoveAt(ct);
                        break;
                    }
                    ct++;
                }
            }

            foreach (var r in rmList)
            {
                var rnd = new Random();
                var rndCard = rnd.Next(0, 52);
                var c = NewDeck.Items[rndCard];
                if (MyFiveCards.Items.Count > 0)
                {
                    var moveOn = false;
                    while (!moveOn)
                    {
                        moveOn = true;
                        foreach (var crd in MyFiveCards.Items)
                        {
                            var rmListMatch = ((PlayingCard) crd).CardName + ((PlayingCard) crd).SuitName;
                            //Don''t accept any cards you already are holding
                            if (((PlayingCard)crd).CardName == ((PlayingCard)c).CardName && ((PlayingCard)crd).SuitName == ((PlayingCard)c).SuitName)
                            {
                                rndCard = rnd.Next(0, 52);
                                c = NewDeck.Items[rndCard];
                                moveOn = false;
                                break;
                            }
                            //Don''t accept any discarded cards
                            if (rmListMatch == r)
                            {
                                rndCard = rnd.Next(0, 52);
                                c = NewDeck.Items[rndCard];
                                moveOn = false;
                                break;
                            }
                            

                        }
                    }
                }

   
                var h = new MyHand
                {
                    CardName = (c as PlayingCard).CardName,
                    SuitName = (c as PlayingCard).SuitName,
                    SuitColorName = (c as PlayingCard).SuitColorName,
                    SuitColor = (c as PlayingCard).SuitColor,
                    HierarchyValue = (c as PlayingCard).HierarchyValue,
                    OverAllHierarchyCardValue = (c as PlayingCard).OverAllHierarchyCardValue,
                    Discard = false
                };

                //Default to Spades
                var path = AppDomain.CurrentDomain.BaseDirectory;
                path = path.Replace(@"\bin\Debug\", "");
                var imagePath = path + @"\img\Spade.png";


                var switchData = h.SuitName;
                switch (switchData)
                {

                    case "CLUBS":
                        imagePath = path + @"\img\Club.png";
                        break;
                    case "HEARTS":
                        imagePath = path + @"\img\Heart.png";
                        break;
                    case "DIAMONDS":
                        imagePath = path + @"\img\Diamond.png";
                        break;

                }
                Uri uri = new Uri(imagePath);
                var bmp = new System.Windows.Media.Imaging.BitmapImage(uri);
                var myImage = bmp; //System.Drawing.Image.FromFile(imagePath);
                h.Image = myImage;

                MyFiveCards.Items.Add(h);

                SortDataGrid(MyFiveCards, 4, ListSortDirection.Ascending);
            }




            //(MyFiveCards.Items as List<MyHand>).Remove(c => c. );  //.RemoveAll(x => x.FirstName == "Bob");



            }


        
    }
}