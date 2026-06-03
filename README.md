# Kafka WinForms Sample

Kafka를 이용한 메시지 송수신 및 MSSQL 저장/조회 샘플 프로젝트입니다.

본 프로젝트는 Kafka 기반 메시지 송수신 구조와 MSSQL 연동 방식을 검증하기 위한 POC(Proof Of Concept) 프로젝트로 개발되었습니다.

WinForms 기반 Producer / Consumer 프로그램을 구현하였으며, Kafka를 통해 전달된 메시지를 MSSQL에 저장하고 조회할 수 있도록 구성하였습니다.

---

# 프로젝트 목적

* Kafka Producer / Consumer 구조 이해
* Kafka 메시지 송수신 검증
* MSSQL 연동 검증
* WinForms 기반 관리자 화면 구현
* 향후 업무 시스템 적용을 위한 기본 아키텍처 검증

---

# 시스템 구성도

```text
[Producer WinForms]
          │
          ▼
     Kafka Broker
          │
          ▼
[Consumer WinForms]
          │
          ▼
        MSSQL
```

메시지 전송 흐름

```text
사용자 입력
      │
      ▼
Producer
      │
      ▼
Kafka Topic
      │
      ▼
Consumer
      │
      ▼
MSSQL 저장
      │
      ▼
DataGridView 조회
```

---

# 프로젝트 구조

```text
WinFormsApp1
│
├─ ConsumerApp
│
├─ ConsumerClient
│   ├─ Repositories
│   │   └─ MessageRepository.cs
│   │
│   ├─ Services
│   │   └─ MessageService.cs
│   │
│   ├─ NotificationMessage.cs
│   └─ Form1.cs
│
├─ Database
│   └─ CreateTable.sql
│
├─ appsettings.json
│
└─ Program.cs
```

---

# 개발 환경

| 항목           | 내용                   |
| ------------ | -------------------- |
| Language     | C#                   |
| Framework    | .NET 10 WinForms     |
| Kafka Client | Confluent.Kafka      |
| Database     | Microsoft SQL Server |
| DB Access    | ADO.NET              |
| IDE          | Visual Studio 2026   |
| OS           | Windows 11           |

---

# 주요 기능

## Producer Client

* Kafka 메시지 전송
* Kafka Server 설정
* Topic 설정
* JSON 직렬화
* 전송 성공 / 실패 로그 출력

전송 메시지 예시

```json
{
  "userId": "user01",
  "title": "테스트 제목",
  "messageBody": "Kafka 테스트 메시지입니다.",
  "sendDateTime": "2026-06-04 10:00:00"
}
```

---

## Consumer Client

* Kafka Topic 구독
* Consumer Group 설정
* 메시지 수신
* MSSQL 저장
* 저장 결과 로그 출력
* 수신 일시정지
* 수신 재개
* DataGridView 조회

---

# 아키텍처

Consumer는 Service 계층과 Repository 계층을 분리하여 구현하였습니다.

```text
WinForms UI
      │
      ▼
MessageService
      │
      ▼
MessageRepository
      │
      ▼
MSSQL
```

역할

### Form1

* 화면 처리
* 사용자 입력 처리
* 이벤트 처리

### MessageService

* 비즈니스 로직 처리
* UI와 Repository 연결

### MessageRepository

* MSSQL 저장
* MSSQL 조회
* SQL 관리

---

# 설정 파일

appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=KafkaTest;Trusted_Connection=True;TrustServerCertificate=True;"
  },

  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "winform-sample-topic",
    "GroupId": "notification-consumer"
  }
}
```

설정 가능한 항목

* Kafka Server
* Kafka Topic
* Consumer Group ID
* MSSQL Connection String

---

# 데이터베이스

데이터베이스

```sql
KafkaTest
```

테이블

```sql
KafkaMessageSample
```

주요 컬럼

| 컬럼명          | 설명          |
| ------------ | ----------- |
| Id           | PK          |
| UserId       | 사용자 ID      |
| Title        | 제목          |
| MessageBody  | 메시지 내용      |
| KafkaTopic   | Kafka Topic |
| SendDateTime | 전송 시간       |
| ReceivedAt   | 저장 시간       |

---

# 실행 방법

## 1. Kafka 실행

Kafka 폴더 이동

```powershell
cd C:\kafka
```

Kafka 서버 실행

```powershell
.\bin\windows\kafka-server-start.bat .\config\kraft\server.properties
```

---

## 2. Topic 생성

```powershell
.\bin\windows\kafka-topics.bat --create --topic winform-sample-topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```

Topic 확인

```powershell
.\bin\windows\kafka-topics.bat --list --bootstrap-server localhost:9092
```

---

## 3. MSSQL 준비

CreateTable.sql 실행

데이터베이스 생성

```sql
KafkaTest
```

테이블 생성

```sql
KafkaMessageSample
```

---

## 4. Consumer 실행

ConsumerClient 실행

설정값 확인

```text
Bootstrap Server : localhost:9092
Topic : winform-sample-topic
GroupId : notification-consumer
```

수신 시작 클릭

---

## 5. Producer 실행

ConsumerApp 실행

메시지 입력

```text
UserId : user01
Title : 테스트
Message : Kafka 테스트
```

전송 버튼 클릭

---

## 6. 결과 확인

Consumer 로그 확인

MSSQL 저장 확인

DataGridView 조회 확인

---

# 예외 처리

구현 항목

* Kafka 서버 연결 실패
* Kafka Consumer 오류
* Topic 오류
* JSON 역직렬화 오류
* MSSQL 연결 오류
* DB INSERT 오류
* DB SELECT 오류
* 일반 예외 처리

---

# 로그

프로그램 로그는 화면 출력과 함께 파일로 저장됩니다.

저장 위치

```text
logs
└─ yyyy-MM-dd.log
```

예시

```text
[2026-06-04 10:20:15] Consumer 시작
[2026-06-04 10:20:30] 메시지 수신
[2026-06-04 10:20:31] DB 저장 성공
```

---

# 주요 특징

* Kafka Producer / Consumer 구조 구현
* WinForms 기반 송신 / 수신 클라이언트 개발
* JSON 기반 메시지 전송
* MSSQL 저장 및 조회 기능 구현
* Repository 패턴 적용
* Service 계층 분리
* appsettings.json 기반 설정 관리
* 로그 파일 저장 기능 구현
* 예외 처리 적용

---

# 향후 개선 사항

* Producer Service 계층 분리
* 페이징 처리
* Docker 환경 구성
* Kafka Dead Letter Queue 적용
* 설정값 암호화
* ELK 기반 로그 수집

```
```
