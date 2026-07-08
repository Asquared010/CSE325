# Week 1 Notes

## Part 1: Additional Pizza Record

The original pizza list contained:

```csharp
new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
```

Additional pizza record added:

```csharp
new Pizza { Id = 3, Name = "Pepperoni", IsGlutenFree = false }
```

---

## Part 2: API Testing Evidence

### GET Request

Request:

```http
GET /pizza
```

Response Status Code:

```text
200 OK
```

---

### POST Request

Request:

```http
POST /pizza
Content-Type: application/json

{
    "name": "Hawaiian",
    "isGlutenFree": false
}
```

Response Status Code:

```text
201 Created
```

---

### PUT Request

Request:

```http
PUT /pizza/3
Content-Type: application/json

{
    "id": 3,
    "name": "Hawaiian Deluxe",
    "isGlutenFree": false
}
```

Response Status Code:

```text
204 No Content
```

---

### DELETE Request

Request:

```http
DELETE /pizza/3
```

Response Status Code:

```text
204 No Content
```

---

## Part 3: Sales Summary Function

```csharp
string GenerateSalesReport(IEnumerable<string> salesFiles)
{
    StringBuilder report = new();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");

    double grandTotal = 0;

    report.AppendLine("Details:");

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);

        SalesData? data =
            JsonConvert.DeserializeObject<SalesData>(salesJson);

        double fileTotal = data?.Total ?? 0;

        grandTotal += fileTotal;

        string storeName =
            Path.GetFileName(Path.GetDirectoryName(file) ?? "");

        string fileName =
            Path.GetFileName(file);

        report.AppendLine(
            $"{storeName}\\{fileName}: {fileTotal:C}");
    }

    report.AppendLine();
    report.AppendLine($"Total Sales: {grandTotal:C}");

    return report.ToString();
}
```

---

## Part 4: Sample Sales Report Output

```text
Sales Summary
----------------------------
Details:
stores\sales.json: $88.88
201\sales.json: $501.22
202\sales.json: $1,234.22
203\sales.json: $99.00
204\sales.json: $88.88

Total Sales: $2,012.20
```
