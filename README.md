# **BioFusion Biofabrication Project**

## **BioFusion:**

**AXIS.App** – Sustainable Biofabrication Simulation Platform

## **Description:**

This project aims to provide a complete platform for modeling, simulating, and managing biofabrication processes. The system integrates a Python-based simulation engine with a .NET Blazor WebAssembly frontend and an ASP.NET Core backend.

Key objectives:

* Model biofabrication products with base and extended variables.
* Execute dynamic simulations using Python formulas.
* Manage and persist data efficiently with Entity Framework Core.
* Provide an interactive UI for visualization and control.
* Follow Clean Architecture principles for scalability and maintainability.

---

## **Architecture Overview:**

### **1. AXIS.App.UI** – User Interface

Handles interaction with the user and displays simulation results.

* `Program.cs` – Application entry point.
* `Pages/` – Razor pages for UI components (e.g., Counter.razor.cs, ProductPage.razor.cs).
* `Layout/` – Layout components for navigation and page structure.
* `App.razor.cs` – Main app component.
* `_Imports.razor.cs` – Common imports for Razor pages.

---

### **2. AXIS.App.Core** – Domain Layer

Contains the core business entities, enums, DTOs, validators, and interfaces.

* **Data/**

  * `ApplicationDbContext.cs` – EF Core DbContext with entity configurations.
* **Entities/**
  (All domain entities, e.g., `TaskPlan.cs`, `Product.cs`, `Variable.cs`)
* **Enums/**
  (Enumerations like `ProcessType.cs`, `Unit.cs`)
* **Dtos/**
  (Data Transfer Objects for moving data across layers)
* **FluentValidation/**
  (Validators for domain entities, e.g., `TaskPlanValidator.cs`)
* **Repositories/**
  (Interfaces like `ITaskRepository.cs` for abstraction)
* **AutoMapper/**
  (Mapping profiles for DTOs and entities)

---

### **3. AXIS.App.Application** – Application Services

Contains services for business logic and use cases.

* `Services/`
  (e.g., `ProductService.cs`, `TaskService.cs`)

---

### **4. AXIS.App.Infrastructure** – Data Access Layer

Implements repository interfaces and handles data persistence.

* `Repositories/`
  (e.g., `TaskRepository.cs`)

---

### **5. AXIS.App.Shared** – Shared Layer

Contains shared DTOs, ViewModels, and components used across UI and services.

* `TaskPlanViewModel.cs`

---

### **6. AXIS.App.Tests** – Unit & Integration Tests

Contains test projects for verifying application logic and integration.

* `obj/` – Temporary build files
* (NuGet test SDK references)

---

## **Architecture Overview (Folder Structure)**

```

AXIS.App
├── AXIS.App.UI
│   ├── Program.cs
│   ├── Pages/
│   │   ├── Counter.razor.cs
│   │   └── ... (other Razor pages)
│   ├── Layout/
│   │   ├── LoginDisplay.razor.cs
│   │   ├── MainLayout.razor.cs
│   │   └── RedirectToLogin.razor.cs
│   ├── App.razor.cs
│   └── \_Imports.razor.cs
│
├── AXIS.App.Core
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Entities/
│   │   ├── TaskPlan.cs
│   │   ├── Product.cs
│   │   ├── Variable.cs
│   │   ├── Process.cs
│   │   ├── ProcessParameter.cs
│   │   ├── ApplicationUser.cs
│   │   └── AuditableEntity.cs
│   ├── Enums/
│   │   ├── ProcessType.cs
│   │   ├── VariableType.cs
│   │   ├── TaskStatus.cs
│   │   └── Unit.cs
│   ├── Repositories/
│   │   └── ITaskRepository.cs
│   ├── Dtos/
│   │   └── ... (DTO classes)
│   ├── FluentValidation/
│   │   └── ... (Validators for entities)
│   └── AutoMapper/
│       └── ... (Mapping profiles)
│
├── AXIS.App.Application
│   └── Services/
│       ├── ProductService.cs
│       └── TaskService.cs
│
├── AXIS.App.Infrastructure
│   └── Repositories/
│       └── TaskRepository.cs
│
├── AXIS.App.Shared
│   └── TaskPlanViewModel.cs
│
└── AXIS.App.Tests
├── obj/
└── ... (NuGet test SDK references)

```

---

💡 **Notes:**
- Follows **Clean Architecture**: separates UI, Domain, Application, and Infrastructure layers.  
- Python integration for simulations is accessed via service calls.  
- DTOs, AutoMapper, and FluentValidation are prepared for robust domain logic handling.  



