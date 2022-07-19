
# Техническое задание
```
	Сделать asp.net web api 2 контроллера для редактирования таблиц пациентов и врачей.

	Контрлллер должен поддерживать операции:
	-Добавление записи
	-Редактирование записи
	-Удаление записи
	-Получения списка записей для формы списка с поддержкой сортировки 
		и постраничного возврата данных (должна быть возможность через параметры указать 
		по какому полю список должен быть отсортирован и так же через параметры указать 
		какой фрагмент списка (страницу) необходимо вернуть)
	-Получение записи по ид для редактирования

	Объект, возвращаемый методом получения записи для редактирования 
	и объекты, возвращаемые методом получения списка должны быть разными:
	
		объект для редактирования должен содержать только ссылки (id) связанных записей из других таблиц,
		объект списка не должен содержать внещних ссылок, 
			вместо них необходимо возвращать значение из связанной таблицы 
			(т.е. не id специализации врача, а название).

	Никаких лишних полей в объектах быть не должно.


	В качестве базы необходимо использовать MS SQL.

	Таблицы в базе:

	Участки
	- Номер

	Специализации
	- Название

	Кабинеты
	-Номер

	Пациенты
	-Фамилия
	-Имя
	-Отчество
	-Адрес
	-Дата рождения
	-Пол
	-Участок (ссылка)

	Врачи
	-ФИО
	-Кабинет (ссылка)
	-Специализация (ссылка)
	-Участок (для участковых врачей, ссылка)

```

----------------------------------------------------------------------------


# Отчет о проделанной работе

## Структура решения
	- ASP.NET Web Api 2.
	- База данных LocalDB MS SQL 2016 с параметрами сортировки Cyrillic_General_100_CI_AS.
	- База данных конфигурировалась First Code.


## Начальная загрузка данных
	через консоль пакетов:  Update-Database   -> используется класс Migrations/Configuration
	по принципу: Add if not exits else update


## Controllers 

### DoctorsController 
	GetList список врачей:
		основной шаблон /api/list/doctors/page/sort
			page номер страницы 
			sort строка для сортировки (допускается использовать "FullName Cabinet Sector Specializatio") по умолчанию DoctorId
		Возможные варианты построения URL:
			/api/list/doctors			-> первая страница сортировка по DoctorId
			/api/list/doctors/sort	-> первая страница сортировка по полю sort
			/api/list/doctors/page	-> страница page сортировка по DoctorId
			/api/list/doctors/page/sort -> страница page сортировка по sort
			/api/list/doctors/sort   -> если sort не соответствует допустимому значению используется DoctorId

		Кол-во записей на одну страницу 3


	Add		(HttpPost) /api/doctors data=model_Doctor	-> добавление новой записи.
	
	Update	(HttpPut) /api/doctors data= model_Doctor	-> Изменение записи. 
			В БД проводится изменение, если есть хоть одно изменение в полях модели Doctor

	Delete (HttpDelete)		-> удаление записи по DoctorId

	Get		/api/doctors/id	-> Выборка модели Doctor по DoctorId

	ВСЕ обработки конфигурированы в Interface/IDoctors реализация в Interface/Doctors
	Если верификация не проходит возбуждается HttpResponseException с кодом 500

	Методы Add, Update, Delete только через Ajax запрос.

	В качестве тестовой прощадки использовалась страница /debgdoctor в контроллере Home
		Вывод данных в текстовые поля или в консоль бразуера
		HttpResponseException в консоль 


### Patient
	GetList список пациентов:
		основной шаблон /api/list/patients/page/sort
			page номер страницы 
			sort строка для сортировки (допускается использовать "DateBirth Address Sername") по умолчанию PatientId
		Возможные варианты построения URL:
			/api/list/patients			-> первая страница сортировка по PatientId
			/api/list/patients/sort	-> первая страница сортировка по полю sort
			/api/list/patients/page	-> страница page сортировка по PatientId
			/api/list/patients/page/sort -> страница page сортировка по sort
			/api/list/patients/sort   -> если sort не соответствует допустимому значению используется PatientId
		
		Кол-во записей на одну страницу 3

	Add		(HttpPost) /api/patients data=model_Patient	 ->	добавление новой записи

	Update	(HttpPut) /api/patients  data=model_Patient	 ->	Изменение записи. 
		В БД проводится изменение, если есть хоть одно изменение по полям модели Patient

	Delete	(HttpDelete) /api/patients/id	-> удаление записи по PatientId

	Get		/api/patients/id	->	Выборка модели Patient по PatientId

	ВСЕ обработки конфигурированы в Interface/IPatients реализация в Interface/Patients
	Если верификация не проходит возбуждается HttpResponseException с кодом 500
	
	Методы Add, Update, Delete только через Ajax запрос.

	В качестве тестовой прощадки использовалась страница /debgpatient контроллера Home
		Вывод данных в текстовые поля
		HttpResponseException в консоль 


### Home
	- Index свобдная информация (по материалам см. выше)
	- DebgPatient	url: /debgpatient	страница для тестирования модели Patient
	- DebgDoctor	url: /debgdoctor	страница для тестирования модели Doctor


### DoctorsLoad	вспомогательный контроллер
	- GetData		url:	/api/doctorsload/id	вспомогательный метод для тестовых страниц 

	- LoadDoctors	url(httpPost):	/api/doctorsload	загрузка исходных данных в БД по модели Doctor
		загрузка по методу:  Add if not exits else update
		(только для разработчика)


-----------------------------------------------

## Модели для построения списков
	- Models/Ls_Doctors		используется при создании списка докторов
	- Models/Ls_Patients	используется при создании списка пациентов


## API разработчика
	- Models/ResProc		
		Посредник между процедурами 
		Создание объекта HttpResponseException  (ResProc.Create_ResponseMessage)

	- Models/DoctorsApi 
		GetData используется для тестовой странице /DebgDoctor в методе GetData

	- Models/ComnEnum -> enum ETypeModel для расчета количества страниц 
		Interface/CountPages -> GetCount_Pages


## Тестирование
	- url: /debgpatient страница тестирования модели Patient
		см. скринШоты:  
		debgpatient_1.png
		debgdoctor_2.png 

	- url: /debgdoctor страница тестирования модели Doctor
		см. скринШоты
		debgdoctor_1.png
		debgdoctor_2.png
