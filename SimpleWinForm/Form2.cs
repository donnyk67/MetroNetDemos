using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SimpleWinForm
{
    //For this example form I did not use dependency injection.
    //It is more for just showing the validation.
    public partial class Form2 : Form
    {
        private static int _jsonLoopCt;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Program.IsForm2Loaded = true;
            FillTextBoxWithRawJson();
            label1.Select();
            //just for example
            var j = new List<JsonDataClass>();
            dataGridView1.DataSource = j;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.IsForm2Loaded = false;
        }

        private void FillTextBoxWithRawJson()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var directoryInfo = Directory.GetParent(workingDirectory).Parent;
            if (directoryInfo == null) return;
            var projectDirectory = directoryInfo.FullName;
            var jSonText = File.ReadAllText(projectDirectory + @"\textData\JsonFile.txt");
            textBox1.Text = jSonText;
        }

        private IEnumerable<RawJsonData> GetRawJasonData()
        {
            // return JsonConvert.DeserializeObject<List<RawJsonData>>(textBox1.Text);
            var myRawList = JsonConvert.DeserializeObject<List<RawJsonData>>(textBox1.Text);
            var ct = 0;
            foreach (var i in myRawList)
            {
                i.Id = ct;
                ct += 1;
            }

            return myRawList;
        }

        private void btnLoopBegin_Click(object sender, EventArgs e)
        {

            ClearValidationLabels();

            var myRawList = GetRawJasonData();
            foreach (var i in myRawList)
            {
                if (i.Id != _jsonLoopCt) continue;
                txtCity.Text = i.CityName;
                txtEmail.Text = i.EmailAddress;
                txtFullName.Text = i.FullName;
                txtPhone.Text = i.PhoneNumber;
            }


        }


        private void ClearValidationLabels()
        {
            lblValFullName.Text = "";
            lblValCityName.Text = "";
            lblVarPhoneNumber.Text = "";
            lblVarEmailAddress.Text = "";
        }

        private void ClearTextBoxes()
        {
            txtCity.Text = "";
            txtEmail.Text = "";
            txtFullName.Text = "";
            txtPhone.Text = "";
        }



        private void btnValidate_Click(object sender, EventArgs e)
        {

            ClearValidationLabels();

            var j = new JsonDataClass
            {
                FullName = txtFullName.Text,
                CityName = txtCity.Text,
                PhoneNumber = txtPhone.Text,
                EmailAddress = txtEmail.Text
            };

            JsonDataClassValidator validator = new JsonDataClassValidator();

            var results = validator.Validate(j);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    switch (failure.PropertyName)
                    {
                        case "FullName":
                            lblValFullName.Text = @"Failed validation. Error was: " + failure.ErrorMessage;
                            break;
                        case "CityName":
                            lblValCityName.Text = @"Failed validation. Error was: " + failure.ErrorMessage;
                            break;
                        case "PhoneNumber":
                            lblVarPhoneNumber.Text = @"Failed validation. Error was: " + failure.ErrorMessage;
                            break;
                        case "EmailAddress":
                            lblVarEmailAddress.Text = @"Failed validation. Error was: " + failure.ErrorMessage;
                            break;

                    }


                }

            }
            else
            {

                var myClass = dataGridView1.DataSource as List<JsonDataClass>;
                if (myClass != null)
                {
                    myClass.Add(j);
                    dataGridView1.DataSource = myClass.ToList();
                }

                _jsonLoopCt += 1;
                lblLoopID.Text = (_jsonLoopCt + 1).ToString();

                MessageBox.Show(@"Passed Validation", @"Data Inserted Successfully", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ClearTextBoxes();
                bttnLoopBegin.PerformClick();

            }
        }

        private void BtnStep1_Click(object sender, EventArgs e)
        {

            var myStep1List = GetJsonStepData();
            var displayList = new List<RawJsonStepDisplay>();

            foreach (var item in myStep1List)
            {
                var disp = new RawJsonStepDisplay();
                disp.DisplayName = item.FullName;
                disp.DisplayOutput = item.DisplayOutput;
                displayList.Add(disp);
            }

            var displayMessage = $"Step 1: List all contact records with the following output:" +
                                 $"{Environment.NewLine}{Environment.NewLine}Full name" +
                                 $"{Environment.NewLine}Whether the phone and email fields are 'valid':" +
                                 $"{Environment.NewLine} Output 'Valid' if both email and phone are valid." +
                                 $"{Environment.NewLine} Output 'Email is invalid'. if email is invalid and phone is valid." +
                                 $"{Environment.NewLine} Output 'Phone is invalid.' if phone is invalid and email is valid." +
                                 $"{Environment.NewLine} Output 'Email and Phone are invalid.' if both phone and email are invalid." +
                                 $"{Environment.NewLine}{Environment.NewLine}Contacts should be sorted alphabetically in ascending order.";
            //

            MessageBox.Show(displayMessage, @"Step 1");
            dataGridView1.DataSource = displayList.OrderBy(t => t.DisplayName).ToList();

        }

        private void BtnStep2_Click(object sender, EventArgs e)
        {
            var myStep2List = GetJsonStepData();

            var uniqueCities = GetJsonStepData()
                .Select(p => p.CityName)
                .Distinct();
            var cityDisplaysList = uniqueCities.Select(city => new RawJsonStepDisplay {DisplayName = city}).ToList();
            foreach (var city in cityDisplaysList)
            {
                var ct = myStep2List.Where(data => data.CityName == city.DisplayName).Sum(data => data.ErrorCount);
                city.DisplayOutput = ct.ToString();
            }

            var displayMessage = $"Step 2: List each city and report the following output:" +
                                 $"{Environment.NewLine}{Environment.NewLine}Name of City" +
                                 $"{Environment.NewLine}Number of Validation Errors per City." +
                                 $"{Environment.NewLine}{Environment.NewLine}Contacts should be sorted alphabetically in ascending order.";
            //

            MessageBox.Show(displayMessage, @"Step 2");
            dataGridView1.DataSource = cityDisplaysList.OrderBy(t => t.DisplayName).ToList();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            }
        }

        private void BtnClearDataGrid_Click(object sender, EventArgs e)
        {
            //just for example
            var j = new List<JsonDataClass>();
            dataGridView1.DataSource = j;
            ClearTextBoxes();
            ClearValidationLabels();
            _jsonLoopCt = 0;
            lblLoopID.Text = @"0";


        }


        List<RawJsonStepData> GetJsonStepData()
        {
            var myRawList = JsonConvert.DeserializeObject<List<RawJsonData>>(textBox1.Text);
            var myStep1List = new List<RawJsonStepData>();
            JsonDataClassValidator validator = new JsonDataClassValidator();

            foreach (var r in myRawList)
            {
                var jd = new RawJsonStepData();
                var j = new JsonDataClass
                {
                    FullName = r.FullName,
                    CityName = r.CityName,
                    PhoneNumber = r.PhoneNumber,
                    EmailAddress = r.EmailAddress
                };
                jd.FullName = j.FullName;
                jd.CityName = j.CityName;
                jd.EmailAddress = j.EmailAddress;
                jd.PhoneNumber = j.PhoneNumber;

                var results = validator.Validate(j);
                if (!results.IsValid)
                {
                    jd.HasErrors = true;
                    jd.ErrorCount = results.Errors.Count;
                    foreach (var failure in results.Errors)
                    {
                        switch (failure.PropertyName)
                        {
                            case "PhoneNumber":
                                jd.PhoneError = @"Email is invalid"; // + failure.ErrorMessage;
                                break;
                            case "EmailAddress":
                                jd.EmailError = @"Phone is invalid"; // + failure.ErrorMessage;
                                break;
                        }
                    }
                }
                else
                {
                    jd.ErrorCount = 0;
                }

                if (jd.HasErrors)
                {
                    if (string.IsNullOrEmpty(jd.PhoneError) && !string.IsNullOrEmpty(jd.EmailError))
                        jd.DisplayOutput = jd.EmailError;
                    if (!string.IsNullOrEmpty(jd.PhoneError) && string.IsNullOrEmpty(jd.EmailError))
                        jd.DisplayOutput = jd.PhoneError;
                    if (jd.ErrorCount > 1) jd.DisplayOutput = @"Email and Phone are invalid.";

                }
                else
                {
                    jd.DisplayOutput = @"Valid";
                }

                myStep1List.Add(jd);

            }

            return myStep1List;
        }
    }
}
