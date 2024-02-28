using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Contratos
{
    public interface IRepositorioGenerico<Entity> where Entity : class
    {
        // Método para obtener todas las entidades
        IEnumerable<Entity> ObtenerTodos();

        // Método para obtener entidades que cumplan con cierta condición:
        // Buscar: Recupera una colección de entidades que cumplen con el predicado especificado.
        // El predicado es una expresión lambda que define los criterios de búsqueda.
        // Retorna una colección IEnumerable de entidades que satisfacen el predicado.
        IEnumerable<Entity> Buscar(Expression<Func<Entity, bool>> predicado);

        // Método para obtener una entidad por su ID
        Entity ObtenerPorId(object id);

        // Método para agregar una nueva entidad
        int Agregar(Entity entidad);

        // Método para actualizar una entidad
        int Editar(Entity entidad);

        // Método para eliminar una entidad por su ID
        int Eliminar(int id);

        // Método para guardar los cambios en la base de datos
        int GuardarCambios();
    }
}
