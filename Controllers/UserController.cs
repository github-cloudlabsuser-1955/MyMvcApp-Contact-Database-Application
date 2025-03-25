using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

    // GET: User
    public ActionResult Index()
    {
        // Devuelve la vista con la lista de usuarios
        return View(userlist);
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        // Busca el usuario por ID en la lista
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            // Si no se encuentra el usuario, devuelve un resultado de "No encontrado"
            return NotFound();
        }

        // Devuelve la vista con los detalles del usuario
        return View(user);
    }

    // GET: User/Create
    public ActionResult Create()
    {
        // Devuelve la vista para crear un nuevo usuario
        return View();
    }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            // Agrega el nuevo usuario a la lista
            userlist.Add(user);

            // Redirige a la acción Index después de crear
            return RedirectToAction(nameof(Index));
        }

        // Si el modelo no es válido, devuelve la vista con los datos ingresados
        return View(user);
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        // Busca el usuario por ID en la lista
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            // Si no se encuentra el usuario, devuelve un resultado de "No encontrado"
            return NotFound();
        }

        // Devuelve la vista para editar el usuario
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        if (ModelState.IsValid)
        {
            // Busca el usuario existente por ID
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                // Si no se encuentra el usuario, devuelve un resultado de "No encontrado"
                return NotFound();
            }

            // Actualiza los datos del usuario
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            // Redirige a la acción Index después de editar
            return RedirectToAction(nameof(Index));
        }

        // Si el modelo no es válido, devuelve la vista con los datos ingresados
        return View(user);
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        // Busca el usuario por ID en la lista
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            // Si no se encuentra el usuario, devuelve un resultado de "No encontrado"
            return NotFound();
        }

        // Devuelve la vista de confirmación de eliminación con los datos del usuario
        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            // Busca el usuario por ID en la lista
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Si no se encuentra el usuario, devuelve un resultado de "No encontrado"
                return NotFound();
            }

            // Elimina el usuario de la lista
            userlist.Remove(user);

            // Redirige a la acción Index después de eliminar
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            // Si ocurre un error, devuelve la vista de eliminación con el usuario
            return View();
        }
    }
}
