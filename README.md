# NET-6-Employee
Project that integrates connection between MySQL and .NET6


Para el desarrollo de requisitos se crearon tres tablas la tabla employees, tiene los campos 
name, last_name, personal_address, phone, workin_start_date, picture, fk_rol and salary.
Fk_rol es foránea de la tabla roles que consta de dos filas: fk_rol and rol_description.
La tabla salary_history tiene las filas salary_period que es el salario que gana el empleado entre las fechas date_salary_initial y date_salary_end, y el campo fk_id_employee quien es foránea de employees. 
Los campos en esta tabla se ingresan automáticamente al crear un usuario ejecuta el disparador incertFirstSalaryHistory y cuando Se integra  el procedimiento llamado spRecalculate_Salary, donde se recibe como parámetro de entrada el identificador del empleado, regresando un incremento en su salario que altera la tabla empleados.
 el procedimiento spExportDataSalary también recibe como parámetro el id de usuario y genera un archivo .csv como reporte en la carpeta C:\ProgramData\MySQL\MySQL Server 8.0\Uploads
El procedimiento spExport_dataEmployees. No recibe parámetros de entrada y genera igual que el anterior un archivo .csv en la carpeta C:\ProgramData\MySQL\MySQL Server 8.0\Uploads

Para el desarrollo en .Net se crea la capa de datos, la capa de lógica y la capa de controladores. Donde creamos la conexión con la base de dato y los diferentes protocolos, métodos get, post, put, etc.
Comenzamos creando un objeto llamado empleado que recibe los mismos datos de la tabla en base de datos, el objeto es recibido por la capa de datos en los Repositoty 
IEmployRepository implementa todos los métodos del modelo, enviando el objeto empleado para ser utilizado por IEmployRepository donde se instancian las sentencias sql y demás disparadores que se envían a la capa de controladores y serán usados por su respectivo controlador.
