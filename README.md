# **MyMvcApp - Contact Database Application**

## **Descripción**
MyMvcApp es una aplicación ASP.NET Core MVC diseñada para gestionar una base de datos de contactos. Permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre una lista de usuarios.

---

## **Características**
- **Listado de usuarios**: Visualiza todos los usuarios registrados.
- **Detalles de usuario**: Consulta información detallada de un usuario específico.
- **Crear usuario**: Agrega nuevos usuarios a la base de datos.
- **Editar usuario**: Modifica la información de un usuario existente.
- **Eliminar usuario**: Elimina usuarios de la base de datos.

---

## **Requisitos del sistema**
- **SDK de .NET**: Versión 8.0 o superior.
- **Azure CLI**: Para despliegues en Azure.
- **Visual Studio Code** o cualquier IDE compatible con .NET.
- **Navegador web**: Para probar la aplicación.

---

## **Estructura del proyecto**
```plaintext
MyMvcApp-Contact-Database-Application/
├── Controllers/
│   └── UserController.cs       # Controlador principal para la gestión de usuarios
├── Models/
│   └── User.cs                 # Modelo de datos para los usuarios
├── Views/
│   ├── User/
│   │   ├── Index.cshtml        # Vista para listar usuarios
│   │   ├── Details.cshtml      # Vista para mostrar detalles de un usuario
│   │   ├── Create.cshtml
