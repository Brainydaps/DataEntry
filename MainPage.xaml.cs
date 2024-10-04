using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace DataEntry
{
    public partial class MainPage : ContentPage
    {
        // Class-level variables to store user inputs, all fields declared as non-nullable
        private string name = string.Empty;
        private string location = string.Empty;
        private string whyYoureHere = string.Empty;
        private string relationship = string.Empty;
        private string sexuality = string.Empty;
        private string pets = string.Empty;
        private string personality = string.Empty;
        private string religion = string.Empty;
        private string starsign = string.Empty;
        private string work = string.Empty;
        private string school = string.Empty;
        private string havewantchildren = string.Empty;
        private string smoking = string.Empty;
        private string drinking = string.Empty;
        private string education = string.Empty;

        private int age = 0;
        private int numberOfBioLines = 0;
        private int numberOfHerPictures = 0;
        private int height = 0;
        private int languages = 0;
        private int prompts = 0;
        private int interests = 0;
        private int nils = 0;
        private int basicNils = 0;
        private int moreNils = 0;
        private int workedNils = 0;

        private string verified = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartDataEntryClicked(object sender, EventArgs e)
        {
            await StartDataEntry();
        }

        private async Task StartDataEntry()
        {
            // Prompt for Name
            name = await DisplayPromptAsync("Name", "Enter your name:");

            // Prompt for Location
            location = await DisplayPromptAsync("Location", "Enter your location:");

            // Continue collecting other data
            await CollectOtherData();
        }

        private async Task CollectOtherData()
        {
            // Age
            var ageInput = await DisplayActionSheet("Select Age", "Cancel", null, GetAgeOptions());
            if (ageInput != "Cancel") age = int.Parse(ageInput);

            // Verified Status
            verified = await DisplayActionSheet("Verified", "Cancel", null, "TRUE", "FALSE");
            

            // Number of Bio Lines
            var numberOfBioLinesInput = await DisplayActionSheet("Number of Bio Lines", "Cancel", null, GetNumberOptions(0, 20));
            if (numberOfBioLinesInput != "Cancel") numberOfBioLines = int.Parse(numberOfBioLinesInput);

            // Number of Her Pictures
            var numberOfHerPicturesInput = await DisplayActionSheet("Number of Her Pictures", "Cancel", null, GetNumberOptions(1, 80));
            if (numberOfHerPicturesInput != "Cancel") numberOfHerPictures = int.Parse(numberOfHerPicturesInput);

            // Why You're Here
            whyYoureHere = await DisplayActionSheet("Why You're Here", "Cancel", null, "Here to Date", "Open to Chat", "Ready for Relationship", "Nil");

            // Relationship Status
            relationship = await DisplayActionSheet("Relationship", "Cancel", null, "Single", "Taken", "It's Complicated", "Open", "I'd Rather Not Say", "Nil");

            // Sexuality
            sexuality = await DisplayActionSheet("Sexuality", "Cancel", null, "Nil", "Straight", "Gay", "Lesbian", "Bisexual", "Asexual", "Demisexual", "Pansexual", "Queer", "Questioning", "I'd Rather Not Say");

            // Children status 
            havewantchildren = await DisplayActionSheet("Children status", "Cancel", null, "Nil", "I'd like them someday", "I'd like them soon", "I don't want kids", "I already have kids", "I'd rather not say");

            // Smoking Status
            smoking = await DisplayActionSheet("Smoking", "Cancel", null, "Yes", "No", "Sometimes", "I'd Rather Not Say", "Nil");

            // Drinking Status
            drinking = await DisplayActionSheet("Drinking", "Cancel", null, "Socially", "Never", "Often", "Sober", "I'd Rather Not Say", "Nil");

            // Height Input
            var heightOptions = new string[] { "Nil" }.Concat(GetNumberOptions(92, 220)).ToArray();
            var heightInput = await DisplayActionSheet("Height (cm)", "Cancel", null, heightOptions);
            height = heightInput == "Nil" ? -1 : int.Parse(heightInput);

            // Education Level
            education = await DisplayActionSheet("Education", "Cancel", null, "Nil", "High School", "Graduate Degree or Higher", "In Grad School", "In College", "Undergraduate Degree", "I'd Rather Not Say");

            // Personality Type
            personality = await DisplayActionSheet("Personality", "Cancel", null, "Introvert", "Extrovert", "Somewhere In Between", "I'd Rather Not Say", "Nil");

            // Pets Info
            pets = await DisplayActionSheet("Pets", "Cancel", null, "Nil", "Cats", "Dogs", "Both Cats and Dogs", "Other Animals", "No Pets", "I'd Rather Not Say");

            // Religion
            religion = await DisplayActionSheet("Religion", "Cancel", null, "Nil", "Agnostic", "Atheist", "Buddhist", "Catholic", "Christian", "Hindu", "Muslim", "Other", "spiritual", "Sikh", "Jain", "Jewish", "Mormon", "Zoroastrian", "I'd rather not say");

            // Star Sign
            starsign = await DisplayActionSheet("Star Sign", "Cancel", null, "Nil", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces");

            // Languages Spoken
            languages = int.Parse(await DisplayActionSheet("Languages", "Cancel", null, GetNumberOptions(0, 10)));

            // Prompts
            prompts = int.Parse(await DisplayActionSheet("Prompts", "Cancel", null, GetNumberOptions(0, 3)));

            // Work Information
            work = await DisplayActionSheet("Work", "Cancel", null, "Nil", "Enter Work Info");
            if (work == "Enter Work Info")
            {
                work = await DisplayPromptAsync("Work", "Enter Work Info:");
            }

            // School Information
            school = await DisplayActionSheet("School", "Cancel", null, "Nil", "Enter School Info");
            if (school == "Enter School Info")
            {
                school = await DisplayPromptAsync("School", "Enter School", "Enter School Info:");
            }

            // Interests
            interests = int.Parse(await DisplayActionSheet("Interests", "Cancel", null, GetNumberOptions(0, 20)));

            // Calculate the number of "Nil" responses
            CalculateNils();

            // Display the summary of collected data for user confirmation
            string dataSummary = $"Name: {name}\nAge: {age}\nLocation: {location}\nVerified: {verified}\n" +
                $"Number of Bio Lines: {numberOfBioLines}\nNumber of Her Pictures: {numberOfHerPictures}\nWhy You're Here: {whyYoureHere}\n" +
                $"Relationship: {relationship}\nSexuality: {sexuality}\nChildren: {havewantchildren}\nSmoking: {smoking}\nDrinking: {drinking}\nHeight: {height}\n" +
                $"Education: {education}\nPersonality: {personality}\nPets: {pets}\nReligion: {religion}\nStar Sign: {starsign}\n" +
                $"Languages: {languages}\nPrompts: {prompts}\nWork: {work}\nSchool: {school}\nInterests: {interests}\n" +
                $"Nils: {nils}\nBasic Nils: {basicNils}\nMore Nils: {moreNils}\nWorked Nils: {workedNils}\n";

            bool confirm = await DisplayAlert("Review Your Data", dataSummary, "Save", "Edit");

            // If confirmed, proceed to save the data
            if (confirm)
            {
                OnSaveDataClicked(null, EventArgs.Empty);
            }
            else
            {
                await DisplayAlert("Edit", "Please update your data.", "OK");
            }
        }

        // Calculate the number of "Nil" responses for various categories
        private void CalculateNils()
        {
            nils = basicNils = moreNils = workedNils = 0;

            // Basic Nil categories
            if (whyYoureHere == "Nil") basicNils++;
            if (relationship == "Nil") basicNils++;
            if (sexuality == "Nil") basicNils++;

            // More Nil categories
            if (havewantchildren == "Nil") moreNils++;
            if (smoking == "Nil") moreNils++;
            if (drinking == "Nil") moreNils++;
            if (height == -1) moreNils++;  // Assuming -1 as Nil height
            if (education == "Nil") moreNils++;
            if (personality == "Nil") moreNils++;
            if (pets == "Nil") moreNils++;
            if (religion == "Nil") moreNils++;
            if (starsign == "Nil") moreNils++;

            // Worked Nil categories
            if (work == "Nil") workedNils++;
            if (school == "Nil") workedNils++;

            nils = basicNils + moreNils + workedNils;
        }

        // Helper method to generate numeric options for DisplayActionSheet
        private string[] GetNumberOptions(int min, int max)
        {
            return Enumerable.Range(min, max - min + 1).Select(x => x.ToString()).ToArray();
        }

        // Helper method to generate age options
        private string[] GetAgeOptions()
        {
            // Assuming a range of ages from 18 to 99
            return Enumerable.Range(18, 82).Select(age => age.ToString()).ToArray();
        }

        // Save Data
        private async void OnSaveDataClicked(object sender, EventArgs e)
        {
            // Define the file path for saving the CSV file
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BadooFormula.csv");

            // Define the headers for the CSV file
            string csvHeader = "name,age,location,verified,numberofbiolines,numberofherpictures,whyyourehere,relationship,sexuality,havewantchildren,smoking,drinking,height,education,personality,pets,religion,starsign,languages,prompts,work,school,interests,nils,basicnils,morenils,workednils,category";

            // Define the data row corresponding to the user input
            string csvData = $"{name},{age},{location},{verified},{numberOfBioLines},{numberOfHerPictures},{whyYoureHere},{relationship},{sexuality},{havewantchildren},{smoking},{drinking},{height},{education},{personality},{pets},{religion},{starsign},{languages},{prompts},{work},{school},{interests},{nils},{basicNils},{moreNils},{workedNils}";

            // Check if file exists, if not, write header first
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, csvHeader + Environment.NewLine);
            }

            // Append the CSV data row to the file
            File.AppendAllText(fileName, csvData + Environment.NewLine);

            // Display success message
            await DisplayAlert("Success", "Data saved successfully in CSV format.", "OK");
        }
    }
}
