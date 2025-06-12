# ✅ Checklist – Etapa 1: Contextos y Módulos

### 📚 Modelado

- [ ] Se identificaron al menos 4 contextos principales
- [ ] Cada contexto tiene una responsabilidad semántica clara
- [ ] Se reconocieron diferencias semánticas entre entidades con nombres comunes (`Usuario`, `Producto`)

---

### 📁 Estructura de Módulos

- [ ] Cada contexto tiene su módulo técnico con estructura propia
- [ ] Cada módulo incluye al menos: `Domain/`, `Application/`, `Infrastructure/`, `Presentation/`
- [ ] Se evita usar `Shared/` para compartir entidades de negocio

---

### 🔐 Aislamiento

- [ ] No hay referencias directas entre modelos de distintos contextos
- [ ] Se usan puertos (interfaces) para comunicar dependencias externas
- [ ] La presentación de cada módulo está desacoplada de otras presentaciones

---

### 🧠 Reflexión técnica

- [ ] Se documentaron los contextos con una tabla o mapa
- [ ] Se comenzó a planificar la forma de integración futura (servicios o eventos)
