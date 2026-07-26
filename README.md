# Backuper — Sistema de Respaldos Automáticos para SQL Server

**Backuper** es una solución empresarial en .NET 8 diseñada para la administración, automatización y programación de respaldos de bases de datos Microsoft SQL Server. Permite configurar tareas de copia de seguridad desatendidas integradas nativamente con el Programador de Tareas de Windows (*Windows Task Scheduler*), ofreciendo compresión configurable, sincronización opcional con Dropbox y políticas de retención avanzadas.

---

## 🛠️ Arquitectura del Sistema

La solución consta de dos componentes desacoplados para garantizar confiabilidad y rendimiento:

```
                  +-----------------------------------+
                  |      Backuper (GUI WinForms)      |
                  | Configuración y Gestión de Tareas |
                  +-----------------+-----------------+
                                    |
                                    v Registra la tarea desatendida
                 +------------------+------------------+
                 |     Programador de Tareas Windows   |
                 +------------------+------------------+
                                    |
                                    v Dispara la ejecución según horario
                  +-----------------+-----------------+
                  |    BackupWorker (Consola .NET)    |
                  | Motor de Respaldo, ZIP y Cloud    |
                  +-----------------------------------+
```

1. **`Backuper` (Interfaz Gráfica WinForms)**:
   - Panel de administración para crear, editar, probar conexiones y programar tareas.
   - Explorador integrado de archivos de respaldo (locales y nube).
   - Cifrado seguro de credenciales (SQL Server, Windows y Tokens de Dropbox) mediante **Windows Data Protection API (DPAPI)** a nivel de máquina.

2. **`BackupWorker` (Motor de Consola)**:
   - Proceso ligero ejecutado desatendidamente por el Programador de Tareas de Windows.
   - Ejecuta comandos T-SQL de `BACKUP DATABASE` / `BACKUP LOG` con soporte para compresión nativa de SQL Server o compresión externa a formato `.zip`.
   - Realiza verificación de integridad (`RESTORE VERIFYONLY`).
   - Sube copias de seguridad a la nube de **Dropbox** mediante subidas por bloques (*chunked sessions*) para archivos de gran volumen.
   - Aplica reglas de retención y limpieza automática local y remota.

---

## ✨ Características Principales

- **Integración Nativa con Windows Task Scheduler**:
  - Las tareas se ejecutan automáticamente a nivel de sistema (`TaskLogonType.Password`), funcionando incluso si el servidor se reinicia o no hay ningún usuario con sesión iniciada en Windows.
  - Activación del indicador `StartWhenAvailable`: Si el servidor estaba apagado a la hora del respaldo, la tarea se ejecuta inmediatamente al encender el equipo.

- **Políticas de Retención y Purga Avanzadas**:
  - **Por Cantidad**: Conserva únicamente los últimos *N* respaldos (p. ej. los últimos 10 respaldos).
  - **Por Antigüedad (Días)**: Purga respaldos que superen un número determinado de días.
  - **Ambos Combinados**: Elimina por días transcurridos y limita adicionalmente la cantidad total acumulada.
  - **Ámbito Configurable**: El usuario decide mediante casillas si la purga aplica en el disco local, en Dropbox o en ambos.

- **Explorador de Respaldos Integrado**:
  - Pestaña dedicada para examinar los archivos de respaldo existentes en disco y en la nube.
  - **Acceso Directo**: Doble clic sobre un respaldo local abre el Explorador de Windows resaltando el archivo en disco.
  - **Nube**: Doble clic sobre un respaldo en Dropbox abre la ubicación correspondiente en el navegador web.

- **Seguridad y Cifrado DPAPI**:
  - Las contraseñas de SQL Server, contraseñas de cuenta de Windows y tokens de Dropbox se almacenan cifrados con `DataProtectionScope.LocalMachine`.

- **Visualización de Logs**:
  - Registro de auditoría paso a paso generado en `%ProgramData%\Backuper\logs\`, accesible con un solo clic desde la interfaz principal.

---

## ⚙️ Requisitos del Sistema

- **Sistema Operativo**: Windows Server 2016+, Windows 10 o Windows 11.
- **Runtime**: .NET 8.0 Desktop Runtime instalado.
- **Motor de Base de Datos**: Microsoft SQL Server 2012 o superior (Express, Standard, Enterprise).
- **Permisos**: Permisos de Administrador en Windows (para registrar tareas en Task Scheduler) y permisos de escritura para la cuenta de servicio de SQL Server en la carpeta destino local.

---

## 📖 Guía de Uso Rápido

1. **Instalación**: Copia los archivos publicados en una carpeta del servidor (ejemplo: `C:\Apps\Backuper\`).
2. **Creación de Tarea**: Ejecuta `Backuper.exe` y haz clic en **Nuevo Respaldo**.
3. **Paso 1 - Conexión SQL**: Selecciona la instancia de SQL Server, la autenticación (Windows o SQL) y elige la base de datos a respaldar. Haz clic en *Probar Conexión*.
4. **Paso 2 - Destino y Limpieza**: Selecciona el tipo de respaldo (Completo, Diferencial o Log), el tipo de compresión, la carpeta local de destino y configura la regla de limpieza deseada.
5. **Paso 3 - Programación**: Selecciona la frecuencia (Diario, Semanal o Mensual) y la hora exacta de ejecución.
6. **Paso 4 - Nube (Opcional)**: Activa la subida a Dropbox e introduce tu Token o Refresh Token.
7. **Paso 5 - Credenciales de Windows**: Proporciona el usuario y contraseña de Windows para autorizar la creación de la tarea desatendida en Windows Task Scheduler.
8. **Guardar**: Haz clic en **Guardar Tarea**. La tarea quedará programada y operará automáticamente de forma autónoma.

---

## 📁 Estructura del Proyecto

```
Backuper/
├── Backuper/                  # Proyecto WinForms (UI y Configuración)
│   ├── Forms/                 # MainForm, JobEditForm
│   ├── Models/                # Modelos de configuración y enums
│   ├── Services/              # CryptoService, SqlServerService, TaskSchedulerService
│   └── app_icon.ico           # Ícono multi-resolución oficial
├── BackupWorker/              # Proyecto de Consola (Worker de ejecución)
│   └── Program.cs             # Lógica de respaldo T-SQL, ZIP, Dropbox y Retención
├── Backuper.sln               # Solución de Visual Studio
├── .gitignore                 # Filtro de archivos para Git
└── README.md                  # Documentación del proyecto
```
