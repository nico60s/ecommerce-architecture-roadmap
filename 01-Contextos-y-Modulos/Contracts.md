# Contratos Públicos entre Módulos

## 📘 ¿Qué es un Contrato?

Un contrato representa la **frontera semántica y técnica** entre un módulo de negocio y el resto del sistema. Es una **estructura estable** que define:

- Qué comandos acepta (ej: `SignInCommand`)
- Qué consultas responde (ej: `GetUsuarioPorIdQuery`)
- Qué eventos publica (ej: `UsuarioRegistradoEvent`)
- Qué estructuras de datos devuelve (ej: `TokenDto`)

---

## 🎯 ¿Para qué sirve un contrato?

### 1. Establecer una frontera explícita
Permite definir claramente qué es **interno** al módulo y qué es **visible** hacia otros contextos.

### 2. Asegurar estabilidad
Evita que cambios internos del módulo rompan dependencias de otros módulos o del borde (`WebApi`, servicios externos).

### 3. Facilitar testing y mocks
Los contratos son estructuras fácilmente testeables o simulables. No dependen del framework ni de la lógica interna.

### 4. Habilitar evolución distribuida
Si un módulo se convierte en microservicio, sus contratos **ya están desacoplados**, listos para ser publicados como NuGet o gRPC proto files.

---

## 📦 Ubicación sugerida

```
Ecommerce.Contracts.<NombreModulo>
├── Commands/
├── Queries/
├── Dtos/
├── Events/
└── Responses/
```
## 🧠 Reglas del uso correcto

- ❌ La capa `Application` **no define** sus propios comandos.
- ✅ Usa los contratos que se encuentran en `Ecommerce.Contracts.*`
- ✅ El controller construye y despacha comandos del contrato, sin conocer el handler real.
- ✅ El handler recibe esos comandos como input, y devuelve estructuras de salida también definidas en el contrato.

---

## 🔄 Ejemplo

```csharp
// Controller (WebApi)
var cmd = new SignInCommand(email, password);
var token = await _dispatcher.DispatchAsync<SignInCommand, TokenDto>(cmd);

// Handler (Application)
public class SignInHandler : ICommandHandler<SignInCommand, TokenDto>
{
    public async Task<TokenDto> Handle(SignInCommand command, CancellationToken ct) { ... }
}
```