# WPF-BookM
## 환경
- Windows10
- VisualStudio 2019
- MySQL8.0
- MaterialDesign

## DB 설정
### MySQL 데이터베이스 생성 및 사용자 생성
```sql
CREATE USER 'bookuser'@'%' identified by 'book1234';
GRANT ALL privileges on *.* TO 'bookuser'@'%';
create database book;
```
### MySQL 테이블 생성
#### Book 테이블
```sql
create table book(
	id int auto_increment primary key,
    title varchar(100),
    author varchar(30),
    publisher varchar(30),
    price int
)engine=InnoDB default charset=utf8;
```

