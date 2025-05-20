Perfekt, här kommer en **komplett startguide** anpassad för **Visual Studio Code + ASP.NET Core Web API + JSON-server (för frontendtest)** med fokus på din students behov.

---

## ✅ **Överblick: Vad ska byggas**

- 🧠 **Backend**: ASP.NET Core REST API i C#

  - Med en **Controller**
  - En **Model**: `Ruta` (med färg + koordinater)
  - En **Repository/Service**-struktur (valfritt men rekommenderat)

- 🎨 **Frontend**: valfritt (JS/React t.ex.), hämtar data via **json-server** (för mock), men till slut kopplas mot riktiga API\:et

---

## 🔧 1. Vad studenten behöver installera

### 📦 **Verktyg och installationer**

| Verktyg                                                        | Ladda ner / installera                                       |
| -------------------------------------------------------------- | ------------------------------------------------------------ |
| [.NET SDK (8.0+)](https://dotnet.microsoft.com/en-us/download) | Krävs för att köra ASP.NET-appar                             |
| [Visual Studio Code](https://code.visualstudio.com/)           | Redigerare                                                   |
| **C# Extension**                                               | `ms-dotnettools.csharp` (via VS Code Marketplace)            |
| (valfritt) REST Client                                         | För att testa API\:et direkt i VS Code (`humao.rest-client`) |
| Terminal / Bash                                                | Git Bash, PowerShell, zsh etc.                               |

---

## 📁 2. Skapa projekt

```bash
dotnet new webapi -n RutaApi
cd RutaApi
code .
```

Detta skapar ett ASP.NET Core Web API-projekt med en Controller och Swagger (OpenAPI) för test.

---

## 🎯 3. Model: `Ruta.cs`

Skapa i `Models/Ruta.cs`:

```csharp
namespace RutaApi.Models;

public class Ruta {
    public int Id { get; set; }
    public string Färg { get; set; } = "blå"; // defaultvärde
    public int X { get; set; }
    public int Y { get; set; }
}
```

---

## 🧠 4. Controller: `RutaController.cs`

Skapa i `Controllers/RutaController.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;
using RutaApi.Models;

namespace RutaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RutaController : ControllerBase
{
    private static List<Ruta> _rutor = new() {
        new Ruta { Id = 1, Färg = "röd", X = 10, Y = 20 },
        new Ruta { Id = 2, Färg = "grön", X = 50, Y = 100 }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Ruta>> GetAll() => Ok(_rutor);

    [HttpGet("{id}")]
    public ActionResult<Ruta> GetById(int id)
    {
        var ruta = _rutor.FirstOrDefault(r => r.Id == id);
        return ruta == null ? NotFound() : Ok(ruta);
    }

    [HttpPost]
    public ActionResult<Ruta> Create(Ruta ruta)
    {
        ruta.Id = _rutor.Max(r => r.Id) + 1;
        _rutor.Add(ruta);
        return CreatedAtAction(nameof(GetById), new { id = ruta.Id }, ruta);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Ruta updated)
    {
        var ruta = _rutor.FirstOrDefault(r => r.Id == id);
        if (ruta == null) return NotFound();

        ruta.Färg = updated.Färg;
        ruta.X = updated.X;
        ruta.Y = updated.Y;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var ruta = _rutor.FirstOrDefault(r => r.Id == id);
        if (ruta == null) return NotFound();

        _rutor.Remove(ruta);
        return NoContent();
    }
}
```

---

## 🌐 5. Testa API

Kör med:

```bash
dotnet run
```

Öppna i webbläsare:
[https://localhost:5001/swagger](https://localhost:5001/swagger)
Där kan du testa alla endpoints direkt (GET/POST/PUT/DELETE).

---

## 🔁 6. Använd json-server för frontend-utveckling

Om frontend ska utvecklas först kan ni börja med en mock-fil:

```json
// db.json
{
  "rutor": [
    { "id": 1, "färg": "röd", "x": 10, "y": 20 },
    { "id": 2, "färg": "grön", "x": 50, "y": 100 }
  ]
}
```

```bash
npx json-server --watch db.json --port 3001
```

Frontend kan hämta `http://localhost:3001/rutor` under utveckling.

Sen byter man till att hämta från `https://localhost:5001/api/ruta`.

---

## 📚 7. Sammanfattning

| Del                 | Vad gör den                                      |
| ------------------- | ------------------------------------------------ |
| `Ruta.cs`           | Model/Entity för API                             |
| `RutaController.cs` | REST API-endpoints för CRUD                      |
| `Program.cs`        | Konfiguration, körs automatiskt med `dotnet run` |
| `json-server`       | Tillfälligt API för frontend                     |

---

Vill du även ha:

✅ Instruktioner för att koppla frontend (ex. React) till API\:et?
✅ Repository + Service-lager med Entity Framework?
✅ Mall för README eller `.rest`-fil för att testa endpoints?

Säg bara till!
