# Shared C# Development Rules

Rules for **non-UI** shared C# code such as Domain, Infrastructure, and backend services.  
For UI-related patterns (WPF, ViewModel, Command), see `WpfMvvmGuide.md`.

---

## 1. Design Principles

### 1.1 Separation of Concerns
- Clearly separate responsibilities by layer
- Do not mix business logic with infrastructure or presentation

### 1.2 Maintainability
- Write code that is easy to read and modify
- Avoid excessive abstraction

### 1.3 Consistency
- Use consistent naming, structure, and patterns across the project

---

## 2. Naming

### Pattern (Optional)
```
{Domain}_{Feature}_{Detail}
```
Examples: `User_Create`, `Order_Process_Payment`

### Basic Rules
- Use meaningful, descriptive names
- Avoid abbreviations unless widely accepted
- Keep naming consistent across layers

---

## 3. Method Design

### Structure
- One method should perform one clear task
- Keep methods short and focused

### Parameters
- Prefer DTOs when there are many parameters
- Validate inputs at the beginning of the method

### Return Values
- Use consistent return types
- Prefer wrapping results in a standard response object when applicable

---

## 4. Exception Handling

- Do not swallow exceptions
- Catch only where meaningful handling is possible
- Always log exceptions

```csharp
try
{
    // business logic
}
catch (Exception ex)
{
    _logger.LogError(ex, "Operation failed");
    throw;
}
```

- Do not use exceptions for normal control flow
- Provide clear and useful error messages

---

## 5. Logging

- Log important operations and state changes
- Use appropriate levels (Information, Warning, Error)

---

## 6. Constants Management

- Do not hardcode strings or numbers
- Centralize constants in a single place

```csharp
public static class Constants
{
    public const string DefaultUserRole = "User";
}
```

---

## 7. Dependency Management

- Prefer dependency injection over direct instantiation
- Avoid global or static state
- Services should depend on interfaces
- Keep dependencies minimal and explicit

---

## 8. Code Safety

- Validate external input
- Handle null values explicitly
- Avoid unsafe operations unless necessary
