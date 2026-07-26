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
- **Credenciales de Usuario**: Cuenta de usuario de Windows con **contraseña configurada** (consulte la sección de requisitos de Windows abajo).

---

## 🔑 Configuración de Credenciales de Windows (Requisito Obligatorio)

> [!IMPORTANT]
> **El usuario de Windows utilizado para programar las tareas DEBE tener una contraseña establecida.**
> 
> El Programador de Tareas de Windows (*Task Scheduler*) registra las tareas en modo de ejecución desatendida (`TaskLogonType.Password`). Esto permite que los respaldos se ejecuten automáticamente a la hora programada incluso si la computadora está bloqueada, si el usuario cerró sesión o si el servidor se reinicia.
> 
> **Métodos NO compatibles para tareas desatendidas:**
> - PIN de Windows Hello.
> - Reconocimiento facial o huella dactilar de Windows Hello.
> - Contraseña de imagen.
> - Cuentas de usuario sin contraseña (en blanco).
> 
> **Si intentas usar un PIN, Windows Hello o un usuario sin contraseña, Windows Task Scheduler rechazará las credenciales y la tarea NO funcionará ni se ejecutará.**

### 📝 ¿Cómo configurar o verificar una Contraseña en tu usuario de Windows?

#### Opción 1: Desde la Configuración de Windows (Windows 10 / Windows 11)
1. Abre el menú **Inicio** y entra a **Configuración** (o presiona la combinación de teclas `Win + I`).
2. Dirígete a la sección **Cuentas** > **Opciones de inicio de sesión**.
3. Busca el apartado **Contraseña** (*Password*).
4. Si tu cuenta no tiene contraseña o actualmente solo usas un PIN o Windows Hello:
   - Haz clic en **Agregar** (o en **Cambiar** si ya la tenías).
   - Establece una contraseña alfanumérica para tu cuenta de Windows y confirma los cambios.
5. Usa **esa misma contraseña de usuario** en el paso 5 (*Credenciales Windows*) al crear o editar la tarea en Backuper.

#### Opción 2: Desde la Consola de Comandos (CMD o PowerShell como Administrador)
Si estás en un servidor Windows Server o prefieres la línea de comandos:
1. Abre **CMD** o **PowerShell** ejecútandolo como Administrador.
2. Ejecuta el siguiente comando reemplazando los datos por tu usuario y la nueva contraseña:
   ```cmd
   net user TuNombreDeUsuario TuNuevaContraseña
   ```
3. Si la cuenta pertenece a un **Dominio de Active Directory**, cambia o verifica la contraseña desde la consola de administración del dominio (*Active Directory Users and Computers*) o presionando `Ctrl + Alt + Supr` > *Cambiar contraseña*.

---

## ☁️ Configuración Requerida en Dropbox (Integración Nube)

> [!NOTE]
> Para activar la subida de respaldos a la nube con Dropbox, debes registrar una aplicación en la consola de desarrolladores de Dropbox y otorgarle los permisos adecuados de lectura y escritura.

### 📝 Pasos para configurar tu App en Dropbox:

1. **Acceder a la Consola de Desarrolladores**:
   - Ingresa a la [Dropbox Developers Console](https://www.dropbox.com/developers/apps).
   - Inicia sesión con tu cuenta de Dropbox.

2. **Crear una nueva Aplicación**:
   - Haz clic en el botón **Create app**.
   - **Paso 1 (API)**: Selecciona **Scoped access**.
   - **Paso 2 (Access Type)**: Selecciona **Full Dropbox** (acceso a todo el almacenamiento) o **App folder** (acceso únicamente a una carpeta propia en `/Apps/NombreDeTuApp`).
   - **Paso 3 (Nombre)**: Asigna un nombre único a tu aplicación (ejemplo: `Backuper-SQL-Server01`) y haz clic en **Create app**.

3. **Configurar Permisos Obligatorios (Pestaña *Permissions*)**:
   - Dentro de la configuración de tu app recién creada, ve a la pestaña **Permissions**.
   - En la sección **Files and folders**, marca las siguientes casillas obligatorias:
     - `files.content.write` *(Obligatorio para subir y reemplazar respaldos)*.
     - `files.content.read` *(Obligatorio para leer y verificar los archivos)*.
     - `files.metadata.read` *(Obligatorio para la regla de retención y limpieza remota de respaldos viejos)*.
   - **CRÍTICO**: Haz clic en el botón **Submit** al final de la página para aplicar los permisos guardados.

4. **Obtener el Token o Refresh Token**:
   - Ve a la pestaña **Settings**.
   - **Opción A (Token de prueba / corta duración)**: En la sección *Generated access token*, haz clic en **Generate**. Copia el token generado y pégalo en el campo *Token / Refresh Token* en Backuper.
   - **Opción B (Refresh Token para Producción - Recomendado)**: 
     - Puedes configurar un Refresh Token de larga duración utilizando el formato `AppKey:AppSecret:RefreshToken` directamente en la casilla de token de Backuper para evitar la expiración de la sesión.

---

## 📖 Guía de Uso Rápido

1. **Instalación**: Copia los archivos publicados en una carpeta del servidor (ejemplo: `C:\Apps\Backuper\`).
2. **Creación de Tarea**: Ejecuta `Backuper.exe` y haz clic en **Nuevo Respaldo**.
3. **Paso 1 - Conexión SQL**: Selecciona la instancia de SQL Server, la autenticación (Windows o SQL) y elige la base de datos a respaldar. Haz clic en *Probar Conexión*.
4. **Paso 2 - Destino y Limpieza**: Selecciona el tipo de respaldo (Completo, Diferencial o Log), el tipo de compresión, la carpeta local de destino y configura la regla de limpieza deseada.
5. **Paso 3 - Programación**: Selecciona la frecuencia (Diario, Semanal o Mensual) y la hora exacta de ejecución.
6. **Paso 4 - Nube (Opcional)**: Activa la subida a Dropbox, asegúrate de haber configurado los permisos de la app en Dropbox y pega tu Token / Refresh Token.
7. **Paso 5 - Credenciales de Windows**: Proporciona el usuario y la **contraseña de Windows** (no PIN ni Windows Hello) para autorizar la creación de la tarea desatendida en Windows Task Scheduler.
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
