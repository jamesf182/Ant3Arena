# 🐜 Ant Simulation System

This project is a simulation of ants with intelligent movement based on dynamic strategies.  

---

## 🚀 Technologies Used

- **.NET 8**
- **xUnit** – Unit testing framework  
- **NSubstitute** – Mocking library  
- **System.Drawing** – Image manipulation  
- **JSON** – Used to simulate a data source

---

## 🧠 Architecture Overview

The project follows a layered architecture:

```
Domain/         # Entities and pure interfaces  
Application/    # Orchestration logic 
Infrastructure/ # Repositories, file reading, logging  
```

### Key Components

- **Ant**: Represents an ant with color, position, and direction  
- **IMoveStrategy**: Interface for movement logic  
- **MoveStrategy**: Implements movement rules based on JSON strategies  
- **AntRepository**: Loads ant data from a local `ants.json` file  
- **AntColorizer**: Applies color to white pixels in the base ant image  

---

## 📂 JSON Structure (`ants.json`)

```json
[
  {
    "Color": "#FFFFFF",
    "HorizontalVelocity": 2,
    "VerticalVelocity": 2,
    "Quantity": 3,
    "Strategies": [
      {
        "Direction": "LeftUp",
        "X": "Decrease",
        "Y": "Decrease",
        "NextDirection": [
          {
            "Condition": "x < 0 AND y < 500",
            "Direction": "RightDown"
          },
          {
            "Condition": "x < 0",
            "Direction": "RightUp"
          },
          {
            "Condition": "y < 500",
            "Direction": "LeftDown"
          }
        ]
      }
    ]
  }
]
```

> Currently, the project uses a JSON file to simulate a data source.  
🔧 **Future improvement**: Replace the infrastructure layer to connect to a real database or external API for dynamic data retrieval.

---

## 🧪 Test Coverage

- The project has **90% unit test coverage**
- Tests are written using **xUnit** and **NSubstitute**

### Covered Components

- Ant behavior  
- Movement strategy logic  
- Image coloring  
- Data loading and validation  

### Run the Tests

```bash
dotnet test
```

---

## 📦 How to Run

Clone the repository:

```bash
git clone https://github.com/jamesf182/Ant3Arena.git
cd ant-simulation
```

Build the project:

```bash
dotnet build
```

Run the simulation (if applicable):

```bash
dotnet run --project src/AntSimulation
```

---

## 👨‍💻 Author

**James Santos Freitas Azarias**  
LinkedIn: [https://linkedin.com/in/jamesazarias](https://www.linkedin.com/in/james-freitas-b4998a124/)  
Email: jamesazarias@hotmail.com
