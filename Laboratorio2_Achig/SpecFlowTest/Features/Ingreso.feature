Feature: Ingreso

A short summary of the feature
/*Este escenario es referencia a ejecutar en un caso de prueba*/
@tag1
Scenario: Ingreso del Cliente
	Given Llenar los campos de la BDD 
	| Cedula      | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
	| 15445854757 | Salas     | Juan    | 10/10/1992      | sjuan@mail.com | 0985421547 | Quito     | 1      |
	When El registro se ingresa en la BDD
	| Cedula      | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
	| 15445854757 | Salas     | Juan    | 10/10/1992      | sjuan@mail.com | 0985421547 | Quito     | 1      |
	Then El resultado se ingresa en la BDD
	| Cedula      | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
	| 15445854757 | Salas     | Juan    | 10/10/1992      | sjuan@mail.com | 0985421547 | Quito     | 1      |
