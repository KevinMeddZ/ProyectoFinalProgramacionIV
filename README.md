El proyecto consiste en desarrollar un sistema informático comercial en el ambiente de desarrollo Visual Studio con C# como lenguaje de programación y SQL Server como gestor de base de datos, el cual debe cumplir con una serie de condiciones las cuales se explican a continuación.
REQUISITOS GENERALES DEL SISTEMA
Esta es la lista de requerimientos generales que todos los sistemas deben cumplir.
1.Debe contar con una pantalla de autenticación en donde el usuario deberá autenticarse para el ingreso al sistema (el usuario deberá escribir su Login (número de cédula del usuario) y clave de acceso). Esta autenticación debe realizarse contra una tabla de la base de datos llamada “Usuarios” la cual contendrá una serie de usuarios registrados que tendrán acceso al sistema. Los campos mínimos que debe contener la tabla son: cedula, nombre, apellido1, apellido2, clave, Fecha_Creacion_Usuario. Por defecto se debe crear un usuario con la cédula 05-0125-0125, con la clave 123456. Su sistema deberá de contar con un módulo desde donde se puedan crear y dar mantenimiento (Incluir, Actualizar, Eliminar y Consultar) a los usuarios del sistema, cuyos datos se almacenarán en la tabla “Usuarios”.
2.Se debe procurar que el sistema sea lo más automatizado posible, de tal manera que el usuario digite la menor cantidad de información al sistema, para evitar inconsistencias en los datos. (Tenga en mentes el uso de combos, listas, ckeckbox, etc.)
3.El desarrollo de la base de datos queda a criterio de cada uno de ustedes dependiendo del tema asignado, pero tiene que cumplir con los campos necesarios para proveer funcionalidad al Sistema. Este aspecto queda a su exclusivo análisis e iniciativa.
4.Debe desarrollar una interfaz(pantalla) principal la cual contendrá:

a.Una barra de menú principal en donde se encuentren las opciones de menú necesarias, para la operación del sistema.
b.Un fondo con una imagen que ilustre el tema asignado.
c.Una barra de estado en donde aparecerá:
i.El nombre del Sistema
ii.el usuario del sistema. Ejemplo: Login: 05-0125-0125
iii.la fecha. Ejemplo: 12/12/2023
iv.la hora. Ejemplo: 10:29:00 pm

5.El sistema debe contener un formulario en donde se indique:
a.El número de carnet y
b.nombre del o de los integrantes del grupo,
c.la sigla del curso,
d.nombre del curso y
e.el cuatrimestre actual.
f.Para el ingreso a este formulario debe haber una opción en la barra de menú llamada “Acerca de…”.
6.Entre las opciones de la barra de menú debe haber una opción que permita al usuario salir del sistema.
7.Todos los módulos de mantenimiento deben cumplir con las transacciones básicas de incluir, actualizar, eliminar y consultar.
8.El sistema al menos debe contar con la implementación de 5 reportes. Por ejemplo. Si tengo una tabla empleados en donde registro los datos personales de los empleados de una empresa, entonces uno de los reportes puede ser: Obtener un listado de todos los empleados de la empresa. Cuyo reporte contendrá los siguientes campos: cédula, nombre, apellido1, apellido2 y teléfono_Celular.
9.Cada grupo deberá definir las tablas que contendrá la base de datos de acuerdo al tema asignado.


REQUERIMIENTOS ESPECÍFICOS SEGÚN EL TEMA ASIGNADO
TEMA ASIGNADO: Sistema de CONTROL de COMPUTADORAS
REQUERIMIENTOS:
Desarrollar un sistema de información que permita llevar el control y administración del software instalado en las computadoras de una empresa.
Algunos de los campos pueden ser:
•Nombre del software,
•Versión.
•Funcionalidad,
•Fecha de Instalación,
•Nombre de la persona que lo instaló,
•Número de serie del CPU,
•Patrimonio del CPU,
•Ubicación dentro de la empresa (nombre del Departamento),
•Tipo de Licenciamiento (Con Licencia, Freeware, Shareware, etc.)
•Etc.

Algunos reportes pueden ser:
•Un reporte del software instalado en un CPU específico.
•Un reporte por tipo de licenciamiento.
•Etc.
