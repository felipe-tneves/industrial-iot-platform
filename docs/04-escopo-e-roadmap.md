# 4. Escopo da primeira versão (MVP) e roadmap

## 4.1 Definição do MVP

O MVP (Minimum Viable Product) é a menor versão demonstrável que valida
o fluxo central da solução: cadastrar equipamentos e sensores, registrar
medições, consultar histórico e gerar alertas simples a partir de
limites configurados.

A primeira entrega será executada localmente e usará dados inseridos
pela API ou por um pequeno simulador. A comunicação MQTT, o dashboard
completo e a IA serão incorporados depois, não precisam estar prontos
para validar o núcleo do sistema.

## 4.2 Dentro do MVP

1.  Repositório Git e documentação inicial.
2.  Solução C#/.NET com API REST.
3.  Modelo relacional para equipamentos, sensores, medições, limites e
    alertas.
4.  Persistência com Entity Framework Core e migrations.
5.  CRUD de equipamentos e sensores, com validação.
6.  Registro e consulta de medições.
7.  Regra de limite para geração de alertas.
8.  Consulta e atualização de status de alertas.
9.  Documentação OpenAPI/Swagger.
10. Testes automatizados para regras essenciais.
11. Instruções para executar e testar localmente.

## 4.3 Fora do MVP

-   Interface React completa.
-   Integração com sensores físicos/ESP32.
-   Ingestão MQTT em produção.
-   Serviço de IA e modelos de detecção de anomalias.
-   Notificações por e-mail, SMS ou mensageria.
-   Controle remoto de equipamentos.
-   Integração com PLC, SCADA, MES ou ERP reais.
-   Multiempresa ou segregação por planta.
-   Aplicativo móvel nativo.
-   Implantação com SLA, alta disponibilidade e recuperação de desastre.
-   Relatórios avançados ou exportação em vários formatos.

## 4.4 Fases sugeridas

### Fase 0 --- Preparação

Entregas: - Repositório e README. - Documento de problema, usuários,
requisitos e escopo. - Backlog inicial e convenção de commits.

Concluída quando: outra pessoa consegue entender o propósito do projeto
e identificar a primeira tarefa.

### Fase 1 --- Domínio e persistência

Entregas: - Entidades Equipment, Sensor, Measurement e Alert, com
configuração de limites. - Relacionamentos e validações. - Banco local e
migrations. - Testes das regras de domínio.

Concluída quando: dados válidos são persistidos e inconsistências
essenciais são rejeitadas.

### Fase 2 --- API REST

Entregas: - Endpoints para equipamentos, sensores, medições e alertas. -
DTOs, validação, tratamento uniforme de erros e documentação. - Testes
de unidade e de integração para fluxos principais.

Concluída quando: o fluxo de cadastro, medição, consulta e alerta pode
ser demonstrado pela API.

### Fase 3 --- Segurança e qualidade

Entregas: - Autenticação e autorização por perfil. - Logs
estruturados. - Testes de permissões e validações. - Revisão de
configuração e segredos.

Concluída quando: operações protegidas não podem ser realizadas sem a
autorização apropriada.

### Fase 4 --- Dashboard web

Entregas: - React/TypeScript. - Resumo de equipamentos e alertas. -
Histórico com gráfico e filtros. - Estados de carregamento, vazio e
erro.

Concluída quando: um usuário consegue consultar as informações
principais sem usar diretamente Swagger.

### Fase 5 --- IoT/MQTT

Entregas: - Simulador de sensores. - Broker MQTT local. - Tópicos e
formato de mensagens documentados. - Consumidor que valida, evita
duplicação e persiste medições. - Testes de desconexão e mensagens
inválidas.

Concluída quando: o simulador publica dados e eles aparecem no histórico
e nos alertas.

### Fase 6 --- IA aplicada

Entregas: - Análise exploratória de dados. - Baseline simples para
comparação. - Experimento com detector de anomalias, se houver dados
adequados. - Métricas, limitações e integração com a aplicação.

Concluída quando: resultados podem ser reproduzidos e a documentação
explica falsos positivos, limitações e como interpretar o indicador.

### Fase 7 --- Cloud e entrega profissional

Entregas: - Docker e configuração por ambiente. - Pipeline de build e
testes. - Publicação em um provedor de nuvem. - Instruções, arquitetura
atualizada, demonstração e decisões técnicas.

Concluída quando: outra pessoa consegue reproduzir a execução seguindo a
documentação e os testes do pipeline passam.

## 4.5 Critério de conclusão do MVP

O MVP está concluído quando o seguinte fluxo for demonstrável:

1.  Criar um equipamento.
2.  Cadastrar um sensor vinculado ao equipamento.
3.  Configurar um limite de medição.
4.  Registrar uma medição válida.
5.  Consultar a medição no histórico.
6.  Registrar uma medição que ultrapasse o limite.
7.  Ver o alerta criado e alterar seu status com usuário autorizado.
8.  Executar os testes automatizados e seguir o README para iniciar o
    sistema.

## 4.6 Priorização

Use três prioridades no backlog:

-   **P0 --- Essencial:** bloqueia o fluxo central do MVP.
-   **P1 --- Importante:** melhora segurança, qualidade ou usabilidade
    antes da demonstração pública.
-   **P2 --- Futuro:** depende de validação anterior ou amplia o
    produto.

Evite começar várias fases ao mesmo tempo. Finalize e teste o fluxo de
uma fase antes de aumentar a complexidade.
