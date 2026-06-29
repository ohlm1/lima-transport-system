# 🚚 Lima Transport System (LTS) — Core API

O **Lima Transport System (LTS)** é um ecossistema focado na resolução de gargalos operacionais no gerenciamento de logística urbana e distribuição de última milha (*last-mile*). O sistema centraliza a governança de frotas, motoristas, roteirização física e o faturamento de fretes, transformando fluxos analógicos em processos digitais auditáveis de alta performance.

Este repositório contém a **API RESTful Core**, desenvolvida com tecnologias de última geração do ecossistema Microsoft para atuar como o motor de regras de negócio e persistência de dados.

---

## 🎯 Problema de Negócio & Dores Solucionadas

Operações logísticas tradicionais sofrem com a falta de centralização e assimetria de informações, resultando em prejuízos financeiros e operacionais. O LTS atua diretamente nas seguintes dores:

* **Involução de Margem por Custos Invisíveis:** Ausência de controle fino sobre o consumo de combustível integrado às rotas e desgaste de frotas.
* **Falta de Rastreabilidade Operacional:** Dificuldade em auditar o histórico de alterações cadastrais de condutores e veículos, gerando vulnerabilidades em compliance e regulamentações (como a LGPD).
* **Processamento Ineficiente de Fretes:** Lentidão na validação de payloads e contratos de frete, gerando erros de faturamento.
* **Gargalos de Acoplamento Técnico:** Sistemas legados que misturam regras de negócio com o banco de dados, impedindo migrações de infraestrutura ou expansão para plataformas mobile e web de forma ágil.

---

## 🏗️ Decisões de Arquitetura & Design de Software

Para mitigar a complexidade do negócio e garantir um ciclo de vida longo ao software, a API foi desenhada utilizando **Clean Architecture (Arquitetura Limpa)** orientada a **Domain-Driven Design (DDD)**. 

### Benefícios Práticos da Abordagem Implementada:
1. **Independência de Frameworks:** O núcleo do software não sabe da existência de APIs Web ou ORMs.
2. **Testabilidade Isolada:** Regras de negócio e use cases podem ser testados sem a necessidade de simular conexões com bancos de dados ou interfaces visuais.
3. **Substituibilidade de Infraestrutura:** A troca do provedor de banco de dados ou bibliotecas externas gera impacto zero nas regras de domínio.

### Divisão de Responsabilidades no Repositório:
* **`LTS.Domain`:** O núcleo imutável da aplicação. Isento de referências a bibliotecas externas, abriga as Entidades (`Driver`, `Vehicle`), Objetos de Valor (*Value Objects*), Contratos de Repositórios e as validações de invariantes de negócio.
* **`LTS.Application`:** Orquestra os Casos de Uso (*Use Cases*) da aplicação. Implementa os serviços de coordenação (`DriverService`, `VehicleService`), DTOs (*Data Transfer Objects*) para tráfego limpo de dados e mapeamentos de entrada/saída.
* **`LTS.Infrastructure.Data`:** Camada de suporte operacional. Implementa o mapeamento objeto-relacional (ORM) via **Entity Framework Core**, isola consultas por meio do *Repository Pattern*, gerencia o versionamento de tabelas via *Migrations* e estabelece a conexão física com o **PostgreSQL**.
* **`LTS.API`:** Camada de Apresentação e ponto de entrada HTTP. Desenvolvida em **ASP.NET Core**, gerencia o pipeline de requisições, resolve a Injeção de Dependências (IoC), intercepta falhas via Middlewares e expõe os contratos para consumo externo.

---

## 🛠️ Stack Tecnológica & Práticas de Engenharia

O projeto utiliza os recursos mais recentes da plataforma .NET, garantindo máxima performance nativa e compilação otimizada:

* **Ambiente de Execução:** C# 14 no **.NET 10**
* **Mecanismo de Persistência:** PostgreSQL (Engine Relacional)
* **Abordagem de Banco:** Entity Framework Core 10 (*Code-First* e configuração via *Fluent API*)
* **Documentação & Contratos:** OpenAPI / Swagger UI (Mapeamento dinâmico de Endpoints)
* **Validação de Payload:** FluentValidation *(Próxima Sprint)*
* **Padrões & Princípios:** Aplicação estrita de **SOLID**, DRY (*Don't Repeat Yourself*), Clean Code e *Inversion of Control (IoC)*.

---

## 🚀 Como Executar e Testar o Ecossistema

### 1. Pré-requisitos Técnicos
* SDK do .NET 10 instalado.
* Instância ativa do banco de dados PostgreSQL local.

### 2. Inicialização por Linha de Comando (CLI)
Para clonar o ecossistema, restaurar os pacotes NuGet e inicializar o servidor de desenvolvimento, execute no seu terminal:

```bash
# Clonar o repositório
git clone [https://github.com/ohlm1/lima-transport-system.git](https://github.com/ohlm1/lima-transport-system.git)

# Acessar o diretório do backend da solução
cd lima-transport-system/backend/LimaTransportSystem

# Executar a restauração de pacotes de forma limpa
dotnet restore

# Inicializar o pipeline da Web API
dotnet run --project LTS.API/LTS.API.csproj
