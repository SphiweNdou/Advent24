# Advent of Code 2024 – C# Solutions

This repository contains a series of C# console applications created to solve challenges from [Advent of Code 2024](https://adventofcode.com/2024). 
Each subproject corresponds to a specific day or part of a day’s challenge.

## 🧠 What’s Inside?

- ✏️ **Daily Puzzle Solutions** – implemented in separate C# projects (e.g., `Advent24_1`, `Advent24_2`, etc.)
- 📂 **Input Handling** – each project reads from an input file located in `Input/input.txt`
- 🧮 **Algorithmic Practice** – solutions feature logic for sorting, parsing, scoring, and more
- 🔁 **Standalone Execution** – every project can be run independently using the .NET CLI or Visual Studio

## 🧰 Tech Stack

- **Language:** C#
- **Framework:** .NET 6 or higher
- **IDE:** Visual Studio 2022
- **Structure:** Multi-project solution with shared problem-solving patterns

## 🛠️ Database Setup

Although these are mostly algorithm-based challenges, if persistence is required in future enhancements, a simple SQLite or in-memory database can be integrated using Entity Framework Core.

> **Note:** No database is used by default in this challenge suite.

## 🖼️ User Interface

This solution is **console-based**, with minimal UI by design. Each project prints output such as totals, scores, or matches directly to the console window after processing inputs.

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/SphiweNdou/Advent2024.git
   cd Advent2024
   ```

2. **Open the solution in Visual Studio**
   - File → Open → `Advent24.sln`

3. **Run a specific day’s project**
   - Open `Program.cs` inside a folder like `Advent24_1`
   - Ensure the `Input/input.txt` file exists
   - Run the project to see the console output

4. **OR use .NET CLI**
   ```bash
   cd Advent24_1
   dotnet run
   ```

## 📁 Folder Structure

Advent24.sln
├── Advent24_1/
├── Advent24_2/
├── Advent24_3/


Each folder contains:
- `Program.cs` – logic for solving the puzzle
- `Input/input.txt` – test data or challenge input

## 👨‍💻 Author

**Sphiwe Ndou**  
Software Developer | Full-Stack .NET Enthusiast  
GitHub: [@SphwieNdou](https://github.com/SphiweNdou)  
LinkedIn: [linkedin.com/in/ndivhuho-ndou-39246515a](https://linkedin.com/in/ndivhuho-ndou-39246515a)


