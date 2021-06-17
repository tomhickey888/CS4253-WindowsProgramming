using System;
using System.Collections.Generic;
using System.IO;

namespace HealthProfileGenerator
{
    class FileOperations
    {
        //Path to file to be read or written to
        public string fileName = "C:\\temp\\Patients.txt";

        //Method to read a file into the patient list
        public void ReadFile(List<Patient> patientList)
        {
            patientList.Clear();
            patientList.Add(new Patient());

            StreamReader file = new StreamReader(fileName);

            //Variable for each line from file
            string person;

            //Read each line until you reach null 
            while ((person = file.ReadLine()) != null)
            {
                string[] words = person.Split(',');

                //Check if the line splits into the correct number of fields
                if (words.Length == 10)
                {
                    //Check to see if the line in the file is new or already in list
                    bool check = true;
                    foreach (Patient p in patientList)
                    {
                        if (p.fname == words[0] && p.lname == words[1] && p.birthYear == Convert.ToInt32(words[5]) && p.birthMonth == Convert.ToInt32(words[6]))
                        {
                            check = false;
                        }
                    }

                    //If data is new add the person to the contact list
                    if (check == true)
                    {
                        patientList.Add(new Patient(words[0], words[1], words[2], Convert.ToDouble(words[3]), Convert.ToDouble(words[4]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7]), Convert.ToInt32(words[8]), Convert.ToInt32(words[9])));
                    }
                }
            }
            file.Close();
        }

        //Method to write a new patient in the patient list to a text file
        public void WriteListToFile(List<Patient> patientList, Patient patient)
        {
            StreamReader file = new StreamReader(fileName);

            //Variable for each line from file
            string person;

            //List of all Patients in the file that have been read in
            List<Patient> fileList = new List<Patient>();

            //Read each line until you reach null 
            while ((person = file.ReadLine()) != null)
            {
                string[] words = person.Split(',');

                //Check if the line splits into the correct number of fields
                if (words.Length == 10)
                {
                   fileList.Add(new Patient(words[0], words[1], words[2], Convert.ToDouble(words[3]), Convert.ToDouble(words[4]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7]), Convert.ToInt32(words[8]), Convert.ToInt32(words[9])));
                }
            }
            file.Close();

            fileList.Add(patient);

            StreamWriter fileWrite = new StreamWriter(fileName);
            foreach (Patient p in fileList)
            {
                fileWrite.WriteLine(string.Format($"{p.fname},{p.lname},{p.gender},{p.height.ToString()},{p.weight.ToString()},{p.birthYear.ToString()},{p.birthMonth.ToString()},{p.currentDay.ToString()},{p.currentMonth.ToString()},{p.currentYear.ToString()}"));
            }
            fileWrite.Close();
        }
    }
}
