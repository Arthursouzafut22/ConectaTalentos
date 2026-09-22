<div align="center">

# 🤝 ConectaTalentos

<p>
  API REST para conectar candidatos e recrutadores, permitindo a publicação de vagas e a candidatura de candidatos às oportunidades de emprego.
</p>

<p>
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/Entity%20Framework-6DB33F?style=for-the-badge&logo=nuget&logoColor=white" alt="Entity Framework"/>
  <img src="https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white" alt="PostgreSQL"/>
  <img src="https://img.shields.io/badge/Supabase-3FCF8E?style=for-the-badge&logo=supabase&logoColor=white" alt="Supabase"/>
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" alt="Swagger"/>
</p>

</div>

---

## 💻 Projeto

Repositório de uma **API REST** que conecta candidatos e recrutadores. A plataforma permite que recrutadores publiquem vagas e gerenciem candidaturas, enquanto candidatos podem se candidatar a oportunidades, acompanhar seu status e gerenciar seu perfil — tudo através de uma API documentada com Swagger.

## ✨ Funcionalidades

- ✅ Autenticação e registro de usuários (candidatos e recrutadores)
- ✅ Publicação, edição e exclusão de vagas
- ✅ Candidatura de candidatos às vagas
- ✅ Acompanhamento de candidaturas e status
- ✅ Download de currículo em PDF
- ✅ Gerenciamento de perfil
- ✅ Fila de processamento de e-mails com Background Service
- ✅ Documentação interativa via Swagger

## 🚀 Recursos Utilizados

- `ASP.NET Core`
- `C#`
- `Entity Framework Core`
- `PostgreSQL`
- `Supabase`
- `Swagger`

## 🗺️ Endpoints

### Autenticação

| Método | Rota                          | Descrição                  |
|--------|-------------------------------|------------------------------|
| POST   | `/v1/autenticacao/registrar`  | Registra um novo usuário     |
| POST   | `/v1/autenticacao/login`      | Autentica um usuário         |

### Vagas

| Método | Rota                          | Descrição                       |
|--------|-------------------------------|-----------------------------------|
| GET    | `/v1/vagas`                   | Lista todas as vagas              |
| GET    | `/v1/vagas/{id}`              | Consulta uma vaga específica      |
| PATCH  | `/v1/vagas/{id}`               | Atualiza uma vaga                 |
| DELETE | `/v1/vagas/{id}`              | Remove uma vaga                   |
| GET    | `/v1/vagas/minhas-publicadas` | Lista as vagas publicadas pelo usuário |
| POST   | `/v1/vagas/publicar-vaga`     | Publica uma nova vaga             |

### Candidaturas

| Método | Rota                                              | Descrição                              |
|--------|-----------------------------------------------------|-------------------------------------------|
| POST   | `/v1/candidaturas/vagas/{jobId}/candidatar`         | Realiza a candidatura a uma vaga          |
| GET    | `/v1/candidaturas/vagas/{id}/ver-candidatos`        | Lista os candidatos de uma vaga           |
| GET    | `/v1/candidaturas/minhas-candidaturas`              | Lista as candidaturas do usuário          |
| GET    | `/v1/candidaturas/{id}/curriculo/baixar-pdf`        | Baixa o currículo do candidato em PDF     |
| PATCH  | `/v1/candidaturas/{id}/atualizar-status-vaga`       | Atualiza o status de uma candidatura      |

### Perfil

| Método | Rota                    | Descrição                  |
|--------|--------------------------|------------------------------|
| GET    | `/v1/perfil/meu-perfil` | Retorna os dados do perfil do usuário logado |

## 📸 Screenshot

<div align="center">
  <img width="1897" height="902" alt="image" src="https://github.com/user-attachments/assets/ee564753-ed57-40de-af3a-ea3918aa2f36" />
</div>

## 👤 Autor

**Arthur Souza**

<p>
  <a href="https://github.com/Arthursouzafut22"><img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white"/></a>
  <a href="https://www.linkedin.com/in/arthur-souza-588168256/"><img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white"/></a>
</p>

---

<div align="center">
  Feito com 💜 por Arthur Souza
</div>
