# 2. Perfis de usuários e permissões

## 2.1 Princípio de autorização

O sistema adotará o princípio do menor privilégio: cada usuário terá
apenas as permissões necessárias para suas tarefas. A autenticação
identifica o usuário; a autorização verifica o que ele pode fazer.

Os nomes abaixo são perfis propostos para o MVP. A implementação de
login e controle de acesso pode ser desenvolvida depois do primeiro
CRUD, mas a matriz deve orientar o projeto desde o início.

## 2.2 Perfis

### Administrador

Responsável pela configuração e manutenção funcional da plataforma.

Pode: - Criar, consultar, editar e desativar usuários. - Criar,
consultar, editar e desativar equipamentos e sensores. - Configurar
limites de alerta. - Consultar medições e alertas. - Alterar o status
dos alertas. - Consultar indicadores gerais.

Não deve: - Visualizar senhas em texto puro. - Usar a plataforma para
comandar diretamente máquinas industriais.

### Técnico de manutenção

Responsável por investigar condições sinalizadas e registrar o
tratamento dos alertas.

Pode: - Consultar equipamentos, sensores e medições. - Consultar
históricos e indicadores. - Consultar alertas e alterar seus status. -
Registrar observações de atendimento, se esse recurso estiver
habilitado.

Não pode: - Gerenciar usuários. - Alterar configurações globais de
segurança. - Excluir registros históricos de medições.

### Operador

Responsável por acompanhar a situação dos equipamentos durante a
operação.

Pode: - Consultar equipamentos e sensores. - Consultar medições e o
dashboard. - Consultar alertas.

Não pode: - Gerenciar usuários. - Alterar limites de alerta. - Excluir
ou editar medições recebidas. - Administrar equipamentos e sensores,
salvo se uma permissão específica for concedida.

### Gestor / visualizador

Responsável por acompanhar indicadores e consultar informações para
apoiar decisões.

Pode: - Consultar dashboard, equipamentos, sensores, históricos e
alertas. - Aplicar filtros e consultar relatórios disponíveis.

Não pode: - Alterar cadastros. - Alterar limites. - Tratar ou excluir
alertas, salvo decisão explícita de negócio. - Gerenciar usuários.

## 2.3 Matriz de permissões

Legenda: **C** = criar; **L** = ler/consultar; **E** = editar; **D** =
desativar; **---** = sem permissão.

  ----------------------------------------------------------------------------------
  Recurso/ação            Administrador        Técnico       Operador         Gestor
  --------------------- --------------- -------------- -------------- --------------
  Dashboard e                         L              L              L              L
  indicadores                                                         

  Equipamentos                  C/L/E/D              L              L              L

  Sensores                      C/L/E/D              L              L              L

  Medições                            L              L              L              L

  Ingestão de medições          Serviço        Serviço        Serviço        Serviço
  por                        autorizado     autorizado     autorizado     autorizado
  dispositivo/serviço                                                 

  Limites de alerta             C/L/E/D              L              L              L

  Consultar alertas                   L              L              L              L

  Alterar status de                   E              E            ---            ---
  alertas                                                             

  Usuários e perfis             C/L/E/D            ---            ---            ---

  Excluir histórico de   --- por padrão            ---            ---            ---
  medições                                                            

  Comandar máquinas      Não disponível Não disponível Não disponível Não disponível
  industriais                                                         
  ----------------------------------------------------------------------------------

A ingestão automática de medições deve usar credenciais próprias de
dispositivo ou serviço, e não uma conta pessoal de usuário.

## 2.4 Regras de autorização

-   Endpoints protegidos devem validar identidade e permissão no
    backend; ocultar botões no frontend não é suficiente.
-   Usuários desativados não devem conseguir iniciar novas sessões.
-   Senhas nunca devem ser armazenadas em texto puro.
-   Tokens e segredos não devem ser enviados ao repositório.
-   Ações administrativas e mudanças de status de alertas devem ser
    registradas em log quando essa capacidade for implementada.
-   O acesso de um usuário a um equipamento ou unidade específica poderá
    ser restringido por escopo em versões futuras.

## 2.5 Decisões ainda abertas

-   Autenticação própria ou provedor de identidade externo.
-   Necessidade de separar usuários por planta/unidade.
-   Política de expiração e renovação de tokens.
-   Retenção e auditoria dos logs.
