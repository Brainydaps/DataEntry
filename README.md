
# DataEntry Software

This is a custom-built data entry software designed to streamline the data collection process from sources that cannot easily be scraped. It prompts the user for input across various fields, summarizes the collected data for review, and finally saves the data in CSV format. This software is useful for speeding up manual data entry tasks, reducing errors, and ensuring data integrity.

## Features

- **User-Friendly Data Input**: The application prompts the user for input using easy-to-understand display alerts for each field.
- **Input Fields**: Collects inputs for multiple attributes such as:
  - Personal Information: Name, Location, Age, Verified Status
  - Profile Information: Number of Bio Lines, Number of Pictures, Work, School
  - Lifestyle: Relationship Status, Sexuality, Smoking, Drinking, Religion, Pets
  - Interests and Traits: Personality, Star Sign, Interests, Languages Spoken
  - Other Custom Fields: Why You're Here, Have/Want Children, Height, Education
- **Data Review**: After data collection, a summary of the inputted values is displayed, allowing the user to cross-check before saving the information.
- **CSV Export**: The validated data is saved into a CSV file, which can be used for analysis or further processing. The CSV headers are predefined to ensure consistent data format.

  ![Screenshot 2024-10-04 174652](https://github.com/user-attachments/assets/f40061bc-72b4-4a0e-b9de-3d12392f9b71)

## How It Works

1. **Prompt for Input**: The software sequentially prompts the user for each piece of information.
2. **Review and Confirm**: Once all data is entered, the user is presented with a summary of their inputs for confirmation.
3. **Save Data**: Upon confirmation, the data is saved in CSV format to the user's local storage.

![Screenshot 2024-10-04 174737](https://github.com/user-attachments/assets/96b38ed9-6b77-4dae-bee2-1b3717de1439)



### Example of CSV Data:
```
name, age, location, verified, numberofbiolines, numberofherpictures, whyyourehere, relationship, sexuality, havewantchildren, smoking, drinking, height, education, personality, pets, religion, starsign, languages, prompts, work, school, interests, nils, basicnils, morenils, workednils, category
John Doe, 29, New York, TRUE, 4, 6, Here to Date, Single, Straight, I'd like them someday, No, Socially, 175, Graduate Degree, Introvert, Cats, Christian, Libra, 2, 1, Software Engineer, NYU, 5, 3, 1, 2, 1, Dating
```
![Screenshot 2024-10-04 174858](https://github.com/user-attachments/assets/1f57c8b5-d62c-4403-908d-daa7966b4169)

## How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/DataEntry.git
   ```
2. Open the solution in Visual Studio and build the project.
3. Run the application on your target platform (Android, iOS, or Windows).

## Requirements

- .NET MAUI Framework
- Visual Studio 2022 (or later)
- .NET 6.0 (or later)

## Installation

1. Install the required dependencies for .NET MAUI following [Microsoft's instructions](https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation).
2. Clone the repository and build the project using Visual Studio.

## Contributing

Contributions are welcome! Please fork the repository, create a new branch, and submit a pull request with your changes.

## License

This project is licensed under the CC BY-NC 4.0 License. See the `LICENSE` file for more details.
