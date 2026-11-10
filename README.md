# 📧 FCG Notifications API

Microsserviço de **notificações** da FIAP Cloud Games (Tech Challenge — Fase 2).

## 📌 Finalidade

Simula o envio de e-mails, registrando as mensagens no console (log).

- Consome o **`UserCreatedEvent`** e "envia" o e-mail de boas-vindas
- Consome o **`PaymentProcessedEvent`** e, se o status for `Approved`, "envia" o e-mail de confirmação da compra

## 📨 Eventos

| Evento | Tipo | Campos |
|---|---|---|
| `UserCreatedEvent` | Consome | `UserId`, `Nome`, `Email` |
| `PaymentProcessedEvent` | Consome | `UserId`, `GameId`, `Price`, `Status` |

## ⚙️ Variáveis de ambiente

| Variável | Descrição | Exemplo |
|---|---|---|
| `RabbitMq__Host` | Endereço do RabbitMQ | `rabbitmq` |
| `RabbitMq__Username` | Usuário do RabbitMQ | `fcg` |
| `RabbitMq__Password` | Senha do RabbitMQ | — |
| `Filas__UsuarioCriado` | Fila que recebe o `UserCreatedEvent` | `notifications-user-created` |
| `Filas__PagamentoProcessado` | Fila que recebe o `PaymentProcessedEvent` | `notifications-payment-processed` |

No Kubernetes, os valores não sensíveis estão no **ConfigMap** (`k8s/configmap.yaml`) e os sensíveis no **Secret** (`k8s/secret.yaml`).

## 🛠️ Tecnologias

.NET 8, MassTransit + RabbitMQ, Docker e Kubernetes.

## ▶️ Como executar

A forma recomendada é pelo repositório de orquestração (`fcg-orchestration`).

```bash
docker build -t fcg-notifications-api:latest .
```

Para ver os e-mails simulados:

```bash
docker compose logs -f notifications-api
```

## ☸️ Kubernetes

```bash
kubectl apply -f k8s/
kubectl logs deployment/notifications-api
```

---

Feito por **Milena Torres**
