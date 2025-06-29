# BudgetApp

**BudgetApp**, or **Our Two Cents**, is a simple budgeting tool with a spreadsheet-like interface.

## ✨ Features
- Create and manage budgets with a spreadsheet-style grid
- Manage fixed income or expenses and add them to budgets
- Visualize data with interactive charts
- Generate useful financial reports

## 🧱 Tech Stack
- Frontend: Blazor, MudBlazor
- Backend: C#, .NET
- Desktop App: Photino
- Database: Azure Cosmos DB

## 🚀 Getting Started
1. Create an Azure Cosmos DB resource.
2. Create a database and container with partition key "/id" in the Azure Cosmos DB resource.
3. Edit the container's Indexing Policy and add composite indexes for "year" and "month" (to enable ordering by year and month):
   ```
   "compositeIndexes": [
       [
           {
               "path": "/year"
           },
           {
               "path": "/month"
           }
       ]
   ]
   ```
4. Add the Azure Cosmos DB connection string to .NET User Secrets.
5. Add the database and container names to [appsettings.json](appsettings.json).