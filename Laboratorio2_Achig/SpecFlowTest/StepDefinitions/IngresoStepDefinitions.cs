using System;
using Laboratorio2_Achig.Data;
using Laboratorio2_Achig.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTest.StepDefinitions
{
    [Binding]
    public class IngresoStepDefinitions
    {
        private readonly ClienteSqlDataAccessLayer _clienteDAL = new ClienteSqlDataAccessLayer();

        [Given(@"Llenar los campos de la BDD")]
        public void GivenLlenarLosCamposDeLaBDD(Table table)
        {
            var dataTable = table.Rows.Count();
            dataTable.Should().BeGreaterThanOrEqualTo(1);
        }

        [When(@"El registro se ingresa en la BDD")]
        public void WhenElRegistroSeIngresaEnLaBDD(Table table)
        {
            var cliente = table.CreateSet<ClienteSql>().ToList();
            ClienteSql clientesql = new ClienteSql();

            foreach (var item in cliente)
            {
                clientesql.Cedula = item.Cedula;
                clientesql.Apellidos = item.Apellidos;
                clientesql.Nombres = item.Nombres;
                clientesql.FechaNacimiento = item.FechaNacimiento;
                clientesql.Mail = item.Mail;
                clientesql.Telefono = item.Telefono;
                clientesql.Direccion = item.Direccion;
                clientesql.Estado = item.Estado;
            }

            _clienteDAL.AddCliente(clientesql);
        }

        [Then(@"El resultado se ingresa en la BDD")]
        public void ThenElResultadoSeIngresaEnLaBDD(Table table)
        {
            int resultado = table.Rows.Count();
            resultado.Should().BeGreaterThanOrEqualTo(1);
        }
    }
}
