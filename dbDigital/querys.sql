use DBDigitalEducation

select * from Rol

insert into Rol(NameRol) values
('Administrador'),
('Docente'),
('Estudiante')

select * from Menu

insert into Menu(NameMenu,Icon,MenuUrl)
values
('Usuarios', 'account_circle' , '/pages/users'),
('Aula', 'class' , '/pages/classroom'),
('Incorporar Docente a Aula', 'person_add' , '/pages/assign_teacher_to_classroom'),
('Añadir Estudiantes a Aulas', 'group_add' , '/pages/add_students_to_classroom'),
('Agregar Tarea', 'playlist_add' , '/pages/add_assignment'),
('Agregar Foros', 'question_answer' , '/pages/add_forums'),
('Agregar Comunicacion', 'message' , '/pages/add_communication'),
('Gestión de Calificaciones','list_alt','/pages/grade_management'),
('Agenda de Tareas', 'assignment' , '/pages/my_assignments'),
('Agenda de Foros', 'forum' , '/pages/scheduled_forums'),
('Agenda de Comunicaciones', 'comment' , '/pages/message_planner'),
('Mis Calificaciones','grade','/pages/my_grades')


select * from MenuRol

insert into MenuRol(MenuId,RolId) values
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1),
(7,1),
(8,1),
(9,1),
(10,1),
(11,1),
(12,1)

insert into MenuRol(MenuId,RolId) values
(5,2),
(6,2),
(7,2),
(8,2)

insert into MenuRol(MenuId,RolId) values
(9,3),
(10,3),
(11,3),
(12,3)


select * from UserInformation

insert into UserInformation(FullName,Age,RolId,Email,UserPassword)
values('Luis Liriano',21,1,'llirianomendez@gmail.com','1234567')

insert into UserInformation(FullName,Age,RolId,Email,UserPassword)
values('Karla Lopez',31,2,'lopez@gmail.com','1234567')

insert into UserInformation(FullName,Age,RolId,Email,UserPassword)
values('Juana Sanchez',18,3,'lopez@gmail.com','1234567')

insert into UserInformation(FullName,Age,RolId,Email,UserPassword)
values('Luisa Matos',21,3,'matos@gmail.com','1234567')

insert into UserInformation(FullName,Age,RolId,Email,UserPassword)
values('Maria De los Santos',19,3,'maria@gmail.com','1234567')

insert into UserInformation(FullName,Age,RolId,Email,UserPassword)
values('Carmen Disla',16,3,'disla@gmail.com','1234567')

select * from Course

insert into Course(CourseName,UserInformationId)
values('4to A',2)

select * from StudentEnrollment

insert into StudentEnrollment(UserInformationId,CourseId)
values 
(3,1),
(4,1),
(5,1),
(6,1)

select * from Assignment

insert into Assignment(CourseId,UserInformationId,Title,AssignmentDescription,DueDate)
values (1,2,'Tarea 1','Hacer una calculador en java y subir el script en archivo PDF', '2024-02-23')

select * from Grade

insert into Grade(UserInformationId,CourseId,AssignmentId,Score,Comment) values
(3,1,1,95,'Excelente')

select * from Forum

insert into Forum(CourseId,Title,Descriptionforums,UserInformationId)
values 
(1,'Python vs C++','Hable sobre las ventajas y desventajas de cada uno de ellos',3),
(1,'Python vs C++','Hable sobre las ventajas y desventajas de cada uno de ellos',4),
(1,'Python vs C++','Hable sobre las ventajas y desventajas de cada uno de ellos',5),
(1,'Python vs C++','Hable sobre las ventajas y desventajas de cada uno de ellos',6)

select * from ForumPost

insert into ForumPost(ForumId,UserInformationId,PostText)
values
(1,3,'La sintaxis de Python es mas facil que la de C++'),
(2,4,'C++ es mas robusto con su sintaxis')

select * from Communication

insert into Communication(CourseId,UserInformationId,MessageCommunicactions)
values 
(1,3,'Este final de mes no dejare tareas, feliz resto del mes'),
(1,4,'Este final de mes no dejare tareas, feliz resto del mes'),
(1,5,'Este final de mes no dejare tareas, feliz resto del mes'),
(1,6,'Este final de mes no dejare tareas, feliz resto del mes')
