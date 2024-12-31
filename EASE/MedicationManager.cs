using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASE
{
    public class Medication
    {
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Time { get; set; }
        public string Notes { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine("\tMedication: {0}\n\tDosage: {1}\n\tTime [HH:mm]: {2}\n\tNotes: {3}\n", Name, Dosage, Time, Notes);
        }
    }

    public class MedicationManager
    {
        private List<Medication> medication = new List<Medication>();

        public void AddMedication(string name, string dosage, string time, string notes)
        {
            Medication newMedication = new Medication();

            newMedication.Name = name;
            newMedication.Dosage = dosage;
            newMedication.Time = time;
            newMedication.Notes = notes;

            medication.Add(newMedication);
            Console.WriteLine("\n\tNew Medication Added Successfully.");
        }

        public void ViewMedications()
        {
            if (medication.Count == 0)
            {
                Console.WriteLine("\n\tNo Medication Available.");
                return;
            }
            Console.WriteLine("\n\tMedication List:\n");
            foreach (var medicationList in medication)
            {
                medicationList.DisplayDetails();
            }
        }

        public void UpdateMedication(string name)
        {
            var medToUpdate = medication.Find(med => med.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (medToUpdate == null)
            {
                Console.WriteLine("\n\tMedication not found!");
            }
            else
            {
                string newDosage = Validation.GetNonEmptyString("\tEnter dosage (e.g., 500 mg, 10 mL, 2 tablets): ");
                string newTime = Validation.GetValidTime("\tEnter the new time (HH:mm): ");
                string newNotes = Validation.GetNonEmptyString("\tEnter the new note(s): ");

                medToUpdate.Dosage = newDosage;
                medToUpdate.Time = newTime;
                medToUpdate.Notes = newNotes;

                Console.WriteLine("\n\tMedication updated successfully!");
            }

        }

        public void DeleteMedication(string name)
        {
            var medToDelete = medication.Find(med => med.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (medToDelete != null)
            {
                medication.Remove(medToDelete);
                Console.WriteLine("\n\tMedication deleted successfully!");
            }
            else
            {
                Console.WriteLine("\n\tMedication not found!");
            }

        }

        public void DisplayDailyReminders()
        {
            if (medication.Count == 0)
            {
                Console.WriteLine("\n\tNo medications scheduled for today.");
                return;
            }

            Console.WriteLine("\n\tToday's Medication Reminders:\n");

            var sortedMedications = medication.OrderBy(med => med.Time).ToList();

            foreach (var med in sortedMedications)
            {
                med.DisplayDetails();
            }
        }
    }

}
