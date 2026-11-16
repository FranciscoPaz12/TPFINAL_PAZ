# TPFINAL_PAZ# Skyrim — Gestor de Alquimia

## Descripción

Aplicación de escritorio desarrollada en **C# con Windows Forms**, basada en el sistema de alquimia del videojuego Skyrim.

Permite gestionar ingredientes, elaborar pociones combinando sus efectos y almacenar la información en una base de datos SQL alojada en TiDB Cloud.

## Tecnologías utilizadas

- C#
- Windows Forms
- .NET Framework 4.7.2
- MySQL mediante MySqlConnector
- TiDB Cloud
- DotNetEnv
- Visual Studio
- Git y GitHub

## Funcionalidades

### Gestión de ingredientes

- Registrar ingredientes con nombre, cuatro efectos y calidad.
- Consultar ingredientes existentes.
- Modificar sus datos.
- Eliminar ingredientes.
- Buscar ingredientes.
- Mostrar los registros almacenados en la base de datos.

### Gestión de pociones

- Elaborar pociones combinando dos ingredientes diferentes.
- Identificar los efectos compartidos.
- Calcular la magnitud de la poción.
- Guardar las pociones y sus efectos en la base de datos.
- Consultar, modificar y eliminar pociones.
- Buscar pociones y mostrar los registros existentes.

## Base de datos

La aplicación utiliza TiDB Cloud, una base de datos SQL compatible con MySQL.

Base de datos: `skyrim_alquimia`

Tablas principales:

| Tabla | Descripción |
|---|---|
| `ingredientes` | Almacena los ingredientes, efectos y calidad. |
| `pociones` | Almacena las pociones elaboradas y sus ingredientes. |
| `efectospocion` | Almacena los efectos asociados a cada poción. |

La conexión utiliza TLS para proteger la comunicación con el servidor.

## Requisitos

- Windows.
- Visual Studio con herramientas para desarrollo de escritorio .NET.
- .NET Framework 4.7.2.
- Acceso a Internet.
- Acceso autorizado a una base de datos TiDB Cloud compatible con la estructura del proyecto.
- Certificado TLS correspondiente.

## Instalación

1. Descargar el repositorio desde GitHub.
2. Extraer el archivo ZIP.
3. Abrir la solución `TPFINAL_PAZ.sln` en Visual Studio.
4. Restaurar los paquetes NuGet.
5. Configurar la conexión a la base de datos.
6. Compilar y ejecutar el proyecto.

## Configuración de TiDB Cloud

El proyecto utiliza un archivo `.env` para almacenar los datos de conexión.

Dentro de la carpeta `TPFINAL_PAZ`, copiar `.env.example` y renombrar la copia como `.env`.

Completar las variables:

```dotenv
DB_HOST=REEMPLAZAR_HOST
DB_PORT=4000
DB_NAME=skyrim_alquimia
DB_USER=REEMPLAZAR_USUARIO
DB_PASSWORD=REEMPLAZAR_CONTRASENA
DB_SSL_CA=REEMPLAZAR_RUTA_CERTIFICADO
```

La variable `DB_SSL_CA` debe contener la ruta completa del certificado TLS en la computadora donde se ejecuta la aplicación.

**Importante:** el archivo `.env` contiene información privada y no debe publicarse en GitHub.

El archivo `.env.example` se incluye únicamente como plantilla.

## Uso de la aplicación

### Ingredientes
# Skyrim — Gestor de Alquimia

## Descripción

Aplicación de escritorio desarrollada en **C# con Windows Forms**, basada en el sistema de alquimia del juego Skyrim creada por Bethesda. Gloria a Tod Howard.

Permite gestionar ingredientes, elaborar pociones combinando sus efectos y almacenar la información en una base de datos SQL alojada en TiDB Cloud.

## Tecnologías utilizadas

- C#
- Windows Forms
- .NET Framework 4.7.2
- MySQL mediante MySqlConnector
- TiDB Cloud
- DotNetEnv
- Visual Studio
- Git y GitHub

## Funcionalidades

### Gestión de ingredientes

- Registrar ingredientes con nombre, cuatro efectos y calidad.
- Consultar ingredientes existentes.
- Modificar sus datos.
- Eliminar ingredientes.
- Buscar ingredientes.
- Mostrar los registros almacenados en la base de datos.

### Gestión de pociones

- Elaborar pociones combinando dos ingredientes diferentes.
- Identificar los efectos compartidos.
- Calcular la magnitud de la poción.
- Guardar las pociones y sus efectos en la base de datos.
- Consultar, modificar y eliminar pociones.
- Buscar pociones y mostrar los registros existentes.

## Base de datos

La aplicación utiliza TiDB Cloud, una base de datos SQL compatible con MySQL.

Base de datos: `skyrim_alquimia`

Tablas principales:

