using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return await this.repo.GetDepartamentosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }

        //LOS METODOS POR DEFECTO DE POST O PUT RECIBEN UN OBJETO
        //SI QUEREMOS ENVIAR PARAMETROS, DEBEMOS MAPEARLOS CON ROUTING
        [HttpPost]
        public async Task<ActionResult> InsertDepartamento(Departamento departamento)
        {
            await this.repo.InsertDepartamentoAsync(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        //EL METODO POR DEFECTO DE DELETE RECIBE UN ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartamento(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        //PODEMOS PERSONALIZAR METODOS POST, PUT O DELETE A CONVENIENCIA
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> PostDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(id, nombre, localidad);
            return Ok();
        }

        //SI LO NECESITAMOS, PODEMOS COMBINAR OBJETOS CON PARAMETROS.
        //EL OBJETO ES EL ULTIMO ELEMENTO QUE SE INCLUYE EN LA PETICION
        //DEL METODO
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> PutDepartamento(int id, Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(id, departamento.Nombre, departamento.Localidad);
            return Ok();
        }
    }
}
