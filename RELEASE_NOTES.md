# 🚀 Backuper v1.2.0 — Rediseño UI/UX, Ajustes por Defecto y Duplicado de Tareas

Nos complace presentar la versión **v1.2.0** de **Backuper**, una actualización mayor enfocada en un rediseño visual completo estilo **Web Dashboard**, mejoras significativas en la experiencia de usuario (UX/UI) y nuevas herramientas de productividad para la gestión de respaldos en SQL Server.

---

## ✨ Novedades Principales

### 🎨 1. Rediseño Integral de UI/UX (Estilo Web Dashboard)
- **Navegación Lateral Slate 900 (`#0F172A`)**: Nueva barra lateral limpia e intuitiva para alternar entre el Dashboard de Tareas, el Explorador de Archivos y la Configuración General.
- **Tipografía Formal (Sin Emojis)**: Eliminación total de emoticonos en favor de una tipografía estructurada (`Segoe UI` / `Segoe UI Semibold`) e insignias de estado formales (`LISTO`, `EJECUTANDO`, `NO PROGRAMADA`).
- **Tarjetas KPI en Tiempo Real**: Métricas visibles de total de tareas, tareas activas, estatus de sincronización con Dropbox y hora del próximo respaldo.
- **Grilla Amplia y Legible**: Tabla de tareas con márgenes generosos, separación de botones y scroll lateral/horizontal completo (`ScrollBars.Both`).
- **Botonera Homogénea**: Todos los botones de acción (`Nuevo Respaldo`, `Editar`, `Duplicar`, `Ejecutar Ahora`, `Eliminar`, `Ver Logs`) cuentan con dimensiones uniformes (`38px` de altura) y alineación perfecta.

---

### ⚙️ 2. Nueva Sección "Configuración General" (Ajustes por Defecto)
- **Definición Global de Parámetros**: Permite configurar previamente la instancia de SQL Server, base de datos por defecto, tipo de autenticación, carpeta local destino, token de Dropbox y credenciales de Windows.
- **Precarga Automática**: Al hacer clic en **"Nuevo Respaldo"**, el formulario se abre con todos los campos ya rellenados según tus preferencias globales, permitiéndote crear tareas en segundos.
- **Almacenamiento Cifrado**: Los tokens de Dropbox y contraseñas de Windows se guardan protegidos mediante cifrado de máquina **Windows DPAPI**.

---

### 📋 3. Función "Duplicar Job" en 1 Clic
- **Clonación Instantánea**: Permite seleccionar cualquier tarea existente y presionar el botón **Duplicar** para generar una copia exacta (`NombreTarea_Copia`).
- **Productividad**: Modifica rápidamente la frecuencia de ejecución, la base de datos o la carpeta remota sin tener que reintroducir credenciales o tokens.

---

### 🔒 4. Asistente Paso a Paso (`JobEditForm`)
- **Barra Lateral de Pasos**: Organización limpia por secciones (`1. Conexión SQL`, `2. Programación`, `3. Destino & Purga`, `4. Sincronización Nube`, `5. Credenciales Windows`).
- **Alertas de Requisitos**: Paneles informativos limpios que recuerdan los permisos necesarios en Dropbox (`files.content.write`, `files.content.read`) y la necesidad obligatoria de contar con una **contraseña de Windows tradicional** (no compatible con PIN de Windows Hello o cuentas sin contraseña) para la ejecución en segundo plano.

---

## 📦 Contenido del Paquete de Producción

Los binarios compilados en modo `Release` (.NET 8) se encuentran listos en la carpeta `ejecutables/Backupper`:

- **`Backuper.exe`**: Interfaz de usuario gráfica para gestión y configuración.
- **`BackupWorker.exe`**: Motor ejecutor de consola que ejecuta las tareas automáticas mediante el Programador de Tareas de Windows.
- **Librerías integradas**: `Dropbox.Api`, `Microsoft.Win32.TaskScheduler`, `Microsoft.Data.SqlClient`, `System.Security.Cryptography.ProtectedData`.

---

## 🛠️ Requisitos de Instalación

1. **Sistema Operativo**: Windows 10 / Windows 11 / Windows Server 2016 o superior.
2. **Runtime**: .NET 8.0 Desktop Runtime.
3. **Credenciales**: Usuario de Windows con contraseña establecida (requerida para guardar la tarea en Windows Task Scheduler).

---

¡Gracias por utilizar **Backuper**! 🚀
