
# ����������� �������
```
	������� asp.net web api 2 ����������� ��� �������������� ������ ��������� � ������.

	���������� ������ ������������ ��������:
	-���������� ������
	-�������������� ������
	-�������� ������
	-��������� ������ ������� ��� ����� ������ � ���������� ���������� 
		� ������������� �������� ������ (������ ���� ����������� ����� ��������� ������� 
		�� ������ ���� ������ ������ ���� ������������ � ��� �� ����� ��������� ������� 
		����� �������� ������ (��������) ���������� �������)
	-��������� ������ �� �� ��� ��������������

	������, ������������ ������� ��������� ������ ��� �������������� 
	� �������, ������������ ������� ��������� ������ ������ ���� �������:
	
		������ ��� �������������� ������ ��������� ������ ������ (id) ��������� ������� �� ������ ������,
		������ ������ �� ������ ��������� ������� ������, 
			������ ��� ���������� ���������� �������� �� ��������� ������� 
			(�.�. �� id ������������� �����, � ��������).

	������� ������ ����� � �������� ���� �� ������.


	� �������� ���� ���������� ������������ MS SQL.

	������� � ����:

	�������
	- �����

	�������������
	- ��������

	��������
	-�����

	��������
	-�������
	-���
	-��������
	-�����
	-���� ��������
	-���
	-������� (������)

	�����
	-���
	-������� (������)
	-������������� (������)
	-������� (��� ���������� ������, ������)

```

----------------------------------------------------------------------------


# ����� � ����������� ������

## ��������� �������
	- ASP.NET Web Api 2.
	- ���� ������ LocalDB MS SQL 2016 � ����������� ���������� Cyrillic_General_100_CI_AS.
	- ���� ������ ����������������� First Code.


## ��������� �������� ������
	����� ������� �������:  Update-Database   -> ������������ ����� Migrations/Configuration
	�� ��������: Add if not exits else update


## Controllers 

### DoctorsController 
	GetList ������ ������:
		�������� ������ /api/list/doctors/page/sort
			page ����� �������� 
			sort ������ ��� ���������� (����������� ������������ "FullName Cabinet Sector Specializatio") �� ��������� DoctorId
		��������� �������� ���������� URL:
			/api/list/doctors			-> ������ �������� ���������� �� DoctorId
			/api/list/doctors/sort	-> ������ �������� ���������� �� ���� sort
			/api/list/doctors/page	-> �������� page ���������� �� DoctorId
			/api/list/doctors/page/sort -> �������� page ���������� �� sort
			/api/list/doctors/sort   -> ���� sort �� ������������� ����������� �������� ������������ DoctorId

		���-�� ������� �� ���� �������� 3


	Add		(HttpPost) /api/doctors data=model_Doctor	-> ���������� ����� ������.
	
	Update	(HttpPut) /api/doctors data= model_Doctor	-> ��������� ������. 
			� �� ���������� ���������, ���� ���� ���� ���� ��������� � ����� ������ Doctor

	Delete (HttpDelete)		-> �������� ������ �� DoctorId

	Get		/api/doctors/id	-> ������� ������ Doctor �� DoctorId

	��� ��������� ��������������� � Interface/IDoctors ���������� � Interface/Doctors
	���� ����������� �� �������� ������������ HttpResponseException � ����� 500

	������ Add, Update, Delete ������ ����� Ajax ������.

	� �������� �������� �������� �������������� �������� /debgdoctor � ����������� Home
		����� ������ � ��������� ���� ��� � ������� ��������
		HttpResponseException � ������� 


### Patient
	GetList ������ ���������:
		�������� ������ /api/list/patients/page/sort
			page ����� �������� 
			sort ������ ��� ���������� (����������� ������������ "DateBirth Address Sername") �� ��������� PatientId
		��������� �������� ���������� URL:
			/api/list/patients			-> ������ �������� ���������� �� PatientId
			/api/list/patients/sort	-> ������ �������� ���������� �� ���� sort
			/api/list/patients/page	-> �������� page ���������� �� PatientId
			/api/list/patients/page/sort -> �������� page ���������� �� sort
			/api/list/patients/sort   -> ���� sort �� ������������� ����������� �������� ������������ PatientId
		
		���-�� ������� �� ���� �������� 3

	Add		(HttpPost) /api/patients data=model_Patient	 ->	���������� ����� ������

	Update	(HttpPut) /api/patients  data=model_Patient	 ->	��������� ������. 
		� �� ���������� ���������, ���� ���� ���� ���� ��������� �� ����� ������ Patient

	Delete	(HttpDelete) /api/patients/id	-> �������� ������ �� PatientId

	Get		/api/patients/id	->	������� ������ Patient �� PatientId

	��� ��������� ��������������� � Interface/IPatients ���������� � Interface/Patients
	���� ����������� �� �������� ������������ HttpResponseException � ����� 500
	
	������ Add, Update, Delete ������ ����� Ajax ������.

	� �������� �������� �������� �������������� �������� /debgpatient ����������� Home
		����� ������ � ��������� ����
		HttpResponseException � ������� 


### Home
	- Index �������� ���������� (�� ���������� ��. ����)
	- DebgPatient	url: /debgpatient	�������� ��� ������������ ������ Patient
	- DebgDoctor	url: /debgdoctor	�������� ��� ������������ ������ Doctor


### DoctorsLoad	��������������� ����������
	- GetData		url:	/api/doctorsload/id	��������������� ����� ��� �������� ������� 

	- LoadDoctors	url(httpPost):	/api/doctorsload	�������� �������� ������ � �� �� ������ Doctor
		�������� �� ������:  Add if not exits else update
		(������ ��� ������������)


-----------------------------------------------

## ������ ��� ���������� �������
	- Models/Ls_Doctors		������������ ��� �������� ������ ��������
	- Models/Ls_Patients	������������ ��� �������� ������ ���������


## API ������������
	- Models/ResProc		
		��������� ����� ����������� 
		�������� ������� HttpResponseException  (ResProc.Create_ResponseMessage)

	- Models/DoctorsApi 
		GetData ������������ ��� �������� �������� /DebgDoctor � ������ GetData

	- Models/ComnEnum -> enum ETypeModel ��� ������� ���������� ������� 
		Interface/CountPages -> GetCount_Pages


## ������������
	- url: /debgpatient �������� ������������ ������ Patient
		��. ���������:  
		debgpatient_1.png
		debgdoctor_2.png 

	- url: /debgdoctor �������� ������������ ������ Doctor
		��. ���������
		debgdoctor_1.png
		debgdoctor_2.png
