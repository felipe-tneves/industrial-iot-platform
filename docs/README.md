# Documentação do Industrial IoT Platform

Este diretório reúne os documentos iniciais de análise e planejamento do
**Industrial IoT Platform**.

## Documentos

1.  [`01-problema-e-objetivos.md`](01-problema-e-objetivos.md) ---
    contexto industrial, problema, objetivos e limites de segurança.
2.  [`02-perfis-e-permissoes.md`](02-perfis-e-permissoes.md) --- perfis
    de usuários e matriz de permissões.
3.  [`03-requisitos.md`](03-requisitos.md) --- requisitos funcionais e
    não funcionais, com critérios de aceite.
4.  [`04-escopo-e-roadmap.md`](04-escopo-e-roadmap.md) --- escopo do
    MVP, itens adiados e evolução planejada.
5.  [`05-regras-de-negocio.md`](05-regras-de-negocio.md) --- regras que
    orientam a implementação.

## Premissas

-   O produto começa como uma aplicação educacional/de portfólio, com
    cenário industrial simulado.
-   A primeira versão é de **monitoramento e apoio à decisão**. Não
    controla máquinas nem substitui sistemas industriais de segurança.
-   Os dados podem vir de um simulador antes de existir integração com
    ESP32 ou sensores físicos.
-   Decisões sobre banco, cloud, autenticação e broker MQTT poderão ser
    registradas em decisões técnicas conforme o projeto evoluir.

## Como usar

Mantenha estes documentos atualizados quando os requisitos mudarem. Cada
requisito deve poder ser rastreado até uma tarefa, implementação ou
teste no repositório.
