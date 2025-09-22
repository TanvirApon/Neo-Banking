# Neo-Banking System

Neo-Banking System is a modern, full-stack banking platform designed to simulate real-world banking operations with advanced features like transaction processing, fraud detection, and notification services. Built using a hybrid tech stack, it combines ASP.NET Core, Angular, and Spring Boot microservices with cloud deployment on Azure and AWS.

# 🚀 Features

User Management: Role-based system (Admin, Banker, Customer) with JWT authentication.

Account Management: Open/Close accounts, view balance & transaction history.

Transaction Processing: Deposit, Withdraw, and Transfer operations handled asynchronously.

Fraud Detection: Real-time monitoring of suspicious transactions using Kafka streams.

Notifications: Email, SMS, and push alerts for transactions and system events.

Admin Dashboard: Analytics, charts, and monitoring of users and transactions.

# 🛠️ Tech Stack

Frontend: Angular 19 + Bootstrap 5

Backend: ASP.NET Core Web API (CRUD, Authentication, Account Management)

Microservices: Java Spring Boot

Transaction Service (RabbitMQ)

Fraud Detection Service (Kafka)

Notification Service (RabbitMQ)

Database: SQL Server / PostgreSQL (main), DynamoDB / RDS (microservices logs)

Cloud: Azure (frontend + ASP.NET API), AWS (microservices, S3, RDS/DynamoDB)

# 📂 Modules

User Management: Registration, login, role-based dashboards.

Account Management: Account CRUD, transaction history.

Transaction Service: Asynchronous processing via RabbitMQ.

Fraud Detection: Kafka stream monitoring & FraudLogs.

Notifications: Email/SMS/Push alerts.

🌐 Architecture
