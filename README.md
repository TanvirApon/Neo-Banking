# Neo-Banking System 💳

**Neo-Banking System** is a modern, full-stack banking platform designed to simulate real-world banking operations with advanced features like transaction processing, fraud detection, and notification services. It combines a hybrid tech stack using **ASP.NET Core**, **Angular**, **Spring Boot microservices**, and cloud deployment on **Azure** and **AWS**.  

---

## 🚀 Features

- **User Management:** Role-based system (Admin, Banker, Customer) with JWT authentication.  
- **Account Management:** Open/Close accounts, view balance & transaction history.  
- **Transaction Processing:** Deposit, Withdraw, and Transfer operations handled asynchronously.  
- **Fraud Detection:** Real-time monitoring of suspicious transactions using Kafka streams.  
- **Notifications:** Email, SMS, and push alerts for transactions and system events.  
- **Admin Dashboard:** Analytics, charts, and monitoring of users and transactions.  

---

## 🛠️ Tech Stack

**Frontend:** Angular 19 + Bootstrap 5  
**Backend:** ASP.NET Core Web API (CRUD, Authentication, Account Management)  
**Microservices:** Java Spring Boot  

- **Transaction Service:** RabbitMQ  
- **Fraud Detection Service:** Kafka  
- **Notification Service:** RabbitMQ  

**Database:** SQL Server / PostgreSQL (main), DynamoDB / RDS (microservices logs)  
**Cloud:** Azure (frontend + ASP.NET API), AWS (microservices, S3, RDS/DynamoDB)  

---

## 📂 Modules

- **User Management:** Registration, login, role-based dashboards.  
- **Account Management:** Account CRUD, transaction history.  
- **Transaction Service:** Asynchronous processing via RabbitMQ.  
- **Fraud Detection:** Kafka stream monitoring & FraudLogs.  
- **Notifications:** Email/SMS/Push alerts.  

---

## 🌐 Architecture

The system uses a hybrid architecture combining monolithic ASP.NET Core APIs for core banking operations and microservices for transactions, notifications, and fraud detection.  
- **Frontend (Angular + Bootstrap):** Responsive UI for Admin, Banker, and Customer.  
- **Backend (ASP.NET Core Web API):** Handles authentication, user management, and account operations.  
- **Microservices:** Handle asynchronous processing and monitoring.  

---

## 📥 Installation

1. **Clone the repository:**  
```bash
git clone https://github.com/yourusername/neo-banking-system.git
