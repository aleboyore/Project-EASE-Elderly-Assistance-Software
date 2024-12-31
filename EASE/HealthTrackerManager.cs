using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASE
{
    public class HealthData
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public int? Age { get; set; }
        public string BloodPressure { get; set; }
        public double? BloodSugar { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int? HeartRate { get; set; }
        public double? Temperature { get; set; }
        public double? BMI { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine("\tDate [DD-MM-YYYY]: " + Date +
                      "\n\tTime [HH:mm]: " + Time +
                      "\n\tAge: " + (Age.HasValue ? Age.ToString() : "Not provided") +
                      "\n\tHeight [cm]: " + Height +
                      "\n\tWeight [kg]: " + Weight +
                      "\n\tBlood Pressure [mmHg]: " + (string.IsNullOrEmpty(BloodPressure) ? "Not provided" : BloodPressure) +
                      "\n\tBlood Sugar [mg/dL]: " + (BloodSugar.HasValue ? BloodSugar.ToString() : "Not provided") +
                      "\n\tHeart Rate [bpm]: " + (HeartRate.HasValue ? HeartRate.ToString() : "Not provided") +
                      "\n\tTemperature [°C]: " + (Temperature.HasValue ? Temperature.ToString() : "Not provided"));
        }
    }

    public class HealthTracker
    {
        private List<HealthData> healthData = new List<HealthData>();

        public void AddRecord(string date, string time, int? age, string bloodPressure, double? bloodSugar, double height, double weight, int? heartRate, double? temperature)
        {
            HealthData newHealthData = new HealthData();

            newHealthData.Date = date;
            newHealthData.Time = time;
            newHealthData.Age = age;
            newHealthData.BloodPressure = bloodPressure;
            newHealthData.BloodSugar = bloodSugar;
            newHealthData.Height = height;
            newHealthData.Weight = weight;
            newHealthData.HeartRate = heartRate;
            newHealthData.Temperature = temperature;

            if (height > 0 && weight > 0)
            {
                newHealthData.BMI = CalculateBMI(height, weight);
            }

            healthData.Add(newHealthData);
            Console.WriteLine("\n\tHealth record added successfully!");
        }

        public void ViewRecords()
        {
            if (healthData.Count == 0)
            {
                Console.WriteLine("\n\tNo health records available.");
                return;
            }

            Console.WriteLine("\n\tHealth Records:\n");
            foreach (var healthRecord in healthData)
            {
                healthRecord.DisplayDetails();
            }
        }

        public void ViewBMIRecords()
        {
            if (healthData.Count == 0)
            {
                Console.WriteLine("\n\tNo health records available for BMI.");
                return;
            }

            Console.WriteLine("\n\tBMI Records by Day:\n");
            foreach (var healthRecord in healthData)
            {
                if (healthRecord.Height > 0 && healthRecord.Weight > 0) // Ensure both height and weight are available
                {
                    double bmi = CalculateBMI(healthRecord.Height, healthRecord.Weight);
                    string bmiCategory = GetBMICategory(bmi); // Get BMI category
                    Console.WriteLine("\tDate: " + healthRecord.Date + " - BMI: " + bmi.ToString("F2") + " (" + bmiCategory + ")");
                }
            }
        }


        public void ViewSummary()
        {
            if (healthData.Count == 0)
            {
                Console.WriteLine("\n\tNo health records to summarize.");
                return;
            }

            Console.WriteLine("\n\tSummary of Health Data:\n");

            foreach (var healthRecord in healthData)
            {
                Console.WriteLine("\n\tDate: " + healthRecord.Date);
                Console.WriteLine("\tBlood Pressure: " + healthRecord.BloodPressure + " (" + GetBloodPressureClassification(healthRecord.BloodPressure) + ")");
                Console.WriteLine("\tBlood Sugar: " + (healthRecord.BloodSugar.HasValue ? healthRecord.BloodSugar.ToString() : "Not provided") + " (" + GetBloodSugarClassification(healthRecord.BloodSugar) + ")");

                Console.WriteLine("\tHeart Rate: " + (healthRecord.HeartRate.HasValue ? healthRecord.HeartRate.ToString() : "Not provided") + " (" + GetHeartRateClassification(healthRecord.HeartRate) + ")");

                Console.WriteLine("\tTemperature: " + (healthRecord.Temperature.HasValue ? healthRecord.Temperature.ToString() : "Not provided") + " (" + GetTemperatureClassification(healthRecord.Temperature) + ")");

                if (healthRecord.Height > 0 && healthRecord.Weight > 0)
                {
                    double bmi = CalculateBMI(healthRecord.Height, healthRecord.Weight);
                    Console.WriteLine("\tBMI: " + bmi.ToString("F2") + " (" + GetBMICategory(bmi) + ")");
                }
                else
                {
                    Console.WriteLine("\tBMI: Not calculated");
                }
            }
        }


        public double CalculateBMI(double height, double weight)
        {
            //	         BMI = weight (kg) / height (m)^2
            double heightInMeters = height / 100;
            return weight / (heightInMeters * heightInMeters);
        }

        public static string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                return "Normal weight";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                return "Overweight";
            }
            else
            {
                return "Obese";
            }
        }

        public static string GetHeartRateClassification(int? heartRate)
        {
            if (heartRate.HasValue)
            {
                if (heartRate.Value < 60)
                {
                    return "Low";
                }
                else if (heartRate.Value >= 60 && heartRate.Value <= 100)
                {
                    return "Normal";
                }
                else
                {
                    return "High";
                }
            }
            else
            {
                return "Not provided";
            }
        }

        public static string GetTemperatureClassification(double? temperature)
        {
            if (temperature.HasValue)
            {
                if (temperature.Value < 36.1)
                {
                    return "Hypothermia";
                }
                else if (temperature.Value >= 36.1 && temperature.Value <= 37.2)
                {
                    return "Normal";
                }
                else
                {
                    return "Fever";
                }
            }
            else
            {
                return "Not provided";
            }
        }


        public string GetBloodPressureClassification(string bloodPressure)
        {
            if (string.IsNullOrEmpty(bloodPressure)) return "Not provided";

            string[] parts = bloodPressure.Split('/');
            if (parts.Length != 2) return "Invalid format";

            int systolic = int.Parse(parts[0]);
            int diastolic = int.Parse(parts[1]);

            if (systolic < 120 && diastolic < 80) return "Normal";
            if (systolic >= 120 && systolic <= 129 && diastolic < 80) return "Elevated";
            if (systolic >= 130 || diastolic >= 80) return "Hypertension";

            return "Unclassified";
        }

        public string GetBloodSugarClassification(double? bloodSugar)
        {
            if (!bloodSugar.HasValue) return "Not provided";

            if (bloodSugar < 70) return "Low";
            if (bloodSugar >= 70 && bloodSugar <= 100) return "Normal";
            if (bloodSugar > 100 && bloodSugar <= 125) return "Pre-diabetes";
            return "Diabetes";
        }
    }

}