| Tabla | Descripción |
|---|---|
| `ingredientes` | Almacena los ingredientes, efectos y calidad. |
| `pociones` | Almacena las pociones elaboradas y sus ingredientes. |
| `efectospocion` | Almacena los efectos asociados a cada poción. |

La conexión utiliza TLS para proteger la comunicación con el servidor.

## Requisitos

- Windows.
- Visual Studio con herramientas para desarrollo de escritorio .NET.
- .NET Framework 4.7.2.
- Acceso a Internet.
- Acceso autorizado a una base de datos TiDB Cloud compatible con la estructura del proyecto.
- Certificado TLS correspondiente.

## Instalación

1. Descargar el repositorio desde GitHub.
2. Extraer el archivo ZIP.
3. Abrir la solución `TPFINAL_PAZ.sln` en Visual Studio.
4. Restaurar los paquetes NuGet.
5. Configurar la conexión a la base de datos.
6. Compilar y ejecutar el proyecto.

## Configuración de TiDB Cloud

El proyecto utiliza un archivo `.env` para almacenar los datos de conexión.

Dentro de la carpeta `TPFINAL_PAZ`, copiar `.env.example` y renombrar la copia como `.env`.

Completar las variables:

```dotenv
DB_HOST=REEMPLAZAR_HOST
DB_PORT=4000
DB_NAME=skyrim_alquimia
DB_USER=REEMPLAZAR_USUARIO
DB_PASSWORD=REEMPLAZAR_CONTRASENA
DB_SSL_CA=REEMPLAZAR_RUTA_CERTIFICADO
```

La variable `DB_SSL_CA` debe contener la ruta completa del certificado TLS en la computadora donde se ejecuta la aplicación.

**Importante:** el archivo `.env` contiene información privada y no debe publicarse en GitHub.

El archivo `.env.example` se incluye únicamente como plantilla.

## Uso de la aplicación

### Ingredientes

Ingresar a la gestión de ingredientes para registrar, consultar, modificar, eliminar o buscar los ingredientes disponibles.

Cada ingrediente posee cuatro efectos y un nivel de calidad.

### Elaboración de pociones

1. Seleccionar dos ingredientes diferentes.
2. Presionar el botón de elaboración.
3. El sistema identifica los efectos compartidos.
4. Se calcula la magnitud correspondiente.
5. La poción puede guardarse en la base de datos.

### Gestión de pociones

Desde la mesa de alquimia se pueden consultar, buscar, modificar y eliminar las pociones almacenadas.

## Validaciones

El sistema incorpora controles para:

- Evitar campos obligatorios vacíos.
- Verificar la calidad de los ingredientes.
- Impedir la combinación de un ingrediente consigo mismo.
- Controlar la elaboración de pociones sin efectos compartidos.
- Evitar modificaciones accidentales de registros.
- Confirmar operaciones de eliminación.
- Manejar errores de configuración y conexión SQL.

## Consideraciones

La aplicación necesita una conexión activa a TiDB Cloud para consultar y modificar los datos.

El repositorio no incluye contraseñas ni credenciales privadas. Para ejecutar el sistema es necesario configurar el acceso a una base de datos existente con las tablas correspondientes.

## Estado del proyecto

- CRUD de ingredientes implementado y probado.
- CRUD de pociones implementado y probado.
- Elaboración de pociones implementada.
- Persistencia en TiDB Cloud verificada.
- Validaciones funcionales comprobadas.
- Compilación sin errores ni advertencias reportadas.
Ingresar a la gestión de ingredientes para registrar, consultar, modificar, eliminar o buscar los ingredientes disponibles.

Cada ingrediente posee cuatro efectos y un nivel de calidad.

### Elaboración de pociones

1. Seleccionar dos ingredientes diferentes.
2. Presionar el botón de elaboración.
3. El sistema identifica los efectos compartidos.
4. Se calcula la magnitud correspondiente.
5. La poción puede guardarse en la base de datos.

### Gestión de pociones

Desde la mesa de alquimia se pueden consultar, buscar, modificar y eliminar las pociones almacenadas.

## Validaciones

El sistema incorpora controles para:

- Evitar campos obligatorios vacíos.
- Verificar la calidad de los ingredientes.
- Impedir la combinación de un ingrediente consigo mismo.
- Controlar la elaboración de pociones sin efectos compartidos.
- Evitar modificaciones accidentales de registros.
- Confirmar operaciones de eliminación.
- Manejar errores de configuración y conexión SQL.

## Consideraciones

La aplicación necesita una conexión activa a TiDB Cloud para consultar y modificar los datos.

El repositorio no incluye contraseñas ni credenciales privadas. Para ejecutar el sistema es necesario configurar el acceso a una base de datos existente con las tablas correspondientes.

## Estado del proyecto

- CRUD de ingredientes implementado y probado.
- CRUD de pociones implementado y probado.
- Elaboración de pociones implementada.
- Persistencia en TiDB Cloud verificada.
- Validaciones funcionales comprobadas.
- Compilación sin errores ni advertencias reportadas.