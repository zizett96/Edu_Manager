# Edu_Manager
     학사 관리 프로그램(.NET & MSSQL)
- 구현된 기능
<!---->
1. 로그인
2. 수강 신청 / 변경
3. 학생 정보 변경
#### +++추가할 것들+++
1. 학점 총량 제한(21~24)
2. 핸드폰 번호로 비밀번호 찾기
3. 전공 필수 포함 기능
---
## Database(_MSSQL)
### 테이블 구성
- e_login
<!---->
     로그인 기능 구현을 위한 테이블
<!---->
|필드 이름|데이터 형식|필드 크기|비고|
|--|--|--|--|
|id|int||Primary Key|
|userid|varchar|30||
|userpwd|varchar|30||
<!---->
- e_userinfo
<!---->
     학생 정보 저장을 위한 테이블
<!---->
|필드 이름|데이터 형식|필드 크기|비고|
|--|--|--|--|
|id|int||Primary Key|
|userid|varchar|30||
|edunum|int|||
|name|varchar|20||
|birth|varchar|30||
|email|varchar|40||
|phone|varchar|30||
<!---->
- e_subject
<!---->
     개설된 강의 목록 저장을 위한 테이블
<!---->
|필드 이름|데이터 형식|필드 크기|비고|
|--|--|--|--|
|id|int||Primary Key|
|subject|varchar|50||
<!---->
- e_userinfo
<!---->
     학생 별로 신청한 강의 저장을 위한 테이블
<!---->
|필드 이름|데이터 형식|필드 크기|비고|
|--|--|--|--|
|id|int||Primary Key|
|edunum|int|||
|subject|varchar|50||
<!---->
---
## Form Design
### Preview
<!---->
 - Form1.cs(로그인)
<!---->
![image](https://user-images.githubusercontent.com/55373791/167285648-eca95ab4-05fb-4578-a5c8-e9d755ae28e9.png)
<!---->
 - Form2.cs(학생 정보 / 수강 정보)
<!---->
![image](https://user-images.githubusercontent.com/55373791/167285579-b2bec3ce-12fc-4907-8397-c1e78a651fa5.png)
<!---->
 - Form3.cs(학생 정보 수정)
<!---->
![image](https://user-images.githubusercontent.com/55373791/167285581-788f34fa-8ab2-4916-b8bc-519532dae8a0.png)
<!---->
---
## Programing
<!---->
### List
1. Form1.cs
<!---->
#### Form1.cs
1. 
2. 
<!---->
