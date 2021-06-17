using System;

namespace HealthProfileGenerator
{
    class Patient
    {
        //Initial Attributes
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public int birthYear { get; set; }
        public int birthMonth { get; set; }
        public int currentDay { get; set; }
        public int currentMonth { get; set; }
        public int currentYear { get; set; }

        //Calculated Attributes
        public string name { get; set; }
        public int age { get; set; }
        public int maxHR { get; set; }
        public int minTargetHR { get; set; }
        public int maxTargetHR { get; set; }
        public double BMI { get; set; }
        public string healthStatus { get; set; }
        public int birthDay { get; set; }

        //Default Constructor
        public Patient()
        {
            //Set initial attributes to default values
            fname = "John";
            lname = "Doe";
            gender = "Male";
            height = 70;
            weight = 170;
            birthYear = 2000;
            birthMonth = 1;
            currentDay = 1;
            currentMonth = 1;
            currentYear = 2021;

            //Randomly generate birth day based on birth month
            var rand = new Random();
            if (birthMonth == 9 || birthMonth == 4 || birthMonth == 6 || birthMonth == 11) { birthDay = rand.Next(1, 30); }
            else if (birthMonth == 2) { birthDay = rand.Next(1, 28); }
            else { birthDay = rand.Next(1, 31); }

            //Calculate Attributes
            name = $"{fname} {lname}";
            age = (currentYear - birthYear) - 1;
            if (currentMonth > birthMonth)
            {
                age++;
            }
            else if (currentMonth == birthMonth && currentDay >= birthDay)
            {
                age++;
            }
            maxHR = 220 - age;
            minTargetHR = Convert.ToInt32(0.50 * maxHR);
            maxTargetHR = Convert.ToInt32(0.85 * maxHR);
            BMI = Math.Round(((weight / Math.Pow(height, 2)) * 703), 1, MidpointRounding.AwayFromZero);

            //Determine Health Status based on BMI
            if (BMI < 18.5) { healthStatus = "Underweight"; }
            else if (BMI < 18.5) { healthStatus = "Normal"; }
            else if (BMI < 18.5) { healthStatus = "Overweight"; }
            else { healthStatus = "Obese"; }
        }

        //Parameter Constructor
        public Patient(string fname,string lname,string gender,double height,double weight,int birthYear,int birthMonth,int currentDay,int currentMonth,int currentYear)
        {
            //Set initial attributes to parameter values
            this.fname = fname;
            this.lname = lname;
            this.gender = gender;
            this.height = height;
            this.weight = weight;
            this.birthMonth = birthMonth;
            this.birthYear = birthYear;
            this.currentDay = currentDay;
            this.currentMonth = currentMonth;
            this.currentYear = currentYear;

            //Randomly generate birth day based on birth month
            var rand = new Random();
            if (birthMonth == 9 || birthMonth == 4 || birthMonth == 6 || birthMonth == 11) { birthDay = rand.Next(1, 30); }
            else if (birthMonth == 2) { birthDay = rand.Next(1, 28); }
            else { birthDay = rand.Next(1, 31); }

            //Calculate Attributes
            name = $"{fname} {lname}";
            age = currentYear - birthYear;
            if (currentMonth > birthMonth)
            {
                age++;
            }
            else if (currentMonth == birthMonth && currentDay >= birthDay)
            {
                age++;
            }
            maxHR = 220 - age;
            minTargetHR = Convert.ToInt32(0.50 * maxHR);
            maxTargetHR = Convert.ToInt32(0.85 * maxHR);
            BMI = Math.Round(((weight / Math.Pow(height, 2)) * 703), 1, MidpointRounding.AwayFromZero);

            //Determine Health Status based on BMI
            if (BMI < 18.5) { healthStatus = "Underweight"; }
            else if (BMI >=18.5 && BMI < 25.0) { healthStatus = "Normal"; }
            else if (BMI >= 25.0 && BMI < 30) { healthStatus = "Overweight"; }
            else { healthStatus = "Obese"; }
        }
    }
}
