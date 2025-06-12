# Etapa 1 – Contextos y Módulos

## 🎯 Objetivo

Diseñar un sistema eCommerce a partir de **contextos bien definidos** que representen el dominio real, y luego implementar esos contextos como **módulos técnicos autónomos**, respetando sus límites semánticos.

---

## 🔍 En esta etapa se busca:

- Identificar y delimitar los **Bounded Contexts** del sistema.
- Modelar cada contexto con su **propio lenguaje, reglas y entidades**.
- Implementar cada contexto como un **módulo independiente**, con estructura clara y sin acoplamientos.
- Evitar compartir entidades o servicios directamente entre contextos.
- Empezar a pensar en cómo se comunicarán (vía puertos o eventos).

---

## 📚 Contextos sugeridos para un eCommerce

| Contexto     | Responsabilidad principal                          |
|--------------|-----------------------------------------------------|
| Auth         | Registro, inicio de sesión, autenticación de usuarios |
| Compras      | Gestión de carritos, órdenes y confirmaciones       |
| Inventario   | Control de stock y disponibilidad de productos      |
| Facturación  | Emisión de comprobantes, validación fiscal, CUIT    |

---

## 🧱 Estructura esperada por módulo

Cada módulo debe tener al menos:

``` text
/<MóduloNombre>
├── Domain/
├── Application/
├── Infrastructure/
├── Presentation/
└── Module.cs (registro interno del módulo)
```

> Estos módulos pueden estar en proyectos separados o como subcarpetas dentro de un monolito modular.

---

## 🛑 Reglas de oro

- No hay referencias cruzadas entre dominios.
- Los modelos (`Usuario`, `Producto`, etc.) **no se comparten**.
- La comunicación entre módulos se realiza mediante:
  - Interfaces (`IUsuarioAuthService`)
  - Eventos de integración
  - Adaptadores (ACLs)

---
