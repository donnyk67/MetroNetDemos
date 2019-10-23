﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
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
                        foreach (var crd in MyFiveCards.Items)
                        {
                            
                            if (((PlayingCard)crd).OverAllHierarchyCardValue == rndCard)
                            {
                                rndCard = rnd.Next(0, 52);
                                c = NewDeck.Items[rndCard];
                                moveOn = false;
                                break;
                            }
                            else if( ((PlayingCard)crd).CardName == ((PlayingCard)c).CardName && ((PlayingCard)crd).SuitName == ((PlayingCard)c).SuitName)
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
            List<string> rmList = new List<string>();
            
            foreach (var i in MyFiveCards.Items)
            {
                var cName = (i as MyHand).CardName;
                var cSuit = (i as MyHand).SuitName;
                var a = (i as MyHand).Discard;
                if (a)
                {
                    rmList.Add(cName + cSuit);
                }
            }

            foreach (var r in rmList)
            {
                int ct = 0;
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

                            if (((PlayingCard)crd).OverAllHierarchyCardValue == rndCard)
                            {
                                rndCard = rnd.Next(0, 52);
                                c = NewDeck.Items[rndCard];
                                moveOn = false;
                                break;
                            }
                            else if (((PlayingCard)crd).CardName == ((PlayingCard)c).CardName && ((PlayingCard)crd).SuitName == ((PlayingCard)c).SuitName)
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

                MyFiveCards.Items.Add(h);

                SortDataGrid(MyFiveCards, 4, ListSortDirection.Ascending);
            }




            //(MyFiveCards.Items as List<MyHand>).Remove(c => c. );  //.RemoveAll(x => x.FirstName == "Bob");



            }


        
    }
}