# Kafka WinForms Sample

Kafka를 이용한 메시지 송수신 및 MSSQL 저장/조회 샘플 프로젝트입니다.

본 프로젝트는 Kafka 기술 검증(POC)을 목적으로 개발되었으며, WinForms 기반 Producer / Consumer 프로그램과 MSSQL 저장 기능을 포함합니다.

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
├─ Program.cs
│
└─ appsettings.json
```

---

# 개발 환경

| 항목            | 내용                 |
| ------------- | ------------------ |
| Language      | C#                 |
| Framework     | .NET 10 WinForms   |
| Kafka Library | Confluent.Kafka    |
| Database      | MSSQL              |
| ORM           | ADO.NET            |
| IDE           | Visual Studio 2026 |

---

# 주요 기능

## Producer Client

* Kafka 메시지 전송
* JSON 직렬화
* Topic 지정 가능

전송 데이터

```json
{
  "userId": "user01",
  "title": "테스트 제목",
  "messageBody": "테스트 메시지",
  "sendDateTime": "2026-06-02T12:00:00"
}
```

---

## Consumer Client

* Kafka Topic 구독
* 메시지 수신
* MSSQL 저장
* DataGridView 조회
* 수신 일시정지 / 재개
* 예외 처리

---

# 아키텍처

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

Kafka 메시지 수신 후 Service 계층을 통해 Repository에 전달하고, Repository에서 MSSQL 저장을 수행합니다.

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

---

# 데이터베이스

테이블명

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

---

# 예외 처리

구현 항목

* Kafka Consume Exception
* JSON Deserialize Exception
* MSSQL Exception
* 일반 Exception

로그는 WinForms 화면에 출력됩니다.

---

# 테스트 항목

## Kafka 연결 확인

* Kafka Broker 실행
* Topic 생성
* Producer 연결 확인
* Consumer 연결 확인

## 메시지 송신

* 사용자 ID 입력
* 제목 입력
* 내용 입력
* 전송 버튼 클릭

## 메시지 수신

* Consumer 시작
* Kafka 메시지 수신 확인
* 화면 표시 확인

## MSSQL 저장

* 수신 데이터 저장 확인
* 저장 실패 로그 확인

## 데이터 조회

* 저장 데이터 조회
* 사용자 ID 검색
* 기간 검색
* 키워드 검색

---

# 향후 개선 사항

* 로그 파일 저장
* Producer Service 계층 분리
* 설정값 암호화
* 페이징 처리
* Docker 환경 구성
* Kafka Dead Letter Queue 적용

```
```
