# APIStock

Este proyecto es una API para gestionar stocks y comentarios.


**Levantar el proyecto:**

Para levantar el proyecto, sigue estos pasos:

- Abre una terminal en la carpeta raíz del proyecto.
- Navega a la carpeta `api/`:
  ```sh
  cd api
  ```
- Restaura las dependencias del proyecto:
  ```sh
  dotnet restore

- Actualiza la base de datos:
   ```sh
   dotnet ef database update

  ```
- Ejecuta el proyecto:
  ```sh
  dotnet run
  ```

La API estará disponible en `http://localhost:5046` y la documentación de Swagger en `http://localhost:5046/swagger`.


## Configuración de Conexión a la Base de Datos

La configuración de conexión en `appsettings.json` está preparada para conectarse a una base de datos Microsoft SQL Express en local. La cadena de conexión predeterminada es la siguiente:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApiC#;Integrated Security=True;Encrypt=False;"
  }
}
````

Si deseas cambiar la cadena de conexión, puedes hacerlo en el archivo `appsettings.json`.

## Estructura del Proyecto

- `Controllers/`: Contiene los controladores de la API.
- `Data/`: Contiene el contexto de la base de datos.
- `Dtos/`: Contiene los Data Transfer Objects (DTOs).
- `Helpers/`: Contiene clases de ayuda.
- `Interfaces/`: Contiene las interfaces de los repositorios.
- `Mappers/`: Contiene los mapeadores.
- `Migrations/`: Contiene las migraciones de la base de datos.
- `Models/`: Contiene los modelos de datos.
- `Repository/`: Contiene las implementaciones de los repositorios.

## Dependencias

- .NET 8.0
- Entity Framework Core
- Swashbuckle (Swagger)
- Newtonsoft.Json

## Contribuir

Si deseas contribuir a este proyecto, por favor abre un issue o envía un pull request.

## Licencia

Este proyecto está bajo la licencia MIT.