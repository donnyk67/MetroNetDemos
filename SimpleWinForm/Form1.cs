using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonLibrary.PlayingCardFactory;
using CommonLibrary.PlayingCards;

namespace SimpleWinForm
{
    //Inject our dependency on the Playing Card Factory into the constructor.
    //Note: Form 2 I did not use dependency injection, it was more for just showing validation examples.
    public partial class Form1 : Form
    {

        private readonly IPlayingCardFactory _pcf;
       
        public Form1(IPlayingCardFactory pcf)
        {
            _pcf = pcf;
            InitializeComponent();
        }

        private void BtnGetNewDeck_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _pcf.GetMeANewDeckOfCards();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1 == null) return;

            try
            {
                // ReSharper disable once PossibleNullReferenceException (Taken care of above)
                dataGridView1.Columns["SuitColor"].DefaultCellStyle.ForeColor = System.Drawing.Color.Yellow;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn c in dataGridView1.Columns)
                    {
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        if (c.Name == "SuitColor")
                            r.Cells[c.Index].Style.BackColor = (System.Drawing.Color) r.Cells[c.Index].Value;
                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }

           
        }

        private void BtnOBHVasc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                var myClass = dataGridView1.DataSource as List<PlayingCard>;
                if (myClass != null)
                    dataGridView1.DataSource = myClass.OrderBy(t => t.OverAllHierarchyCardValue).ToList();
            }
            else
            {
                MessageBox.Show(MissingDeckMsgBoxItemHolder.Text,
                    MissingDeckMsgBoxItemHolder.Caption,
                    MissingDeckMsgBoxItemHolder.Button,
                    MissingDeckMsgBoxItemHolder.Icon);
            }
     
          
        }



        private void BtnOBHVdesc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                var myClass = dataGridView1.DataSource as List<PlayingCard>;
                if (myClass != null)
                    dataGridView1.DataSource = myClass.OrderByDescending(t => t.OverAllHierarchyCardValue).ToList();
            }
            else
            {
                MessageBox.Show(MissingDeckMsgBoxItemHolder.Text,
                    MissingDeckMsgBoxItemHolder.Caption,
                    MissingDeckMsgBoxItemHolder.Button,
                    MissingDeckMsgBoxItemHolder.Icon);
            }
        }

        private void BtnGoToDataValidation_Click(object sender, EventArgs e)
        {
            if (!Program.IsForm2Loaded)
            {
                var f = new Form2();
                f.Show();
            }
            else
            {
                MessageBox.Show(@"No need to have 2 of the same open for this example.", @"Your form is already open.");
            }
        }
    }
}
