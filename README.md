# IVF Success Calculator

## Overview

This application helps users estimate their chances of successful IVF. The backend calculates the success rate using a set of formulas provided in a CSV file, and the frontend displays the results!

## Solution

- React frontend to collect input like age, BMI, infertility reasons, etc.
- .NET backend handles the heavy lifting of selecting the correct formula and calculating the success rate.

## Getting Started

To get the project up and running on your local machine, follow these steps:

### 1. Install Dependencies

At the root of the project, install both frontend and backend dependencies by running:

```bash
npm install
```

This will install everything for both the frontend (React) and backend (.NET).

### 2. Run the Project

At the root of the project, to start both the frontend and backend, just run:

```bash
npm start
```

Open `http://localhost:3000` in your browser to start using the application.

### 3. Testing

The backend project includes unit tests for CalculateSuccessRateService based on the examples given in the instructions for the project. In the root of the project, run:

```bash
npm test
```

Enjoy!
