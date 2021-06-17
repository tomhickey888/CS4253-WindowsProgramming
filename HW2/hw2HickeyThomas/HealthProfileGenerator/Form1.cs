using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HealthProfileGenerator
{
    public partial class HealthProfileGenerator : Form
    {
        List<Patient> PatientList = new List<Patient>();
        int ListIndex = 1;
        
        public HealthProfileGenerator()
        {
            PatientList.Add(new Patient());
            InitializeComponent();
            comboGender.SelectedIndex = 0;
            textListInfo.Text = $"{ListIndex-1}/{PatientList.Count-1}";
        }

        //Method to update the values of the labels with the current Patient information
        void ListViewer()
        {
            if(ListIndex >= 1 && ListIndex < PatientList.Count)
            {
                textListInfo.Text = $"{ListIndex}/{PatientList.Count-1}";
                labelName.Text = PatientList[ListIndex].name;
                labelName.Visible = true;

                labelGender.Text = PatientList[ListIndex].gender;
                labelGender.Visible = true;

                labelAge.Text = PatientList[ListIndex].age.ToString();
                labelAge.Visible = true;

                labelMaxHeart.Text = PatientList[ListIndex].maxHR.ToString();
                labelMaxHeart.Visible = true;

                labelMinTarget.Text = PatientList[ListIndex].minTargetHR.ToString();
                labelMinTarget.Visible = true;

                labelMaxTarget.Text = PatientList[ListIndex].maxTargetHR.ToString();
                labelMaxTarget.Visible = true;

                labelHeight.Text = PatientList[ListIndex].height.ToString();
                labelHeight.Visible = true;

                labelBMI.Text = PatientList[ListIndex].BMI.ToString();
                labelBMI.Visible = true;

                labelBMIValue.Text = PatientList[ListIndex].healthStatus;
                labelBMIValue.Visible = true;
            }

            //If patient list is currently empty reset labels
            else if ( ListIndex == 0 )
            {
                labelName.Text = "";
                labelGender.Text = "";
                labelAge.Text = "";
                labelHeight.Text = "";
                labelMaxHeart.Text = "";
                labelMinTarget.Text = "";
                labelMaxTarget.Text = "";
                labelBMI.Text = "";
                labelBMIValue.Text = "";

                ListIndex = 1;
                textListInfo.Text = $"{ListIndex-1}/{PatientList.Count-1}";
            }
        }

        void AdvanceList()
        {
            if (ListIndex < PatientList.Count)
            {
                ListIndex++;
                ListViewer();
            }
        }

        void ReverseList()
        {
            if (ListIndex > 1)
            {
                ListIndex--;
                ListViewer();
            }
            
        }

        void ImportProfiles()
        {
            ListIndex = 0;
            ListViewer();

            FileOperations FO = new FileOperations();
            FO.ReadFile(PatientList);

            ListIndex = 1;
            ListViewer();
        }

        //Method to generate a new profile from user input and add it to the patient list using error messages to troubleshoot input validation
        public void GenerateProfile()
        {
            string fname = "";
            string lname = "";
            string gender = "";
            int birthYear = 0;
            int birthMonth = 0;
            int treatmentYear = 0;
            int treatmentMonth = 0;
            int treatmentDay = 0;
            double height = 0;
            double weight = 0;

            bool check = true;

            if (textFName.Text != "" && textLName.Text != "")
            {
                fname = textFName.Text;
                lname = textLName.Text;
            }
            else { MessageBox.Show("Error in first/last name field, please enter something for both first and last name", "Birthdate Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }

            if (comboGender.SelectedIndex != 0)
            {
                gender = comboGender.Text;
            }
            else { MessageBox.Show("Error in gender field, please select either Female or Male", "Gender Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }

            if (textBirthDate.Text != "MM/YYYY" && textTreatmentDate.Text != "MM/DD/YYYY")
            {
                string birthDateText = textBirthDate.Text;
                string treatmentDateText = textTreatmentDate.Text;

                string[] birthDate = birthDateText.Split('/');
                if (birthDate.Length == 2)
                {
                    if(Convert.ToInt32(birthDate[0]) < 13 && Convert.ToInt32(birthDate[0]) > 0) birthMonth = Convert.ToInt32(birthDate[0]);
                    else { MessageBox.Show("Error in birth month field, please enter only whole numbers between 1 and 12 for the birth month","Birth Month Error",MessageBoxButtons.OK,MessageBoxIcon.Error); check = false; }

                    if (Convert.ToInt32(birthDate[1]) < 2022 && Convert.ToInt32(birthDate[1]) > 1899) birthYear = Convert.ToInt32(birthDate[1]);
                    else { MessageBox.Show("Error in birth year field, please enter only whole numbers between 1900 and 2021 for the birth year", "Birth Year Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }

                    
                }
                else { MessageBox.Show("Error in birth date field, please enter only whole numbers in MM/YYYY format","Birth Date Error",MessageBoxButtons.OK,MessageBoxIcon.Error); check = false; }
                string[] treatmentDate = treatmentDateText.Split('/');
                if (treatmentDate.Length == 3)
                {
                    if (Convert.ToInt32(treatmentDate[0]) < 13 && Convert.ToInt32(treatmentDate[0]) > 0) treatmentMonth = Convert.ToInt32(treatmentDate[0]);
                    else {MessageBox.Show("Error in treatment month field, please enter only whole numbers between 1 and 12 for treatment month", "Treatment Month Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }

                    if (Convert.ToInt32(treatmentDate[1]) < 32 && Convert.ToInt32(treatmentDate[1]) > 0) treatmentDay = Convert.ToInt32(treatmentDate[1]);
                    else { MessageBox.Show("Error in treatment day field, please enter only whole numbers between 1 and 31 for treatment day", "Treatment Day Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }

                    if (Convert.ToInt32(treatmentDate[2]) < 2022 && Convert.ToInt32(treatmentDate[2]) > 1899) treatmentYear = Convert.ToInt32(treatmentDate[2]);
                    else { MessageBox.Show("Error in treatment year field, please enter only whole numbers between 1900 and 2021 for treatment year", "Treatment Year Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }
                }
                else { MessageBox.Show("Error in treatment date field, please enter only whole numbers in MM/DD/YYYY", "Treatment Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }
            }
            else { check = false; }

            if (textHeight.Text != "" && textWeight.Text != "")
            {
                height = Convert.ToInt32(textHeight.Text);
                weight = Convert.ToInt32(textWeight.Text);
            }
            else { MessageBox.Show("Error in height or weight field, please enter only whole numbers for inches in height and pounds in weight", "Height/Weight Error", MessageBoxButtons.OK, MessageBoxIcon.Error); check = false; }

            if (check == true)
            {
                //Adds new patient to patient list and displays the new patient in the list viewer
                PatientList.Add(new Patient(fname, lname, gender, height, weight, birthYear, birthMonth, treatmentDay, treatmentMonth, treatmentYear));
                ListIndex = PatientList.Count - 1;
                int last = PatientList.Count - 1;
                Patient newPatient = PatientList[last];
                ListViewer();
                
                //Writes updated list to the text file
                FileOperations FO = new FileOperations();
                FO.WriteListToFile(PatientList, newPatient);
            }
        }

        //Method to reset user fields, labels, and list index
        public void Clear()
        {
            //Reset all user fields
            textFName.Text = "";
            textLName.Text = "";
            comboGender.SelectedIndex = 0;
            textHeight.Text = "";
            textWeight.Text = "";
            textBirthDate.Text = "MMYYYY";
            textTreatmentDate.Text = "MMDDYYYY";

            //Reset the list index and viewer
            ListIndex = 1;
            ListViewer();
        }

        //Event handlers for when buttons are clicked
        private void buttonImportProfiles_Click(object sender, EventArgs e)
        {
            ImportProfiles();
        }

        private void buttonGenerateProfile_Click(object sender, EventArgs e)
        {
            GenerateProfile();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            ReverseList();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            AdvanceList();
        }

        //Event handlers for when menu items are clicked
        private void menuImportProfiles_Click(object sender, EventArgs e)
        {
            ImportProfiles();
        }

        private void menuGenerateProfile_Click(object sender, EventArgs e)
        {
            GenerateProfile();
        }

        private void menuClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //Event handlers for date fields coming into focus and mask input rejected
        private void textBirthDate_Enter(object sender, EventArgs e)
        {
            textBirthDate.Text = "";
            textBirthDate.Select(0, 0);
        }

        private void MMYYYY(object sender, MaskInputRejectedEventArgs e)
        {
            textBirthDate.Text = "MMYYYY";
            textTreatmentDate.Select(0, 0);
        }

        private void textTreatmentDate_Enter(object sender, EventArgs e)
        {
            textTreatmentDate.Text = "";
            textTreatmentDate.Select(0, 0);
        }

        private void textTreatmentDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            textTreatmentDate.Text = "MMDDYYYY";
            textTreatmentDate.Select(0, 0);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
